using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class AddressService : Service, IAddressService
    {
        public AddressService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
