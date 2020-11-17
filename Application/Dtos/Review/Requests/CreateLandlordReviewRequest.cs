using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Review.Requests
{
    public class CreateLandlordReviewRequest
    {
        public string UserToId { get; set; }

        public int Rate { get; set; }

        public string Description { get; set; }

        public int FlatId { get; set; }

    }
}
