﻿using Application.Dtos.Flat.Requests;
using Application.Dtos.Flat.Responses;
using Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFlatService
    {
        /// <summary>
        /// Zwraca wszystkie mieszkania
        /// W zależności od roli użytkownika zwraca
        /// Admin - wszystkie mieszkania
        /// Landlord - wszystkie mieszkania którymi zarządza
        /// Tenant - wszystkie mieszkania do których jest przypisany
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse<GetFlatsResponse>> GetFlatsAsync(GetFlatsRequest request);

        /// <summary>
        /// Tworzy nowe mieszkanie i przypisuje osobę tworzącą jako zarządcę
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> CreateFlatAsync(CreateFlatRequest request);

        /// <summary>
        /// Dokonuje aktualizacji mieszkania
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> UpdateFlatAsync(UpdateFlatRequest request);

        /// <summary>
        /// Usuwa mieszkanie o wskazanym Id
        /// </summary>
        /// <param name="flatId"></param>
        /// <returns></returns>
        Task<ServiceResponse> DeleteFlatAsync(int flatId);
    }
}
