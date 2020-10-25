using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class TenancyService : Service, ITenancyService
    {
        public TenancyService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
