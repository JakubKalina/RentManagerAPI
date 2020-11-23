using Application.Dtos.Payment.Requests;
using Application.Dtos.Payment.Responses;
using Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPaymentService
    {

        /// <summary>
        /// Zwraca wszystkie płatności które powinien dokonać najemca dla jego wszystkich mieszkań
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse<IList<GetTenantPaymentsResponse>>> GetTenantPaymentsAsync();


        /// <summary>
        /// Zwraca wszystkie aktualne płatności dla najemców wybranego mieszkania
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse<IList<GetFlatPaymentsResponse>>> GetFlatPaymentsAsync(int flatId);


        /// <summary>
        /// Dodanie nowej płatności
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> CreatePaymentAsync(CreatePaymentRequest request);


        /// <summary>
        /// Aktualizacja istniejącej płatności
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> UpdatePaymentAsync(UpdatePaymentRequest request);


        /// <summary>
        /// Usunięcie istniejącej płatności
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> DeletePaymentAsync(int paymentId);

    }
}
