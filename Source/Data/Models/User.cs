using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyWords.Data.Models
{
    public class User : IMongoObject
    {
        public ObjectId Id { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
