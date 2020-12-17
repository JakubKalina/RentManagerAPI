using Application.Dtos.Report.Requests;
using Application.Dtos.Report.Responses;
using Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReportService
    {
        /// <summary>
        /// Zwraca wszystkie raporty dla wszystkich mieszkań zarządcy oraz wszystkich mieszkań najemcy
        /// Posiada flagę określającą czy mają to być raporty aktualne czy archiwizowane
        /// </summary>
        /// <param name="flatId"></param>
        /// <param name="isArchived"></param>
        /// <returns></returns>
        Task<ServiceResponse<GetReportsResponse>> GetReportsAsync(GetReportsRequest request);


        /// <summary>
        /// Zwraca wszystkie raporty dla wybranego mieszkania
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse<GetFlatReportsResponse>> GetFlatReportsAsync(GetFlatReportsRequest request);

        /// <summary>
        /// Tworzy nowy raport przypsisany do mieszkania - tworzony przez zarządcę
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> CreateLandlordReportAsync(CreateLandlordReportRequest request);

        /// <summary>
        /// Tworzy nowy raport przypsisany do mieszkania - tworzony przez najemcę
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> CreateTenantReportAsync(CreateTenantReportRequest request);

        /// <summary>
        /// Edytuje istniejący raport przypisany do mieszkania
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //Task<ServiceResponse> UpdateReportAsync(UpdateReportRequest request);

        /// <summary>
        /// Usuwa wybrany raport przypisany do mieszkania
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        Task<ServiceResponse> DeleteReportAsync(int reportId);
    }
}
