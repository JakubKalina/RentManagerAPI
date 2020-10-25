using Application.Dtos.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dtos.Review.Requests
{
    public class GetUserReviewsRequest : PaginationQuery
    {
        [Required]
        public string UserId { get; set; }
    }
}
