using HappyWords.Core.Services;
using HappyWords.Data.Models;
using HappyWords.Data.Repositories;
using HappyWords.Web.Exceptions;
using HappyWords.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace HappyWords.Web.Controllers.Api
{
    [Route("api/word")]
    public class WordController : Controller
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
        public Word Post(AddWordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Spelling))
            {
                throw new BadRequestException("word spelling is requried.");
            }
            return WordService.Add(request.ConvertToWord());
        }

        [HttpPut]
        [Route("{spelling}")]
        public Word Put(string spelling, UpdateWordRequest request)
        {
            if (string.IsNullOrWhiteSpace(spelling))
            {
                throw new BadRequestException("word spelling is requried.");
            }

            return WordService.Update(request.ConvertToWord(spelling));
        }
    }
}
