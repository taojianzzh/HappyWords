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
            return DB.GetCollection<Word>().AsQueryable().ToList();
        }
    }
}
