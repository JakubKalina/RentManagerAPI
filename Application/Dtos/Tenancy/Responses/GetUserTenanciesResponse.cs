using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Tenancy.Responses
{
    public class GetUserTenanciesResponse
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Deposit { get; set; }

        public virtual RoomForGetUserTenanciesResponse Room { get; set; }
    }

    public class RoomForGetUserTenanciesResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
