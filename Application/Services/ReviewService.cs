using Application.Dtos.Review.Requests;
using Application.Dtos.Review.Responses;
using Application.Interfaces;
using Application.Utilities;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ReviewService : Service, IReviewService
    {
        public ReviewService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<ServiceResponse> CreateUserReviewAsync(CreateUserReviewRequest request)
        {
            throw new NotImplementedException(); //TODO: Implementacja

        }

        public async Task<ServiceResponse<GetUserReviewsResponse>> GetUserReviewsAsync(GetUserReviewsRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            // Jeśli nie podano użytkownika to zwróć opinie dla użytkownika zalogowanego
            if (request.UserId == null)
                request.UserId = userId;

            var dbQuery = Context.Reviews.Where(r => r.UserToId == request.UserId);

            var totalNumberOfItems = await dbQuery.CountAsync();
            var reviews = await dbQuery.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

            var reviewsDto = Mapper.Map<IEnumerable<Review>, IEnumerable<ReviewForGetUserReviewsResponse>>(reviews).ToList();

            var response = new GetUserReviewsResponse(request, reviewsDto, totalNumberOfItems);

            return new ServiceResponse<GetUserReviewsResponse>(HttpStatusCode.OK, response);
        }
    }
}
