using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Review.Responses
{
    public class GetUserReviewsResponse
    {
        public IEnumerable<ReviewForGetUserReviewsResponse> Data { get; set; }
    }

    public class ReviewForGetUserReviewsResponse
    {
        public int Rate { get; set; }
        public string Description { get; set; }
    }
}
