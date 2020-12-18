using Application.Dtos.Flat.Requests;
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

        public async Task<ServiceResponse<GetFlatResponse>> GetFlatAsync(int flatId)
        {
            string userId = CurrentlyLoggedUser.Id;

            var user = await GetEntityByIdAsync<ApplicationUser>(userId);
            var flatLandlord = await Context.FlatLandlords.SingleOrDefaultAsync(fl => fl.UserId == user.Id && fl.FlatId == flatId);
            var flat = await Context.Flats.SingleOrDefaultAsync(f => f.Id == flatLandlord.FlatId);

            var flatDto = Mapper.Map<Flat, GetFlatResponse>(flat);

            return new ServiceResponse<GetFlatResponse>(HttpStatusCode.OK, flatDto);
        }


        public async Task<ServiceResponse<GetLandlordFlatsResponse>> GetLandlordFlatsAsync(GetLandlordFlatsRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            var user = await GetEntityByIdAsync<ApplicationUser>(userId);

            IQueryable<Flat> dbQuery;
            List<Flat> flats;
            List<FlatForGetLandlordFlatsResponse> flatsDto = new List<FlatForGetLandlordFlatsResponse>();
            int totalNumberOfItems = 0;


            dbQuery = Context.FlatLandlords.Where(fl => fl.UserId == user.Id).Select(fl => fl.Flat);

            totalNumberOfItems = await dbQuery.CountAsync();
            flats = await dbQuery.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

            flatsDto = Mapper.Map<IEnumerable<Flat>, IEnumerable<FlatForGetLandlordFlatsResponse>>(flats).ToList();

            var response = new GetLandlordFlatsResponse(request, flatsDto, 0);

            return new ServiceResponse<GetLandlordFlatsResponse>(HttpStatusCode.OK, response);
        }

        public async Task<ServiceResponse<GetTenantFlatsResponse>> GetTenantFlatsAsync(GetTenantFlatsRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            var user = await GetEntityByIdAsync<ApplicationUser>(userId);

            IQueryable<Flat> dbQuery;
            List<Flat> flats;
            List<FlatForGetTenantFlatsResponse> flatsDto = new List<FlatForGetTenantFlatsResponse>();
            int totalNumberOfItems = 0;

            dbQuery = Context.Tenancies.Where(t => t.UserId == user.Id && t.EndDate > DateTime.Now).Select(t => t.Flat);
            totalNumberOfItems = await dbQuery.CountAsync();
            flats = await dbQuery.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
            flatsDto = Mapper.Map<IEnumerable<Flat>, IEnumerable<FlatForGetTenantFlatsResponse>>(flats).ToList();



            var response = new GetTenantFlatsResponse(request, flatsDto, 0);

            return new ServiceResponse<GetTenantFlatsResponse>(HttpStatusCode.OK, response);
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

        public async Task<ServiceResponse<GetAdminFlatsResponse>> GetAdminFlatsAsync(GetAdminFlatsRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            var user = await GetEntityByIdAsync<ApplicationUser>(userId);

            IQueryable<Flat> dbQuery;
            List<Flat> flats;
            List<FlatForGetAdminFlatsResponse> flatsDto = new List<FlatForGetAdminFlatsResponse>();
            int totalNumberOfItems = 0;


            dbQuery = Context.Flats;

            totalNumberOfItems = await dbQuery.CountAsync();
            flats = await dbQuery.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

            flatsDto = Mapper.Map<IEnumerable<Flat>, IEnumerable<FlatForGetAdminFlatsResponse>>(flats).ToList();

            var response = new GetAdminFlatsResponse(request, flatsDto, 0);

            return new ServiceResponse<GetAdminFlatsResponse>(HttpStatusCode.OK, response);
        }
    }
}
