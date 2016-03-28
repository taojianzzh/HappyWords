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
            return WordService.Add(new Word(request.Spelling, request.Chinese));
        }

        [HttpPut]
        [Route("")]
        public Word Put([FromBody]Word request)
        {
            if (string.IsNullOrWhiteSpace(request.Spelling))
            {
                throw new BadRequestException("word spelling is requried.");
            }
            return WordService.Add(new Word(request.Spelling, request.Chinese));
        }
    }
}
