﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Infrastructure.Errors;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Validation;
using Validation.Models;

namespace Application.Utilities
{
    public static class UserCreator
    {

        public static async Task CreateUserAsync(UserManager<ApplicationUser> userManager, ApplicationUser userToCreate, string password,
            List<string> requestRoles)
        {
            await CheckIfEmailIsTaken(userManager, userToCreate.Email);

            var accountCreationResult = await userManager.CreateAsync(userToCreate, password);
            if (!accountCreationResult.Succeeded)
                throw new RestException(HttpStatusCode.BadRequest, new ErrorResult(Errors.AccountErrors.ErrorOccuredWhileCreatingUser, accountCreationResult.Errors.Select(e => e.Description)));

            var addToRolesResult = await userManager.AddToRolesAsync(userToCreate, requestRoles);
            if (!addToRolesResult.Succeeded)
                throw new RestException(HttpStatusCode.BadRequest, new ErrorResult(Errors.AccountErrors.ErrorOccuredWhileCreatingUser, addToRolesResult.Errors.Select(e => e.Description)));
        }

        private static async Task CheckIfEmailIsTaken(UserManager<ApplicationUser> userManager, string email)
        {
            var emailTaken = await userManager.FindByEmailAsync(email) != null;
            if (emailTaken)
                throw new RestException(HttpStatusCode.BadRequest, new ErrorResult(Errors.UserCreatorErrors.EmailIsAlreadyTaken.SetParams(email)));
        }
    }
}