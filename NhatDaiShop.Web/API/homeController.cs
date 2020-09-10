using NhatDaiShop.Service;
using NhatDaiShop.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NhatDaiShop.Web.API
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class homeController : ApiControllerBase
    {
        IErrorService _errorService; 
        public homeController(IErrorService errorService): base(errorService)
        {
            this._errorService = errorService;
        }

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return ("Hello");
        }
    }
}
