using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.Api
{
    [RoutePrefix("api/word")]
    public class WordController : ApiController
    {
        [HttpGet]
        [Route("")]
        public List<Word> Get()
        {
            return WordRepository.Get();
        }

        [HttpPost]
        [Route("")]
        public void Post([FromBody]string word)
        {
            WordRepository.Add(new Word()
            {
                Content = word
            });
        }
    }
}
