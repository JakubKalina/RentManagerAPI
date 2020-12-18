using Application.Interfaces;
using AutoMapper;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.Infrastructure.Errors;
using Domain.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Validation;
using Validation.Models;

namespace Application.Services
{
    public class Service
    {
        protected IMapper Mapper { get; }
        protected DataContext Context { get; }
        protected UserManager<ApplicationUser> UserManager { get; }
        protected ErrorResult ErrorResultToReturn { get; set; }

        protected string CurrentlyLoggedUserName { get; }

        protected ApplicationUser CurrentlyLoggedUser { get; set; }

        public Service(IServiceProvider serviceProvider)
        {
            var userAccessor = serviceProvider.GetService<IUserAccessor>();
            CurrentlyLoggedUserName = userAccessor.GetCurrentUsername();

            Context = serviceProvider.GetService<DataContext>();
            Mapper = serviceProvider.GetService<IMapper>();
            UserManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            AssignCurrentlyLoggedUser();
        }

        public async Task<TEntity> GetEntityByIdAsync<TEntity>(Guid id, HttpStatusCode codeOnEntityNotFound = HttpStatusCode.NotFound) where TEntity : class, IHasGuidId
        {
            if (id == Guid.Empty)
            {
                ErrorResultToReturn = new ErrorResult(Errors.DatabaseErrors.InvalidResourceIdentifier, $"Nieprawidłowy id dla {typeof(TEntity).Name}");
                throw new RestException(HttpStatusCode.BadRequest, ErrorResultToReturn);
            }

            var entity = await Context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                ErrorResultToReturn = new ErrorResult(Errors.DatabaseErrors.InvalidResourceIdentifier,
                    $"Nie znaleziono {typeof(TEntity).Name} o podanym id");
                throw new RestException(codeOnEntityNotFound, ErrorResultToReturn);
            }

            return entity;
        }

        public async Task<TEntity> GetEntityByIdAsync<TEntity>(int id, HttpStatusCode codeOnEntityNotFound = HttpStatusCode.NotFound) where TEntity : class, IHasIntId
        {
            var entity = await Context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                ErrorResultToReturn = new ErrorResult(Errors.DatabaseErrors.InvalidResourceIdentifier,
                    $"Nie znaleziono {typeof(TEntity).Name} o podanym id");
                throw new RestException(codeOnEntityNotFound, ErrorResultToReturn);
            }
            return entity;
        }

        public async Task<TEntity> GetEntityByIdAsync<TEntity>(string id, HttpStatusCode codeOnEntityNotFound = HttpStatusCode.NotFound) where TEntity : class, IHasStringId
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                ErrorResultToReturn = new ErrorResult(Errors.DatabaseErrors.InvalidResourceIdentifier, $"Nieprawidłowy id dla {typeof(TEntity).Name}");
                throw new RestException(HttpStatusCode.BadRequest, ErrorResultToReturn);
            }

            var entity = await Context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                ErrorResultToReturn = new ErrorResult(Errors.DatabaseErrors.InvalidResourceIdentifier,
                    $"Nie znaleziono {typeof(TEntity).Name} o podanym id");
                throw new RestException(codeOnEntityNotFound, ErrorResultToReturn);
            }

            return entity;
        }

        public async Task SaveChangesAsync(IEnumerable<string> errorMessages)
        {
            if (await Context.SaveChangesAsync() <= 0)
                throw new RestException(HttpStatusCode.InternalServerError, new ErrorResult(errorMessages));
        }

        public async Task SaveChangesAsync()
        {
            if (await Context.SaveChangesAsync() <= 0)
                throw new RestException(HttpStatusCode.InternalServerError, new ErrorResult(Errors.DatabaseErrors.ErrorOccuredWhileSaving));
        }


        private void AssignCurrentlyLoggedUser()
        {
            if (CurrentlyLoggedUserName == null)
            {
                CurrentlyLoggedUser = null;
                return;
            }
            CurrentlyLoggedUser = UserManager.FindByNameAsync(CurrentlyLoggedUserName).Result;
        }
    }
}