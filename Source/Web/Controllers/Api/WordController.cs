using HappyWords.Core.Interfaces;
using HappyWords.Core.Services;
using HappyWords.Data.Interfaces;
using HappyWords.Data.Models;
using HappyWords.Data.Repositories;
using HappyWords.Web.Exceptions;
using HappyWords.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyWords.Web.Controllers.Api
{
    [Authorize]
    [Route("api/word")]
    public class WordController : ControllerBase
    {
        private IWordRepository _wordRepository;
        private IWordService _wordService;

        public WordController(IUserRepository userRepository, IWordRepository wordRepository, IWordService wordService)
            : base(userRepository)
        {
            _wordRepository = wordRepository;
            _wordService = wordService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("top200")]
        public async Task<List<Word>> GetTop200()
        {
            return await _wordRepository.GetAsync(200);
        }

        [HttpGet]
        [Route("")]
        public async Task<List<Word>> Get()
        {
            return await _wordRepository.GetAsync(UserContext.Id);
        }

        [HttpPost]
        [Route("")]
        public async Task<Word> Post(AddWordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Spelling))
            {
                throw new BadRequestException("word spelling is requried.");
            }
            var word = request.ConvertToWord();
            await _wordService.AddAsync(word);
            return word;
        }

        [HttpPut]
        [Route("{spelling}")]
        public Word Put(string spelling, UpdateWordRequest request)
        {
            if (string.IsNullOrWhiteSpace(spelling))
            {
                throw new BadRequestException("word spelling is requried.");
            }

            return _wordService.Update(request.ConvertToWord(spelling));
        }
    }
}
