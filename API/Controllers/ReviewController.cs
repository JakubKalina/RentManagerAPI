using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Review.Requests;
using Application.Dtos.Review.Responses;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [Produces(typeof(GetUserReviewsResponse))]
        [HttpGet]
        public async Task<IActionResult> GetUserReviews([FromQuery] GetUserReviewsRequest request)
        {
            var response = await _reviewService.GetUserReviewsAsync(request);
            return SendResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserReview([FromQuery] CreateUserReviewRequest request)
        {
            var response = await _reviewService.CreateUserReviewAsync(request);
            return SendResponse(response);
        }

    }
}
