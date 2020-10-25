using Application.Dtos.Report.Requests;
using Application.Dtos.Report.Responses;
using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
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
    public class ReportService : Service, IReportService
    {
        public ReportService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<ServiceResponse<GetReportsResponse>> GetReportsAsync(GetReportsRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;
            var user = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flat = await GetEntityByIdAsync<Flat>(request.FlatId);
            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == userId && fl.FlatId == flat.Id).SingleOrDefaultAsync();

            IQueryable<Report> dbQuery;
            List<Report> reports;
            List<ReportForGetReportsResponse> reportsDto = new List<ReportForGetReportsResponse>();

            int totalNumberOfItems = 0;
            if (flatLandlord != null)
            {
                if(request.IsArchived == true)
                {
                    dbQuery = Context.Reports.Where(r => r.FlatId == request.FlatId && r.Status == "Archived");
                }
                else
                {
                    dbQuery = Context.Reports.Where(r => r.FlatId == request.FlatId && r.Status == "Pending");
                }
                totalNumberOfItems = await dbQuery.CountAsync();
                reports = await dbQuery.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

                reportsDto = Mapper.Map<IEnumerable<Report>, IEnumerable<ReportForGetReportsResponse>>(reports).ToList();
            }

            var response = new GetReportsResponse(request, reportsDto, totalNumberOfItems);

            return new ServiceResponse<GetReportsResponse>(HttpStatusCode.OK, response);

        }
    }
}
