using Application.Dtos.Room.Requests;
using Application.Dtos.Room.Responses;
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
    public class RoomService : Service, IRoomService
    {
        public RoomService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<ServiceResponse> CreateRoomAsync(CreateRoomRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;
            var user = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flat = await GetEntityByIdAsync<Flat>(request.FlatId);
            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == userId && fl.FlatId == flat.Id).SingleOrDefaultAsync();

            if(flatLandlord != null)
            {
                var room = new Room()
                {
                    Name = request.Name,
                    Flat = flat
                };
                Context.Rooms.Add(room);
            }

            await SaveChangesAsync(new[] { $"Wystąpił błąd podczas dodawania nowego pokoju do mieszkania" });
            return new ServiceResponse(HttpStatusCode.OK);
        }

        public async Task<ServiceResponse> DeleteRoomAsync(int flatId, int roomId)
        {
            string userId = CurrentlyLoggedUser.Id;
            var user = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flat = await GetEntityByIdAsync<Flat>(flatId);
            if(flat == null)
                throw new RestException(HttpStatusCode.BadRequest);

            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == userId && fl.FlatId == flat.Id).SingleOrDefaultAsync();

            if(flatLandlord != null)
            {
                var room = flat.Rooms.Where(r => r.Id == roomId).SingleOrDefault();
                if (room == null)
                    throw new RestException(HttpStatusCode.BadRequest);
                Context.Rooms.Remove(room);
            }
            else
                throw new RestException(HttpStatusCode.BadRequest);

            await SaveChangesAsync(new[] { $"Wystąpił błąd podczas usuwania wybranego pokoju z mieszkania" });
            return new ServiceResponse(HttpStatusCode.OK);
        }

        public async Task<ServiceResponse<GetRoomsResponse>> GetRoomsAsync(int flatId)
        {
            string userId = CurrentlyLoggedUser.Id;
            var user = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flat = await GetEntityByIdAsync<Flat>(flatId);
            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == userId && fl.FlatId == flat.Id).SingleOrDefaultAsync();

            var response = new GetRoomsResponse();
            if(flatLandlord != null)
            {
                var rooms = flat.Rooms;
                var roomsDto = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomForGetRoomsResponse>>(rooms);
                response.Rooms = roomsDto;
            }

            return new ServiceResponse<GetRoomsResponse>(HttpStatusCode.OK, response);
        }
    }
}
