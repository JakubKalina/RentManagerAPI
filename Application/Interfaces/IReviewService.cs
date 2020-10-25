using Application.Dtos.Review.Requests;
using Application.Dtos.Review.Responses;
using Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReviewService
    {
        /// <summary>
        /// Zwraca wszystkie opinie na temat wybranego użytkownika
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse<GetUserReviewsResponse>> GetUserReviewsAsync(GetUserReviewsRequest request);

        /// <summary>
        /// Dodaje nową opinie o użytkowniku jeśli ten jest upoważniony do jej dodania
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> CreateUserReviewAsync(CreateUserReviewRequest request);
    }
}
