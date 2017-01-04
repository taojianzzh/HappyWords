using HappyWords.Data.Exceptions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;
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
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }      
          
        public string Spelling { get; set; }
        public string Chinese { get; set; }
        public string USPron { get; set; }
        public string UKPron { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [JsonIgnore]
        public DateTime AddedAt { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        public Word(string userId, string spelling)
        {
            if (string.IsNullOrWhiteSpace(spelling))
            {
                throw new HappyWordsException("Word spelling cannot be empty.");
            }

            Spelling = spelling.Trim().ToLower();
            UserId = userId;
            AddedAt = DateTime.Now;
        }

        public Word(string userId, string spelling, string chinese)
            : this(userId, spelling)
        {
            Chinese = chinese;
        }

        public Word(string spelling, string chinese, string usPron, string ukPron)
            : this(spelling, chinese)
        {
            USPron = usPron;
            UKPron = ukPron;
        }

        public static void EnsureIndex(IMongoCollection<Word> mongoCollection)
        {
            mongoCollection.Indexes.CreateOne(new IndexKeysDefinitionBuilder<Word>().Ascending(w => w.AddedAt));
            mongoCollection.Indexes.CreateOne(new IndexKeysDefinitionBuilder<Word>().Ascending(w => w.UpdatedAt));
            mongoCollection.Indexes.CreateOne(new IndexKeysDefinitionBuilder<Word>().Ascending(w => w.UserId));
        }

        public void UpdateFrom(Word word)
        {
            Chinese = word.Chinese;
            USPron = word.USPron;
            UKPron = word.UKPron;
            UpdatedAt = DateTime.Now;
        }
    }
}
