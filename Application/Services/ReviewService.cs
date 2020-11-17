using Application.Dtos.Review.Requests;
using Application.Dtos.Review.Responses;
using Application.Infrastructure.Errors;
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

        /// <summary>
        /// Najemca dodaje opinie o zarządcy
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> CreateLandlordReviewAsync(CreateLandlordReviewRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            var tenant = await GetEntityByIdAsync<ApplicationUser>(userId);

            var tenancy = await Context.Tenancies.SingleOrDefaultAsync(t => t.FlatId == request.FlatId && t.UserId == tenant.Id);

            if(tenancy != null)
            {
                var currentReview = await Context.Reviews.SingleOrDefaultAsync(r => r.UserFromId == userId && r.UserToId == request.UserToId);
                if(currentReview == null)
                {
                    var userTo = await GetEntityByIdAsync<ApplicationUser>(request.UserToId);
                    var review = new Review()
                    {
                        Rate = request.Rate,
                        Description = request.Description,
                        UserFrom = tenant,
                        UserTo = userTo
                    };
                    Context.Reviews.Add(review);

                    await SaveChangesAsync(new[] { $"Wystąpił błąd podczas dodawania nowej opinii" });
                    return new ServiceResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new RestException(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                throw new RestException(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Zarządca dodaje opinie o najemcy
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> CreateTenantReviewAsync(CreateTenantReviewRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            var landlord = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == landlord.Id && fl.FlatId == request.FlatId).SingleOrDefaultAsync();

            if(flatLandlord != null)
            {
                var currentReview = await Context.Reviews.SingleOrDefaultAsync(r => r.UserFromId == userId && r.UserToId == request.UserToId);
                
                // Jeśli nie oceniono jeszcze wskazanego użytkownika
                if(currentReview == null)
                {
                    var userTo = await GetEntityByIdAsync<ApplicationUser>(request.UserToId);
                    var review = new Review()
                    {
                        Rate = request.Rate,
                        Description = request.Description,
                        UserFrom = landlord,
                        UserTo = userTo
                    };
                    Context.Reviews.Add(review);

                    await SaveChangesAsync(new[] { $"Wystąpił błąd podczas dodawania nowej opinii" });
                    return new ServiceResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new RestException(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                throw new RestException(HttpStatusCode.BadRequest);
            }
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
