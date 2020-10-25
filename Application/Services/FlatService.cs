﻿using Application.Dtos.Flat.Requests;
using Application.Dtos.Flat.Responses;
using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using Domain.Models.Entities;
using Domain.Models.Entities.Association;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FlatService : Service, IFlatService
    {
        public FlatService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
                
        }

        public async Task<ServiceResponse> CreateFlatAsync(CreateFlatRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            var landlord = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flatAddress = new Address()
            {
                HomeAddress = request.HomeAddress,
                City = request.City,
                PostalCode = request.PostalCode,
            };

            var flat = new Flat()
            {
                Description = request.Description,
                Address = flatAddress
            };

            var flatLandlord = new FlatLandlord()
            {
                User = landlord,
                Flat = flat
            };

            Context.Flats.Add(flat);
            Context.FlatLandlords.Add(flatLandlord);

            await SaveChangesAsync(new[] { $"Wystąpił błąd podczas dodawania nowego mieszkania" });
            return new ServiceResponse(HttpStatusCode.OK);
        }

        public async Task<ServiceResponse> DeleteFlatAsync(int flatId)
        {
            string userId = CurrentlyLoggedUser.Id;

            var landlord = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == landlord.Id && fl.FlatId == flatId).SingleOrDefaultAsync();

            if(flatLandlord != null)
            {
                Context.FlatLandlords.Remove(flatLandlord);
                var flat = await GetEntityByIdAsync<Flat>(flatId);
                Context.Flats.Remove(flat);
            }

            await SaveChangesAsync(new[] { $"Wystąpił błąd podczas usuwania mieszkania" });
            return new ServiceResponse(HttpStatusCode.OK);
        }

        public async Task<ServiceResponse<GetFlatsResponse>> GetFlatsAsync(GetFlatsRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            var user = await GetEntityByIdAsync<ApplicationUser>(userId);
            var role = await UserManager.GetRolesAsync(user);

            IQueryable<Flat> dbQuery;
            List<Flat> flats;
            List<FlatForGetFlatsResponse> flatsDto = new List<FlatForGetFlatsResponse>();

            int  totalNumberOfItems = 0;
            switch (role.ElementAt(0))
            {
                case Role.Administrator:
                    dbQuery = Context.Flats;

                    totalNumberOfItems = await dbQuery.CountAsync();
                    flats = await dbQuery.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

                    flatsDto = Mapper.Map<IEnumerable<Flat>, IEnumerable<FlatForGetFlatsResponse>>(flats).ToList();
                    break;
                case Role.Landlord:
                    dbQuery = Context.FlatLandlords.Where(fl => fl.UserId == user.Id).Select(fl => fl.Flat);

                    totalNumberOfItems = await dbQuery.CountAsync();
                    flats = await dbQuery.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

                    flatsDto = Mapper.Map<IEnumerable<Flat>, IEnumerable<FlatForGetFlatsResponse>>(flats).ToList();

                    break;

                case Role.Tenant:
                    dbQuery = Context.Tenancies.Where(t => t.UserId == user.Id && t.EndDate < DateTime.Now).Select(t => t.Flat);
                    totalNumberOfItems = await dbQuery.CountAsync();
                    flats = await dbQuery.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
                    flatsDto = Mapper.Map<IEnumerable<Flat>, IEnumerable<FlatForGetFlatsResponse>>(flats).ToList();
                    break;
            }

            var response = new GetFlatsResponse(request, flatsDto, 0);

            return new ServiceResponse<GetFlatsResponse>(HttpStatusCode.OK, response);

        }

        public async Task<ServiceResponse> UpdateFlatAsync(UpdateFlatRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            var flat = await GetEntityByIdAsync<Flat>(request.FlatId);
            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == userId && fl.FlatId == flat.Id).SingleOrDefaultAsync();

            if(flatLandlord != null)
            {
                flat.Description = request.Description;
                flat.Address.HomeAddress = request.HomeAddress;
                flat.Address.City = request.City;
                flat.Address.PostalCode = request.PostalCode;
            }

            await SaveChangesAsync(new[] { $"Wystąpił błąd podczas edycji danych mieszkania" });
            return new ServiceResponse(HttpStatusCode.OK);
        }
    }
}
