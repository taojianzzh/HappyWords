using HappyWords.Data.Exceptions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
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
        public string Chinese { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime AddedAt { get; set; }

        public Word(string spelling, string chinese)
        {
            if (string.IsNullOrWhiteSpace(spelling))
            {
                throw new HappyWordsException("Word spelling cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(chinese))
            {
                throw new HappyWordsException("Word chinese cannot be empty.");
            }

            Spelling = spelling.Trim().ToLower();
            Chinese = chinese.Trim();
        }

        public static void EnsureIndex(IMongoCollection<Word> mongoCollection)
        {
            mongoCollection.Indexes.CreateOne(new IndexKeysDefinitionBuilder<Word>().Ascending(w => w.AddedAt));
        }
    }
}
