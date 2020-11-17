using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Flat.Responses
{
    public class GetLandlordFlatsResponse : PagedResponse<FlatForGetLandlordFlatsResponse>
    {
        public GetLandlordFlatsResponse(PaginationQuery request, IEnumerable<FlatForGetLandlordFlatsResponse> data, int totalNumberOfItems) : base(request, data, totalNumberOfItems)
        {

        }
    }

    public class FlatForGetLandlordFlatsResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual AddressForFlatForGetLandlordFlatsResponse Address { get; set; }
    }

    public class AddressForFlatForGetLandlordFlatsResponse
    {
        public string HomeAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
