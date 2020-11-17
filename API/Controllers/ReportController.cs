using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Report.Requests;
using Application.Dtos.Report.Responses;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ReportController : BaseController
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [Produces(typeof(GetReportsResponse))]
        [Authorize(Roles = (Role.Landlord))]
        [HttpGet]
        public async Task<IActionResult> GetReports([FromQuery] GetReportsRequest request)
        {
            var response = await _reportService.GetReportsAsync(request);
            return SendResponse(response);
        }

        [Authorize(Roles = (Role.Landlord))]
        [HttpPost]
        public async Task<IActionResult> CreateReport(CreateReportRequest request)
        {
            var response = await _reportService.CreateReportAsync(request);
            return SendResponse(response);
        }

        [Authorize(Roles = (Role.Landlord))]
        [HttpDelete("{reportId}")]
        public async Task<IActionResult> DeleteReport([FromQuery] int reportId)
        {
            var response = await _reportService.DeleteReportAsync(reportId);
            return SendResponse(response);
        }

        [Authorize(Roles = (Role.Landlord))]
        [HttpPut]
        public async Task<IActionResult> UpdateReport(UpdateReportRequest request)
        {
            var response = await _reportService.UpdateReportAsync(request);
            return SendResponse(response);
        }
    }
}
