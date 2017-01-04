using HappyWords.Core.Interfaces;
using HappyWords.Data.Interfaces;
using HappyWords.Data.Models;
using HappyWords.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Core.Services
{
    public class WordService : IWordService
    {
        private IWordRepository _wordRepository;
        private IBingDictService _bingDictService;

        public WordService(IWordRepository wordRepository, IBingDictService bingDictService)
        {
            _wordRepository = wordRepository;
            _bingDictService = bingDictService;
        }

        public async Task AddAsync(Word word)
        {
            if (word == null || string.IsNullOrWhiteSpace(word.Spelling))
            {
                throw new ArgumentException("word");
            }

            if (string.IsNullOrWhiteSpace(word.Chinese) ||
                string.IsNullOrWhiteSpace(word.UKPron) ||
                string.IsNullOrWhiteSpace(word.USPron))
            {
                var bingWord = _bingDictService.Get(word.Spelling);
                if (string.IsNullOrWhiteSpace(word.Chinese))
                {
                    word.Chinese = bingWord.Chinese;
                }

                if (string.IsNullOrWhiteSpace(word.UKPron))
                {
                    word.UKPron = bingWord.Pron.UK;
                }

                if (string.IsNullOrWhiteSpace(word.USPron))
                {
                    word.USPron = bingWord.Pron.US;
                }
            }

            await _wordRepository.AddAsync(word);
        }

        public Word Update(Word word)
        {
            if (word == null || string.IsNullOrWhiteSpace(word.Spelling))
            {
                throw new ArgumentException("word");
            }

            return _wordRepository.Update(word);
        }
    }
}
