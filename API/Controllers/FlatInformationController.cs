using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class FlatInformationController : BaseController
    {
        private readonly IFlatInformationService _flatInformationService;
        public FlatInformationController(IFlatInformationService flatInformationService)
        {
            _flatInformationService = flatInformationService;
        }
    }
}
