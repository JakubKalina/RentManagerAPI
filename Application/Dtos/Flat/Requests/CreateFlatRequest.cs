using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dtos.Flat.Requests
{
    public class CreateFlatRequest
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string HomeAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }
    }
}
