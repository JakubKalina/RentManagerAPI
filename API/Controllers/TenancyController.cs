using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Tenancy.Requests;
using Application.Dtos.Tenancy.Responses;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class TenancyController : BaseController
    {
        private readonly ITenancyService _tenancyService;

        public TenancyController(ITenancyService tenancyService)
        {
            _tenancyService = tenancyService;
        }

        [Produces(typeof(GetFlatTenanciesResponse))]
        [Authorize(Roles = (Role.Landlord))]
        [HttpGet("flat/{flatId}")]
        public async Task<IActionResult> GetFlatTenancies([FromRoute] int flatId)
        {
            var response = await _tenancyService.GetFlatTenanciesAsync(flatId);
            return SendResponse(response);
        }

        [Produces(typeof(GetFlatTenancyResponse))]
        [Authorize(Roles = (Role.Landlord))]
        [HttpGet("{tenancyId}")]

        public async Task<IActionResult> GetTenancy([FromRoute] int tenancyId)
        {
            var response = await _tenancyService.GetFlatTenancyAsync(tenancyId);
            return SendResponse(response);
        }

        [Produces(typeof(GetUserTenanciesResponse))]
        [Authorize(Roles = (Role.Tenant))]
        [HttpGet("user")]
        public async Task<IActionResult> GetUserTenancies()
        {
            var response = await _tenancyService.GetUserTenanciesAsync();
            return SendResponse(response);

        }

        [Authorize(Roles = (Role.Landlord))]
        [HttpPost]
        public async Task<IActionResult> BeginTenancy([FromBody]BeginTenancyRequest request)
        {
            var response = await _tenancyService.BeginTenancy(request);
            return SendResponse(response);

        }

        [Authorize(Roles = (Role.Landlord))]
        [HttpPut]
        public async Task<IActionResult> UpdateTenancy([FromBody]UpdateTenancyRequest request)
        {
            var response = await _tenancyService.UpdateTenancy(request);
            return SendResponse(response);

        }




    }
}
