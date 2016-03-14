using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Word : IMongoObject
    {
        public ObjectId Id { get; set; }
        public string Content { get; set; }
    }
}
