using HappyWords.Data.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using HappyWords.Data.Exceptions;

namespace HappyWords.Data.Repositories
{
    public static class WordRepository
    {
        public static void Add(Word word)
        {
            word.AddedAt = DateTime.Now;

            try
            {
                DB.GetCollection<Word>().InsertOne(word);
            }
            catch (MongoWriteException exception)
            {
                if (exception.Message.Contains("E11000"))
                {
                    throw new DuplicateObjectException(typeof(Word), word.Spelling, exception);
                }
                else
                {
                    throw;
                }
            }
        }

        public static List<Word> Get()
        {
            return DB.GetCollection<Word>().AsQueryable().OrderByDescending(w => w.AddedAt).ToList();
        }

        public static List<Word> Get(int count)
        {
            return DB.GetCollection<Word>().AsQueryable().OrderByDescending(w => w.AddedAt).Take(count).ToList();
        }

        public static Word Update(Word word)
        {
            var wordCollection = DB.GetCollection<Word>();
            var dbWord = wordCollection.AsQueryable().FirstOrDefault(w => w.Spelling == word.Spelling);
            dbWord.UpdateFrom(word);
            wordCollection.ReplaceOne(Builders<Word>.Filter.Eq(w => w.Spelling, word.Spelling), dbWord);
            return word;
        }
    }
}
