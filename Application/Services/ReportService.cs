using Application.Dtos.Report.Requests;
using Application.Dtos.Report.Responses;
using Application.Infrastructure.Errors;
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

        public async Task<ServiceResponse> CreateLandlordReportAsync(CreateLandlordReportRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;
            var user = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flat = await GetEntityByIdAsync<Flat>(request.FlatId);
            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == userId && fl.FlatId == flat.Id).SingleOrDefaultAsync();

            if (flatLandlord != null)
            {
                var report = new Report()
                {
                    Title = request.Title,
                    Description = request.Description,
                    CreatedAt = DateTime.Now,
                    Type = request.Type,
                    Flat = flat,
                    Sender = user
                };
                Context.Reports.Add(report);

                await SaveChangesAsync(new[] { $"Wystąpił błąd podczas dodawania nowego raportu" });
                return new ServiceResponse(HttpStatusCode.OK);
            }
            else
            {
                throw new RestException(HttpStatusCode.BadRequest);
            }
        }

        public async Task<ServiceResponse> CreateTenantReportAsync(CreateTenantReportRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> DeleteReportAsync(int reportId)
        {
            var report = await GetEntityByIdAsync<Report>(reportId);

            string userId = CurrentlyLoggedUser.Id;
            var user = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flat = await GetEntityByIdAsync<Flat>(report.FlatId);
            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == userId && fl.FlatId == flat.Id).SingleOrDefaultAsync();

            if (flatLandlord != null) // Jeśli osoba wysyłająca zapytanie jest zarządcą mieszkania
            {
                Context.Reports.Remove(report);
                await SaveChangesAsync(new[] { $"Wystąpił błąd podczas usuwania raportu" });
                return new ServiceResponse(HttpStatusCode.OK);
            }
            else if(report.SenderId == user.Id) // Jeśli osoba wysyłająca zapytanie dodała tą notatkę informacyjną
            {
                Context.Reports.Remove(report);
                await SaveChangesAsync(new[] { $"Wystąpił błąd podczas usuwania raportu" });
                return new ServiceResponse(HttpStatusCode.OK);
            }
            else
            {
                throw new RestException(HttpStatusCode.BadRequest);
            }
        }


        public async Task<ServiceResponse<GetFlatReportsResponse>> GetFlatReportsAsync(GetFlatReportsRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;
            var user = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flat = await GetEntityByIdAsync<Flat>(request.FlatId);
            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == userId && fl.FlatId == flat.Id).SingleOrDefaultAsync();

            IQueryable<Report> dbQuery;
            List<Report> reports;
            List<ReportForGetFlatReportsResponse> reportsDto = new List<ReportForGetFlatReportsResponse>();

            int totalNumberOfItems = 0;
            if (flatLandlord != null)
            {

                dbQuery = Context.Reports.Where(r => r.FlatId == request.FlatId);
              
                totalNumberOfItems = await dbQuery.CountAsync();
                reports = await dbQuery.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

                foreach(var report in reports)
                {
                    var createdByUser = await GetEntityByIdAsync<ApplicationUser>(report.SenderId);
                    var reportDto = Mapper.Map<Report, ReportForGetFlatReportsResponse>(report);
                    reportDto.SenderFirstName = createdByUser.FirstName;
                    reportDto.SenderLastName = createdByUser.LastName;
                    reportsDto.Add(reportDto);
                }
            }
            var response = new GetFlatReportsResponse(request, reportsDto, totalNumberOfItems);
            response.FlatId = flat.Id;
            return new ServiceResponse<GetFlatReportsResponse>(HttpStatusCode.OK, response);
        }

        public async Task<ServiceResponse<GetReportsResponse>> GetReportsAsync(GetReportsRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;
            var user = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flatLandlordIds = await Context.FlatLandlords.Where(fl => fl.UserId == userId).Select(fl => fl.FlatId).ToListAsync();

            IQueryable<Report> dbQuery;
            List<Report> reports;
            List<ReportForGetReportsResponse> reportsDto = new List<ReportForGetReportsResponse>();

            int totalNumberOfItems = 0;
            if (flatLandlordIds.Count > 0)
            {

                dbQuery = Context.Reports.Where(r => flatLandlordIds.Contains(r.FlatId));

                totalNumberOfItems = await dbQuery.CountAsync();
                reports = await dbQuery.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

                foreach (var report in reports)
                {
                    var createdByUser = await GetEntityByIdAsync<ApplicationUser>(report.SenderId);
                    var flat = await GetEntityByIdAsync<Flat>(report.FlatId);
                    var reportDto = Mapper.Map<Report, ReportForGetReportsResponse>(report);
                    reportDto.FlatDescription = flat.Description;
                    reportDto.SenderFirstName = createdByUser.FirstName;
                    reportDto.SenderLastName = createdByUser.LastName;
                    reportsDto.Add(reportDto);
                }
            }
            var response = new GetReportsResponse(request, reportsDto, totalNumberOfItems);
            return new ServiceResponse<GetReportsResponse>(HttpStatusCode.OK, response);
        }

        //public async Task<ServiceResponse> UpdateReportAsync(UpdateReportRequest request)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
