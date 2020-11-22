using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Payment.Requests;
using Application.Dtos.Payment.Responses;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }


        [Produces(typeof(GetTenantPaymentsResponse))]
        [Authorize(Roles = (Role.Tenant))]
        [HttpGet]
        public async Task<IActionResult> GetTenantPayments()
        {
            var response = await _paymentService.GetTenantPaymentsAsync();
            return SendResponse(response);
        }

        [Produces(typeof(GetFlatPaymentsResponse))]
        [Authorize(Roles = (Role.Landlord))]
        [HttpGet("{flatId}")]
        public async Task<IActionResult> GetFlatPayments([FromRoute] int flatId)
        {
            var response = await _paymentService.GetFlatPaymentsAsync(flatId);
            return SendResponse(response);
        }

        [Authorize(Roles = (Role.Landlord))]
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest request)
        {
            var response = await _paymentService.CreatePaymentAsync(request);
            return SendResponse(response);
        }

        [Authorize(Roles = (Role.Landlord))]
        [HttpPut]
        public async Task<IActionResult> UpdatePayment([FromBody] UpdatePaymentRequest request)
        {
            var response = await _paymentService.UpdatePaymentAsync(request);
            return SendResponse(response);
        }


    }
}
