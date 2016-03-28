using HappyWords.Core.Services;
using HappyWords.Data.Models;
using HappyWords.Data.Repositories;
using HappyWords.Web.Exceptions;
using HappyWords.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HappyWords.Web.Controllers.Api
{
    [RoutePrefix("api/word")]
    public class WordController : ApiController
    {
        [HttpGet]
        [Route("")]
        public List<Word> Get(int? take = null)
        {
            if (take != null)
            {
                return WordRepository.Get(take.Value);
            }
            else
            {
                return WordRepository.Get();
            }
        }

        [HttpPost]
        [Route("")]
        public Word Post([FromBody]AddWordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Spelling))
            {
                throw new BadRequestException("word spelling is requried.");
            }
            return WordService.Add(request.ConvertToWord());
        }

        [HttpPut]
        [Route("{spelling}")]
        public Word Put(string spelling, [FromBody]UpdateWordRequest request)
        {
            if (string.IsNullOrWhiteSpace(spelling))
            {
                throw new BadRequestException("word spelling is requried.");
            }

            return WordService.Update(request.ConvertToWord(spelling));
        }
    }
}
