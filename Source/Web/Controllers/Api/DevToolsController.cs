using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HappyWords.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using HappyWords.Data.Interfaces;
using HappyWords.Data.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using HappyWords.Web.Filters;
using HappyWords.Core.Interfaces;

namespace HappyWords.Web.Controllers.Api
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class DevToolsController : ControllerBase
    {
        private static readonly HashSet<char> _ignoredPronChars = new HashSet<char>(new char[] { 'ˈ', '(', ')', ',', ',', 'ː', 'ˌ', '\'', '.', ' ' });
        private IWordRepository _wordRepository;
        private IWordService _wordService;
        private IHostingEnvironment _env;

        public DevToolsController(
            IUserRepository userRepository, 
            IWordRepository wordRepository,
            IWordService wordService,
            IHostingEnvironment env)
            : base(userRepository)
        {
            _wordRepository = wordRepository;
            _wordService = wordService;
            _env = env;
        }

        [Route("GetProns", Name = "GetPronsApi")]
        public async Task<List<string>> GetPronChars()
        {
            var words = await _wordRepository.GetAsync(UserContext.Id);
            var pronChars = words.Where(w => !string.IsNullOrWhiteSpace(w.USPron))
                                 .SelectMany(w => w.USPron.ToCharArray()).ToList();

            var prons = new List<string>();
            for (int i = 0; i < pronChars.Count; i++)
            {
                var c = pronChars[i];
                if (_ignoredPronChars.Contains(c))
                {
                    continue;
                }

                if (c != ':')
                {
                    prons.Add(c.ToString());
                }
                else
                {
                    prons.Add(pronChars[i - 1].ToString() + c.ToString());
                }
            }

            return prons.Distinct().ToList();
        }

        [Route("ImportWords1", Name = "ImportWords1Api")]
        public async Task<List<Word>> ImportWords1()
        {
            return await _ImportWords("Words1.txt");
        }

        private async Task<List<Word>> _ImportWords(string fileName)
        {
            var spellings = _ParseWordsFromFile(fileName);
            var dbWords = await _wordRepository.GetAsync(UserContext.Id);
            var dbSpellings = dbWords.Select(w => w.Spelling).ToList();
            var words = new List<Word>();

            foreach (var spelling in spellings.Except(dbSpellings))
            {
                var word = new Word(UserContext.Id, spelling);
                await _wordService.AddAsync(word);
                words.Add(word);
            }

            return words;
        }

        private List<string> _ParseWordsFromFile(string fileName)
        {
            var fileNameFullPath = Path.Combine(_env.WebRootPath, "DevTools", fileName);
            var content = System.IO.File.ReadAllText(fileNameFullPath);
            var letters = from c in content.ToCharArray()
                          where char.IsLetter(c) || char.IsWhiteSpace(c)
                          select c;

            var words = new string(letters.ToArray()).Split(new string[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return words.Select(w => w.ToLower()).Distinct().ToList();
        }
    }
}
