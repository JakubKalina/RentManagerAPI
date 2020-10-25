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
        /// Zwraca wszyskie mieszkania w zależności od roli
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Produces(typeof(GetFlatsResponse))]
        [Authorize(Roles = (Role.Administrator + "," + Role.Tenant + "," + Role.Landlord) )]
        [HttpGet]
        public async Task<IActionResult> GetFlats([FromQuery] GetFlatsRequest request)
        {
            var response = await _flatService.GetFlatsAsync(request);
            return SendResponse(response);
        }

        /// <summary>
        /// Zwraca informacje szczegółowe na temat wybranego mieszkania
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Produces(typeof(GetFlatResponse))]
        [Authorize(Roles = (Role.Administrator + "," + Role.Tenant + "," + Role.Landlord))]
        [HttpGet("{flatId}")]
        public async Task<IActionResult> GetFlat([FromQuery] int flatId)
        {
            throw new NotImplementedException();
            //var response = await _flatService.GetFlatAsync(flatId);
            //return SendResponse(response);
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
        [Authorize(Roles = (Role.Administrator + "," + Role.Landlord))]
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
        [Authorize(Roles = (Role.Administrator + "," + Role.Landlord))]
        public async Task<IActionResult> DeleteFlat([FromRoute] int flatId)
        {
            var response = await _flatService.DeleteFlatAsync(flatId);
            return SendResponse(response);
        }
    }
}
