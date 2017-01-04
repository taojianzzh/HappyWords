using HappyWords.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyWords.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string userName);
    }
}
