using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Flat.Responses
{
    public class GetTenantFlatsResponse : PagedResponse<FlatForGetTenantFlatsResponse>
    {
        public GetTenantFlatsResponse(PaginationQuery request, IEnumerable<FlatForGetTenantFlatsResponse> data, int totalNumberOfItems) : base(request, data, totalNumberOfItems)
        {

        }
    }
    public class FlatForGetTenantFlatsResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual AddressForFlatForGetTenantFlatsResponse Address { get; set; }
    }

    public class AddressForFlatForGetTenantFlatsResponse
    {
        public string HomeAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
