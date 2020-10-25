using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Room.Responses
{
    public class GetRoomsResponse
    {
        public IEnumerable<RoomForGetRoomsResponse> Rooms { get; set; }
    }

    public class RoomForGetRoomsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
