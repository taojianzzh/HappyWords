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
            var words = WordRepository.Get().Select(w => new Word(w));
            if (take != null)
            {
                words = words.Take(take.Value);
            }
            return words.ToList();
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
