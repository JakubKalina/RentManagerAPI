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
        /// Zwraca wszystkie raporty dla wybranego mieszkania
        /// Posiada flagę określającą czy mają to być raporty aktualne czy archiwizowane
        /// </summary>
        /// <param name="flatId"></param>
        /// <param name="isArchived"></param>
        /// <returns></returns>
        Task<ServiceResponse<GetReportsResponse>> GetReportsAsync(GetReportsRequest request);

        /// <summary>
        /// Tworzy nowy raport przypsisany do mieszkania
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> CreateReportAsync(CreateReportRequest request);

        /// <summary>
        /// Edytuje istniejący raport przypisany do mieszkania
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> UpdateReportAsync(UpdateReportRequest request);

        /// <summary>
        /// Usuwa wybrany raport przypisany do mieszkania
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        Task<ServiceResponse> DeleteReportAsync(int reportId);
    }
}
