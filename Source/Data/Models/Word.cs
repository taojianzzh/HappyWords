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

        public Word(string spelling)
        {
            if (string.IsNullOrWhiteSpace(spelling))
            {
                throw new HappyWordsException("Word spelling cannot be empty.");
            }

            Spelling = spelling.Trim().ToLower();
            AddedAt = DateTime.Now;
        }

        public Word(string spelling, string chinese)
            : this(spelling)
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
