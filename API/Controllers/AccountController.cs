using API.Utilities;
using Application.Dtos.Account.Requests;
using Application.Dtos.Account.Responses;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [Produces(typeof(Response<GetAccountDetailsResponse>))]
        [HttpGet("details")]
        public async Task<IActionResult> GetAccountDetails()
        {
            var response = await _accountService.GetAccountDetailsAsync();
            return SendResponse(response);
        }


        [Produces(typeof(Response<GetUserDetailsResponse>))]
        [HttpGet("details/{userId}")]
        public async Task<IActionResult> GetUserDetails([FromRoute] string userId)
        {
            var response = await _accountService.GetUserDetailsAsync(userId);
            return SendResponse(response);
        }



        [Produces(typeof(Response<UpdateAccountDetailsResponse>))]
        [HttpPut("details")]
        public async Task<IActionResult> UpdateAccountDetails([FromBody] UpdateAccountDetailsRequest request)
        {
            var response = await _accountService.UpdateAccountDetailsAsync(request);
            return SendResponse(response);
        }


        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var response = await _accountService.ChangePasswordAsync(request);
            return SendResponse(response);
        }


        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            var response = await _accountService.GetUsersAsync(request);
            return SendResponse(response);
        }
    }
}