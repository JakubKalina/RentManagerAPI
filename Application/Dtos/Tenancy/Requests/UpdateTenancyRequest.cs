using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Tenancy.Requests
{
    public class UpdateTenancyRequest
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Deposit { get; set; }
    }
}
