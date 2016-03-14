using Data.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace Data.Repositories
{
    public static class WordRepository
    {
        public static void Add(Word word)
        {
            DB.GetCollection<Word>().InsertOne(word);
        }

        public static List<Word> Get()
        {
            return DB.GetCollection<Word>().AsQueryable().ToList();
        }
    }
}
