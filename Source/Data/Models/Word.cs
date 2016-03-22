using HappyWords.Data.Exceptions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Data.Models
{
    public class Word : IMongoObject
    {
        [BsonId]
        public string Spelling { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime AddedAt { get; set; }

        public Word(string spelling)
        {
            if (string.IsNullOrWhiteSpace(spelling))
            {
                throw new HappyWordsException("Word spelling cannot be empty.");
            }

            Spelling = spelling.Trim().ToLower();
        }
    }
}
