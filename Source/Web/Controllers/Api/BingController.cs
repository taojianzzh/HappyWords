using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HappyWords.Core.Models;
using HappyWords.Web.Exceptions;
using HappyWords.Core.Services;

namespace HappyWords.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class BingController : Controller
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
