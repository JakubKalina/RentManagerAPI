using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class TenancyController : BaseController
    {
        private readonly ITenancyService _tenancyService;

        public TenancyController(ITenancyService tenancyService)
        {
            _tenancyService = tenancyService;
        }
    }
}
