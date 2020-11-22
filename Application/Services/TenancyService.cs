using Application.Dtos.Tenancy.Requests;
using Application.Dtos.Tenancy.Responses;
using Application.Infrastructure.Errors;
using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TenancyService : Service, ITenancyService
    {
        public TenancyService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<ServiceResponse> BeginTenancy(BeginTenancyRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            var landlord = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == landlord.Id && fl.FlatId == request.flatId).SingleOrDefaultAsync();

            if(flatLandlord != null)
            {
                    var flat = await GetEntityByIdAsync<Flat>(request.flatId);
                    var user = await GetEntityByIdAsync<ApplicationUser>(request.UserId);

                    var room = await Context.Rooms.SingleOrDefaultAsync(r => r.Id == request.RoomId);

                    var userRoles = await UserManager.GetRolesAsync(user);

                    // Możemy dodać tylko najemce
                    if(userRoles.Contains(Role.Tenant))
                    {
                        var tenancy = new Tenancy()
                        {
                            StartDate = request.StartDate,
                            EndDate = request.EndDate,
                            Deposit = request.Deposit,
                            Flat = flat,
                            User = user,
                            Room = room
                        };
                        Context.Tenancies.Add(tenancy);

                        await SaveChangesAsync(new[] { $"Wystąpił błąd podczas dodawania nowego najmu mieszkania" });
                        return new ServiceResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        throw new RestException(HttpStatusCode.BadRequest);
                    }
            }
            else
            {
                throw new RestException(HttpStatusCode.BadRequest);
            }

        }

        public async Task<ServiceResponse<IList<GetFlatTenanciesResponse>>> GetFlatTenanciesAsync(int flatId)
        {
            string userId = CurrentlyLoggedUser.Id;

            var landlord = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == landlord.Id && fl.FlatId == flatId).SingleOrDefaultAsync();

            IList<GetFlatTenanciesResponse> response = new List<GetFlatTenanciesResponse>();
            // Jeżeli zalogowana osoba jest zarządcą
            if(flatLandlord != null)
            {
                var tenancies = await Context.Tenancies.Where(t => t.EndDate > DateTime.Now && t.FlatId == flatId).ToListAsync();
                response = Mapper.Map<ICollection<Tenancy>, IList<GetFlatTenanciesResponse>>(tenancies).ToList();
            }

            return new ServiceResponse<IList<GetFlatTenanciesResponse>>(HttpStatusCode.OK, response);
        }

        public async Task<ServiceResponse<GetFlatTenancyResponse>> GetFlatTenancyAsync(int tenancyId)
        {

            string userId = CurrentlyLoggedUser.Id;

            var landlord = await GetEntityByIdAsync<ApplicationUser>(userId);

            var tenancy = await Context.Tenancies.SingleOrDefaultAsync(t => t.Id == tenancyId);

            var tenancyFlatId = tenancy.FlatId;

            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == landlord.Id && fl.FlatId == tenancyFlatId).SingleOrDefaultAsync();

            GetFlatTenancyResponse response = new GetFlatTenancyResponse();

            // Jeżeli zalogowana osoba jest zarządcą
            if (flatLandlord != null)
            {

                response = Mapper.Map<Tenancy, GetFlatTenancyResponse>(tenancy);
            }
            return new ServiceResponse<GetFlatTenancyResponse> (HttpStatusCode.OK, response);
        }

        public async Task<ServiceResponse<IList<GetUserTenanciesResponse>>> GetUserTenanciesAsync()
        {
            string userId = CurrentlyLoggedUser.Id;

            var landlord = await GetEntityByIdAsync<ApplicationUser>(userId);

            IList<GetUserTenanciesResponse> response = new List<GetUserTenanciesResponse>();

            var tenancies = await Context.Tenancies.Where(t => t.EndDate > DateTime.Now && t.UserId == userId).ToListAsync();

            response = Mapper.Map<ICollection<Tenancy>, IList<GetUserTenanciesResponse>>(tenancies).ToList();

            return new ServiceResponse<IList<GetUserTenanciesResponse>>(HttpStatusCode.OK, response);
        }

        public async Task<ServiceResponse> UpdateTenancy(UpdateTenancyRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            var landlord = await GetEntityByIdAsync<ApplicationUser>(userId);

            var tenancy = await Context.Tenancies.SingleOrDefaultAsync(t => t.Id == request.Id);

            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == landlord.Id && fl.FlatId == tenancy.FlatId).SingleOrDefaultAsync();

            IList<GetFlatTenanciesResponse> response = new List<GetFlatTenanciesResponse>();
            // Jeżeli zalogowana osoba jest zarządcą
            if (flatLandlord != null)
            {
                tenancy.StartDate = request.StartDate;
                tenancy.EndDate = request.EndDate;
                tenancy.Deposit = request.Deposit;
            }

            await SaveChangesAsync(new[] { $"Wystąpił błąd podczas edycji danych najmu" });
            return new ServiceResponse(HttpStatusCode.OK);
        }
    }
}
