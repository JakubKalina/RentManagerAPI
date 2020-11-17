using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Tenancy.Requests
{
    public class BeginTenancyRequest
    {
        public int flatId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Deposit { get; set; }

        public int? RoomId { get; set; }

        public string UserId { get; set; }

    }
}
