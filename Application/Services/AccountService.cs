﻿using Application.Dtos.Account.Requests;
using Application.Dtos.Account.Responses;
using Application.Infrastructure.Errors;
using Application.Interfaces;
using Domain.Models.Entities;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Utilities;
using Validation;
using Validation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Application.Services
{
    public class AccountService : Service, IAccountService
    {

        public AccountService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<ServiceResponse<GetAccountDetailsResponse>> GetAccountDetailsAsync()
        {
            if (CurrentlyLoggedUser == null)
                throw new RestException(HttpStatusCode.Unauthorized);

            var details = Mapper.Map<ApplicationUser, GetAccountDetailsResponse>(CurrentlyLoggedUser);
            var roles = await UserManager.GetRolesAsync(CurrentlyLoggedUser);

            details.Roles = roles.ToList();

            return new ServiceResponse<GetAccountDetailsResponse>(HttpStatusCode.OK, payload: details);
        }

        public async Task<ServiceResponse<UpdateAccountDetailsResponse>> UpdateAccountDetailsAsync(UpdateAccountDetailsRequest request)
        {
            if (CurrentlyLoggedUser == null)
                throw new RestException(HttpStatusCode.Unauthorized);

            Mapper.Map(request, CurrentlyLoggedUser);
            var result = await UserManager.UpdateAsync(CurrentlyLoggedUser);

            if (result.Succeeded)
            {
                var response = Mapper.Map<ApplicationUser, UpdateAccountDetailsResponse>(CurrentlyLoggedUser);
                var roles = await UserManager.GetRolesAsync(CurrentlyLoggedUser);
                response.Roles = roles.ToList();
                return new ServiceResponse<UpdateAccountDetailsResponse>(HttpStatusCode.OK, response);
            }

            var resultErrors = result.Errors.Select(e => e.Description);
            ErrorResultToReturn = new ErrorResult(Errors.AccountErrors.ErrorOccuredWhileUpdatingUser, resultErrors);

            throw new RestException(HttpStatusCode.BadRequest, ErrorResultToReturn);
        }

        public async Task<ServiceResponse> ConfirmEmailAsync(string userId, string confirmationCode)
        {
            var user = await GetEntityByIdAsync<ApplicationUser>(userId, HttpStatusCode.BadRequest);

            var result = await UserManager.ConfirmEmailAsync(user, confirmationCode);

            if (result.Succeeded)
                return new ServiceResponse(HttpStatusCode.OK);

            var resultErrors = result.Errors.Select(e => e.Description);
            ErrorResultToReturn = new ErrorResult(Errors.AccountErrors.ErrorOccuredWhileConfirmingEmail, resultErrors);

            throw new RestException(HttpStatusCode.BadRequest, ErrorResultToReturn);
        }

        public async Task<ServiceResponse> ChangePasswordAsync(ChangePasswordRequest request)
        {
            if (CurrentlyLoggedUser == null)
                throw new RestException(HttpStatusCode.Unauthorized);

            var changePasswordResult = await UserManager.ChangePasswordAsync(CurrentlyLoggedUser, request.CurrentPassword, request.NewPassword);
            if (changePasswordResult.Succeeded)
                return new ServiceResponse(HttpStatusCode.OK);

            var resultErrors = changePasswordResult.Errors.Select(e => e.Description);
            ErrorResultToReturn = new ErrorResult(Errors.AccountErrors.ErrorOccuredWhileChangingPassword, resultErrors);

            throw new RestException(HttpStatusCode.BadRequest, ErrorResultToReturn);
        }

        public async Task<ServiceResponse> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var user = await UserManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                ErrorResultToReturn = new ErrorResult(Errors.AccountErrors.CouldNotFindUserWithGivenEmail.SetParams(request.Email));
                throw new RestException(HttpStatusCode.NotFound, ErrorResultToReturn);
            }

            var passwordResetToken = await UserManager.GeneratePasswordResetTokenAsync(user);
            ServiceResponse emailServiceResponse = null;

            return emailServiceResponse;
        }

        public async Task<ServiceResponse> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await GetEntityByIdAsync<ApplicationUser>(request.UserId, HttpStatusCode.BadRequest);

            var result = await UserManager.ResetPasswordAsync(user, request.PasswordResetCode, request.NewPassword);

            if (result.Succeeded)
                return new ServiceResponse(HttpStatusCode.OK);

            var resultErrors = result.Errors.Select(e => e.Description);
            ErrorResultToReturn = new ErrorResult(Errors.AccountErrors.ErrorOccuredWhileResettingPassword, resultErrors);

            throw new RestException(HttpStatusCode.BadRequest, ErrorResultToReturn);
        }

        public async Task<ServiceResponse> ResendConfirmationEmailAsync(ResendConfirmationEmailRequest request)
        {
            var user = await UserManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                ErrorResultToReturn = new ErrorResult(Errors.AccountErrors.CouldNotFindUserWithGivenEmail.SetParams(request.Email));
                throw new RestException(HttpStatusCode.BadRequest, ErrorResultToReturn);
            }

            if (user.IsDeleted)
            {
                ErrorResultToReturn = new ErrorResult(Errors.AccountErrors.DeletedAccountCanNotBeConfirmed);
                throw new RestException(HttpStatusCode.BadRequest, ErrorResultToReturn);
            }

            if (user.EmailConfirmed)
            {
                ErrorResultToReturn = new ErrorResult(Errors.AccountErrors.EmailIsAlreadyConfirmed.SetParams(request.Email));
                throw new RestException(HttpStatusCode.BadRequest, ErrorResultToReturn);
            }

            var generatedEmailConfirmationToken = await UserManager.GenerateEmailConfirmationTokenAsync(user);

                return new ServiceResponse(HttpStatusCode.OK);
            

            ErrorResultToReturn = new ErrorResult(Errors.EmailErrors.ErrorOccuredWhileSendingEmailWithConfirmationLink.SetParams(request.Email));
            throw new RestException(HttpStatusCode.BadRequest, ErrorResultToReturn);
        }

        public async Task<ServiceResponse<GetUsersResponse>> GetUsersAsync(GetUsersRequest request)
        {
            bool isQueryIncluded = !string.IsNullOrWhiteSpace(request.Query);

            var dbQuery = Context.Users.Where(u => u.IsDeleted == false);

            if (isQueryIncluded)
            {
                string queryToLower = request.Query.ToLower();
                dbQuery = dbQuery.Where(u => u.Email.ToLower().Contains(queryToLower)
                                             || u.LastName.ToLower().Contains(queryToLower)
                                             || u.FirstName.ToLower().Contains(queryToLower)
                                             || u.SearchId.ToLower().Contains(queryToLower));
            }
            var totalNumberOfItems = await dbQuery.CountAsync();

            var users = await dbQuery.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

            var usersDto= Mapper.Map<List<ApplicationUser>, List<UserForGetUsersResponse>>(users);
            foreach(var userDto in usersDto)
            {
                var role = await Context.UserRoles.SingleOrDefaultAsync(ur => ur.UserId == userDto.Id);
                var roleName = await Context.Roles.SingleOrDefaultAsync(r => r.Id == role.RoleId);
                userDto.Role = roleName.Name;
            }

            var response = new GetUsersResponse(request, usersDto, totalNumberOfItems);
            return new ServiceResponse<GetUsersResponse>(HttpStatusCode.OK, response);
        }

        public async Task<ServiceResponse<GetUserDetailsResponse>> GetUserDetailsAsync(string userId)
        {
            var user = await GetEntityByIdAsync<ApplicationUser>(userId);

            if(user != null)
            {
                var userDto = Mapper.Map<ApplicationUser, GetUserDetailsResponse>(user);


                var role = await Context.UserRoles.SingleOrDefaultAsync(ur => ur.UserId == userDto.Id);
                var roleName = await Context.Roles.SingleOrDefaultAsync(r => r.Id == role.RoleId);
                userDto.Role = roleName.Name;
                return new ServiceResponse<GetUserDetailsResponse>(HttpStatusCode.OK, payload: userDto);
            }


            return new ServiceResponse<GetUserDetailsResponse>(HttpStatusCode.OK, payload: new GetUserDetailsResponse());
        }
    }
}