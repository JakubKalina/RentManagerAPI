using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Flat.Requests;
using Application.Dtos.Flat.Responses;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class FlatController : BaseController
    {
        private readonly IFlatService _flatService;

        public FlatController(IFlatService flatService)
        {
            _flatService = flatService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Produces(typeof(GetAdminFlatsResponse))]
        [Authorize(Roles = (Role.Administrator))]
        [HttpGet("admin")]
        public async Task<IActionResult> GetAdminFlats([FromQuery] GetAdminFlatsRequest request)
        {
            var response = await _flatService.GetAdminFlatsAsync(request);
            return SendResponse(response);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Produces(typeof(GetLandlordFlatsResponse))]
        [Authorize(Roles = (Role.Landlord))]
        [HttpGet("landlord")]
        public async Task<IActionResult> GetLandlordFlats([FromQuery] GetLandlordFlatsRequest request)
        {
            var response = await _flatService.GetLandlordFlatsAsync(request);
            return SendResponse(response);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Produces(typeof(GetTenantFlatsResponse))]
        [Authorize(Roles = (Role.Tenant))]
        [HttpGet("tenant")]
        public async Task<IActionResult> GetTenantFlats([FromQuery] GetTenantFlatsRequest request)
        {
            var response = await _flatService.GetTenantFlatsAsync(request);
            return SendResponse(response);
        }


        /// <summary>
        /// Zwraca informacje szczegółowe na temat wybranego mieszkania
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Produces(typeof(GetFlatResponse))]
        [Authorize(Roles = (Role.Landlord))]
        [HttpGet("{flatId}")]
        public async Task<IActionResult> GetFlat([FromRoute] int flatId)
        {
            var response = await _flatService.GetFlatAsync(flatId);
            return SendResponse(response);
        }

        /// <summary>
        /// Tworzy nowe mieszkanie
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = (Role.Landlord))]
        public async Task<IActionResult> CreateFlat([FromBody] CreateFlatRequest request)
        {
            var response = await _flatService.CreateFlatAsync(request);
            return SendResponse(response);
        }

        /// <summary>
        /// Edytuje istniejące mieszkanie
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = (Role.Landlord))]
        public async Task<IActionResult> UpdateFlat([FromBody] UpdateFlatRequest request)
        {
            var response = await _flatService.UpdateFlatAsync(request);
            return SendResponse(response);
        }

        /// <summary>
        /// Usuwa wybrane mieszkanie
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{flatId}")]
        [Authorize(Roles = (Role.Landlord))]
        public async Task<IActionResult> DeleteFlat([FromRoute] int flatId)
        {
            var response = await _flatService.DeleteFlatAsync(flatId);
            return SendResponse(response);
        }
    }
}
