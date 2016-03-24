using HappyWords.Data.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Data
{
    public static class DB
    {
        private static IMongoDatabase _db;
        private static Dictionary<Type, string> _mappings = new Dictionary<Type, string>();

        static DB()
        {
            _Init();
        }

        public static IMongoCollection<T> GetCollection<T>()
            where T : IMongoObject
        {
            string collectionName;
            if (!_mappings.TryGetValue(typeof(T), out collectionName))
            {
                throw new Exception("MongoDB collection was not defined for type: " + typeof(T).ToString());
            }

            return _db.GetCollection<T>(collectionName);
        }

        private static void _Init()
        {
            var client = new MongoClient();
            _db = client.GetDatabase("HappyWords");

            _mappings.Add(typeof(Word), "Words");
            _EnsureIndexes();
        }

        private static void _EnsureIndexes()
        {
            foreach (var mapping in _mappings)
            {
                var methodInfo = mapping.Key.GetMethod("EnsureIndex", BindingFlags.Public | BindingFlags.Static);
                if (methodInfo != null)
                {
                    var collection = typeof(DB).GetMethod("GetCollection")
                                                         .MakeGenericMethod(mapping.Key)
                                                         .Invoke(null, null);
                    methodInfo.Invoke(null, new object[] { collection });
                }
            }
        }
    }
}
