using HappyWords.Data.Models;
using HappyWords.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Core.Services
{
    public static class WordService
    {
        public static Word Add(Word word)
        {
            if (word == null || string.IsNullOrWhiteSpace(word.Spelling))
            {
                throw new ArgumentException("word");
            }

            if (string.IsNullOrWhiteSpace(word.Chinese) ||
                string.IsNullOrWhiteSpace(word.UKPron) ||
                string.IsNullOrWhiteSpace(word.USPron))
            {
                var bingWord = BingDictService.Get(word.Spelling);
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

            WordRepository.Add(word);

            return word;
        }
    }
}
