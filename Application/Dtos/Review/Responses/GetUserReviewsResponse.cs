using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Review.Responses
{
    public class GetUserReviewsResponse : PagedResponse<ReviewForGetUserReviewsResponse>
    {
        public GetUserReviewsResponse(PaginationQuery request, IEnumerable<ReviewForGetUserReviewsResponse> data, int totalNumberOfItems) : base(request, data, totalNumberOfItems)
        {

        }
    }

    public class ReviewForGetUserReviewsResponse
    {
        public int Rate { get; set; }
        public string Description { get; set; }
    }
}
