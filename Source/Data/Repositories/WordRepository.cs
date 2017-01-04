using HappyWords.Data.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using HappyWords.Data.Exceptions;
using HappyWords.Data.Interfaces;

namespace HappyWords.Data.Repositories
{
    public class WordRepository : IWordRepository
    {
        public async Task AddAsync(Word word)
        {
            word.AddedAt = DateTime.Now;

            try
            {
                await DB.GetCollection<Word>().InsertOneAsync(word);
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

        public async Task<List<Word>> GetAsync(string userId)
        {
            return await DB.GetCollection<Word>().AsQueryable()
                .Where(w => w.UserId == userId)
                .OrderByDescending(w => w.AddedAt)
                .ToListAsync();
        }

        public async Task<List<Word>> GetAsync(int count)
        {
            return await DB.GetCollection<Word>().AsQueryable()
                .OrderByDescending(w => w.AddedAt)
                .Take(count)
                .ToListAsync();
        }

        public Word Update(Word word)
        {
            var wordCollection = DB.GetCollection<Word>();
            var dbWord = wordCollection.AsQueryable().FirstOrDefault(w => w.Id == word.Id);
            dbWord.UpdateFrom(word);
            wordCollection.ReplaceOne(Builders<Word>.Filter.Eq(w => w.Spelling, word.Spelling), dbWord);
            return word;
        }
    }
}
