using Application.Dtos.Room.Requests;
using Application.Dtos.Room.Responses;
using Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRoomService
    {
        /// <summary>
        /// Zwraca właścicielowi/zarządcy listę wszystkich pokoi w mieszkaniu
        /// </summary>
        /// <param name="flatId"></param>
        /// <returns></returns>
        Task<ServiceResponse<GetLandlordRoomsResponse>> GetLandlordRoomsAsync(int flatId);

        /// <summary>
        /// Tworzy nowy pokój i przypisuje go do mieszkania
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> CreateRoomAsync(CreateRoomRequest request);

        /// <summary>
        /// Usuwa wybrany pokój dla podanego mieszkania
        /// </summary>
        /// <param name="flatId"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
        Task<ServiceResponse> DeleteRoomAsync(int flatId, int roomId);
    }
}
