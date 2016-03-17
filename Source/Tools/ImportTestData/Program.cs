﻿using HappyWords.Data.Repositories;
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
            var words = _ParseWordsFromFile();
            foreach (var word in words)
            {
                WordRepository.Add(new Data.Models.Word(word));
                Console.Write(word + " ");
            }

            Console.WriteLine();
            Console.WriteLine("DONE");
            Console.ReadLine();
        }

        private static List<string> _ParseWordsFromFile()
        {
            var content = File.ReadAllText("Words.txt");
            var letters = from c in content.ToCharArray()
                          where char.IsLetter(c) || char.IsWhiteSpace(c)
                          select c;

            var words = new string(letters.ToArray()).Split(new string[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return words.Select(w => w.ToLower()).Distinct().ToList();
        }
    }
}