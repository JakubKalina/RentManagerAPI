using Application.Dtos.Tenancy.Requests;
using Application.Dtos.Tenancy.Responses;
using Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITenancyService
    {
        /// <summary>
        /// Zwraca wszystkie aktualne najmy dla wybranego mieszkania
        /// Dostępne dla właściciela, zarządcy
        /// </summary>
        /// <param name="flatId"></param>
        /// <returns></returns>
        Task<ServiceResponse<IList<GetFlatTenanciesResponse>>> GetFlatTenanciesAsync(int flatId);

        /// <summary>
        /// Zwraca najem po jego id
        /// </summary>
        /// <param name="tenancyId"></param>
        /// <returns></returns>
        Task<ServiceResponse<GetFlatTenancyResponse>> GetFlatTenancyAsync(int tenancyId);

        /// <summary>
        /// Zwraca wszystkie aktualne najmy jakie posiada zalogowany użytkownik
        /// Dostępne dla najemców
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<IList<GetUserTenanciesResponse>>> GetUserTenanciesAsync();

        /// <summary>
        /// Rozpoczyna najem dla danego mieszkania
        /// Dostępne dla własciciela, zarządcy
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> BeginTenancy(BeginTenancyRequest request);

        /// <summary>
        /// Dokonuje edycji najmu dla danego mieszkania
        /// Dostęp dla właściciela, zarządcy
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> UpdateTenancy(UpdateTenancyRequest request);
    }
}
