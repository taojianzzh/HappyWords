using HappyWords.Core.Models;
using HappyWords.Core.Services;
using HappyWords.Web.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HappyWords.Web.Controllers.Api
{
    [RoutePrefix("api/bing")]
    public class BingController : ApiController
    {
        [HttpGet]
        [Route("{spelling}")]
        public BingDictWord Put(string spelling)
        {
            if (string.IsNullOrWhiteSpace(spelling))
            {
                throw new BadRequestException("word spelling is requried.");
            }

            return BingDictService.Get(spelling);
        }
    }
}
