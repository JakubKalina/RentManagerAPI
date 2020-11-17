using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Room.Responses
{
    public class GetLandlordRoomsResponse
    {
        public IEnumerable<RoomForGetLandlordRoomsResponse> Data { get; set; }
    }

    public class RoomForGetLandlordRoomsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
