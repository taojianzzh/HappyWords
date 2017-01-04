using HappyWords.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyWords.Core.Interfaces
{
    public interface IWordService
    {
        Task AddAsync(Word word);
        Word Update(Word word);
    }
}
