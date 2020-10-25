using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Address : IHasIntId
    {
        public int Id { get; set; }
        public string HomeAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int FlatId { get; set; }
        public virtual Flat Flat { get; set; }
    }
}
