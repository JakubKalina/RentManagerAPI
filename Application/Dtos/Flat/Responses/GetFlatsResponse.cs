using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Flat.Responses
{
    public class GetFlatsResponse : PagedResponse<FlatForGetFlatsResponse>
    {
        public GetFlatsResponse(PaginationQuery request, IEnumerable<FlatForGetFlatsResponse> data, int totalNumberOfItems) : base(request, data, totalNumberOfItems)
        {

        }
    }

    public class FlatForGetFlatsResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual AddressForFlatForGetFlatsResponse Address { get; set; }
    }

    public class AddressForFlatForGetFlatsResponse
    {
        public string HomeAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
