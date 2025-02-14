﻿using Application.Dtos.Payment.Requests;
using Application.Dtos.Payment.Responses;
using Application.Infrastructure.Errors;
using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PaymentService : Service, IPaymentService
    {
        public PaymentService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<ServiceResponse> CreatePaymentAsync(CreatePaymentRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            var landlord = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == landlord.Id && fl.FlatId == request.FlatId).SingleOrDefaultAsync();

            if(flatLandlord != null)
            {
                var flat = await GetEntityByIdAsync<Flat>(request.FlatId);
                var user = await GetEntityByIdAsync<ApplicationUser>(request.UserId);
                var room = await Context.Rooms.SingleOrDefaultAsync(r => r.Id == request.RoomId);
                var userRoles = await UserManager.GetRolesAsync(user);

                var tenancies = new List<Tenancy>();
                if(room == null)
                {
                    tenancies = await Context.Tenancies.Where(t => t.EndDate > DateTime.Now && t.FlatId == flat.Id && t.UserId == user.Id).ToListAsync();
                }
                else
                {
                    tenancies = await Context.Tenancies.Where(t => t.EndDate > DateTime.Now && t.FlatId == flat.Id && t.UserId == user.Id && t.RoomId == room.Id).ToListAsync();
                }

                // Możemy dodać opłate tylko dla najemcy
                if (userRoles.Contains(Role.Tenant) && tenancies.Count > 0)
                {
                    var payment = new Payment()
                    {
                        Title = request.Title,
                        Description = request.Description,
                        Amount = request.Amount,
                        CreatedAt = DateTime.Now,
                        DueDate = request.DueDate,
                        IsPaid = false,
                        RecipientAccountNumber = request.RecipientAccountNumber,
                        Flat = flat,
                        Room = room,
                        User = user
                    };

                    Context.Payments.Add(payment);

                    await SaveChangesAsync(new[] { $"Wystąpił błąd podczas dodawania nowej opłaty" });
                    return new ServiceResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new RestException(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                throw new RestException(HttpStatusCode.BadRequest);
            }
        }

        public async Task<ServiceResponse> DeletePaymentAsync(int paymentId)
        {
            string userId = CurrentlyLoggedUser.Id;

            var landlord = await GetEntityByIdAsync<ApplicationUser>(userId);

            var payment = await Context.Payments.SingleOrDefaultAsync(p => p.Id == paymentId);
            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == landlord.Id && fl.FlatId == payment.FlatId).SingleOrDefaultAsync();

            if (flatLandlord != null)
            {
                Context.Payments.Remove(payment);
                await SaveChangesAsync(new[] { $"Wystąpił błąd podczas usuwania opłaty" });
                return new ServiceResponse(HttpStatusCode.OK);
            }
            else
            {
                throw new RestException(HttpStatusCode.BadRequest);
            }
        }

        public async Task<ServiceResponse<IList<GetFlatPaymentsResponse>>> GetFlatPaymentsAsync(int flatId)
        {
            string userId = CurrentlyLoggedUser.Id;

            var landlord = await GetEntityByIdAsync<ApplicationUser>(userId);

            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == landlord.Id && fl.FlatId == flatId).SingleOrDefaultAsync();

            IList<GetFlatPaymentsResponse> response = new List<GetFlatPaymentsResponse>();
            // Jeżeli zalogowana osoba jest zarządcą
            if (flatLandlord != null)
            {
                var payments = await Context.Payments.Where(p => p.FlatId == flatId && p.IsPaid == false).ToListAsync();

                var paymentsDto = Mapper.Map<IList<Payment>, IList<GetFlatPaymentsResponse>>(payments);
                response = paymentsDto;
            }

            return new ServiceResponse<IList<GetFlatPaymentsResponse>>(HttpStatusCode.OK, response);
        }

        public async Task<ServiceResponse<IList<GetTenantPaymentsResponse>>> GetTenantPaymentsAsync()
        {
            string userId = CurrentlyLoggedUser.Id;

            var tenancies = await Context.Tenancies.Where(t => t.EndDate > DateTime.Now && t.UserId == userId).ToListAsync();

            IList<GetTenantPaymentsResponse> response = new List<GetTenantPaymentsResponse>();
            response = new List<GetTenantPaymentsResponse>();

            var tenatPayments = await Context.Payments.Where(p => p.UserId == userId && p.IsPaid == false).ToListAsync();

            foreach(var tenantPayment in tenatPayments)
            {
                var paymentDto = Mapper.Map<Payment, GetTenantPaymentsResponse>(tenantPayment);
                response.Add(paymentDto);
            }

            return new ServiceResponse<IList<GetTenantPaymentsResponse>>(HttpStatusCode.OK, response);
        }

        public async Task<ServiceResponse> UpdatePaymentAsync(UpdatePaymentRequest request)
        {
            string userId = CurrentlyLoggedUser.Id;

            var landlord = await GetEntityByIdAsync<ApplicationUser>(userId);

            var payment = await Context.Payments.SingleOrDefaultAsync(p => p.Id == request.Id);
            var flatLandlord = await Context.FlatLandlords.Where(fl => fl.UserId == landlord.Id && fl.FlatId == payment.FlatId).SingleOrDefaultAsync();

            if(flatLandlord != null)
            {
                payment.Title = request.Title;
                payment.Description = request.Description;
                payment.Amount = request.Amount;
                payment.DueDate = request.DueDate;
                payment.IsPaid = request.IsPaid;
                payment.RecipientAccountNumber = request.RecipientAccountNumber;

                try
                {
                    await Context.SaveChangesAsync();
                    return new ServiceResponse(HttpStatusCode.OK);

                }
                catch (Exception ex)
                {
                    throw new RestException(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                throw new RestException(HttpStatusCode.BadRequest);
            }
        }
    }
}
