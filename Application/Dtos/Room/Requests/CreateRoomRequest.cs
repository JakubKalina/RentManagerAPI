using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Room.Requests
{
    public class CreateRoomRequest
    {
        public int FlatId { get; set; }
        public string Name { get; set; }
    }
}
