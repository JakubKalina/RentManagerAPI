using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Tenancy.Responses
{
    public class GetFlatTenanciesResponse
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Deposit { get; set; }

        public virtual RoomForGetFlatTenanciesResponse Room { get; set; }

        public virtual UserForGetFlatTenanciesResponse User { get; set; }
    }

    public class RoomForGetFlatTenanciesResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class UserForGetFlatTenanciesResponse
    {
        public string Id { get; set; }
        public string SearchId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
