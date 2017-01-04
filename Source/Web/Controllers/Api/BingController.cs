using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HappyWords.Core.Models;
using HappyWords.Web.Exceptions;
using HappyWords.Core.Services;
using Microsoft.AspNetCore.Authorization;
using HappyWords.Data.Interfaces;
using HappyWords.Core.Interfaces;

namespace HappyWords.Web.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class BingController : ControllerBase
    {
        private IBingDictService _bingDictService;

        public BingController(IUserRepository userRepository, IBingDictService bingDictService)
            : base(userRepository)
        {
            _bingDictService = bingDictService;
        }

        [HttpGet]
        [Route("{spelling}")]
        public BingDictWord Put(string spelling)
        {
            if (string.IsNullOrWhiteSpace(spelling))
            {
                throw new BadRequestException("word spelling is requried.");
            }

            return _bingDictService.Get(spelling);
        }
    }
}
