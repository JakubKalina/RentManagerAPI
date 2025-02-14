﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Review.Requests;
using Application.Dtos.Review.Responses;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = (Role.Landlord + "," + Role.Tenant + "," + Role.Administrator))]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserReviews([FromRoute] string userId)
        {
            var response = await _reviewService.GetUserReviewsAsync(userId);
            return SendResponse(response);
        }


        [Authorize(Roles = (Role.Landlord))]
        [HttpPost("landlord")]
        public async Task<IActionResult> CreateTenantReview([FromBody] CreateTenantReviewRequest request)
        {
            var response = await _reviewService.CreateTenantReviewAsync(request);
            return SendResponse(response);
        }

        [Authorize(Roles = (Role.Tenant))]
        [HttpPost("tenant")]
        public async Task<IActionResult> CreateLandlordReview([FromBody] CreateLandlordReviewRequest request)
        {
            var response = await _reviewService.CreateLandlordReviewAsync(request);
            return SendResponse(response);
        }


    }
}
