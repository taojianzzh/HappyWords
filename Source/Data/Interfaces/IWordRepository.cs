using HappyWords.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyWords.Data.Interfaces
{
    public interface IWordRepository
    {
        Task AddAsync(Word word);
        Task<List<Word>> GetAsync(string userId);
        Task<List<Word>> GetAsync(int count);
        Word Update(Word word);
    }
}
