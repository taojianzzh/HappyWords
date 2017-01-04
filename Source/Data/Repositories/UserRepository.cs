using HappyWords.Data.Interfaces;
using HappyWords.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace HappyWords.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetUserAsync(string userName)
        {
            return await DB.GetCollection<User>().AsQueryable().FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
