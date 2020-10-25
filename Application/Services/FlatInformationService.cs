using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class FlatInformationService : Service, IFlatInformationService
    {
        public FlatInformationService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
