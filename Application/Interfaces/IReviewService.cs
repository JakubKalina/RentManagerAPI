﻿using Application.Dtos.Review.Requests;
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
        Task<ServiceResponse<GetUserReviewsResponse>> GetUserReviewsAsync(string userId);

        /// <summary>
        /// Dodaje nową opinię na temat zarządcy - dodaje ją najemca
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> CreateLandlordReviewAsync(CreateLandlordReviewRequest request);

        /// <summary>
        /// Dodaje nową opinię na temat najemcy - dodaje ją zarządca
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> CreateTenantReviewAsync(CreateTenantReviewRequest request);

    }
}
