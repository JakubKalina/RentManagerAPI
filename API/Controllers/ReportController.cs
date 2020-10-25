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
    }
}
