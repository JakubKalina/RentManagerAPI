using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Flat.Responses
{
    public class GetFlatResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual AddressForGetFlatResponse Address { get; set; }
    }

    public class AddressForGetFlatResponse
    {
        public string HomeAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }

}
