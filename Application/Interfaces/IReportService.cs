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
    }
}
