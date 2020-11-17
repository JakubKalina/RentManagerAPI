using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Tenancy.Responses
{
    public class GetFlatTenancyResponse
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Deposit { get; set; }
    }


}
