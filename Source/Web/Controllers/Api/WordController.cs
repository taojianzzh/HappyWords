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
        public List<Word> Get()
        {
            return WordRepository.Get().Select(w => new Word(w)).ToList();
        }

        [HttpPost]
        [Route("")]
        public void Post([FromBody]Word word)
        {
            _ValidateWord(word);
            WordRepository.Add(new Data.Models.Word(word.Spelling, word.Chinese));
        }

        private void _ValidateWord(Word word)
        {
            if (word == null)
            {
                throw new BadRequestException("word is requried.");
            }
            if (string.IsNullOrWhiteSpace(word.Spelling))
            {
                throw new BadRequestException("word spelling is requried.");
            }
            if (string.IsNullOrWhiteSpace(word.Chinese))
            {
                throw new BadRequestException("word chinese is requried.");
            }
        }
    }
}
