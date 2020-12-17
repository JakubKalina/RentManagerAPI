using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Flat.Responses
{
    public class GetAdminFlatsResponse : PagedResponse<FlatForGetAdminFlatsResponse>
    {
        public GetAdminFlatsResponse(PaginationQuery request, IEnumerable<FlatForGetAdminFlatsResponse> data, int totalNumberOfItems) : base(request, data, totalNumberOfItems)
        {

        }
    }

    public class FlatForGetAdminFlatsResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual AddressForFlatForGetAdminFlatsResponse Address { get; set; }
    }

    public class AddressForFlatForGetAdminFlatsResponse
    {
        public string HomeAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
