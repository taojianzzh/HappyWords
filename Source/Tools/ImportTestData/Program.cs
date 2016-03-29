using HappyWords.Core.Services;
using HappyWords.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.ImportTestData
{
    class Program
    {
        static void Main(string[] args)
        {
            var spellings = _ParseWordsFromFile();
            var dbSpellings = WordRepository.Get().Select(w => w.Spelling).ToList();
            var existingWords = spellings.Intersect(dbSpellings).ToList();
            if (existingWords.Count > 0)
            {
                Console.WriteLine("{0} duplicate words in db.", existingWords.Count);
            }

            foreach (var spelling in spellings.Except(dbSpellings))
            {
                try
                {
                    Console.Write(spelling + " ");
                    WordService.Add(new Data.Models.Word(spelling));
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.WriteLine();
            Console.WriteLine("DONE");
            Console.ReadLine();
        }

        private static List<string> _ParseWordsFromFile()
        {
            var content = File.ReadAllText("Words2.txt");
            var letters = from c in content.ToCharArray()
                          where char.IsLetter(c) || char.IsWhiteSpace(c)
                          select c;

            var words = new string(letters.ToArray()).Split(new string[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return words.Select(w => w.ToLower()).Distinct().ToList();
        }
    }
}
