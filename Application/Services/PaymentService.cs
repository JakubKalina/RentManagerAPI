using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class PaymentService : Service, IPaymentService
    {
        public PaymentService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
