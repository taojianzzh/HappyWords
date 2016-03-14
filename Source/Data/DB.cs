using Data.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class DB
    {
        private static IMongoDatabase _db;
        private static bool _initialized = false;
        private static object _initLocker = new object();
        private static Dictionary<Type, string> _mappings = new Dictionary<Type, string>();

        public static IMongoCollection<T> GetCollection<T>()
            where T : IMongoObject
        {
            _Init();

            string collectionName;
            if (!_mappings.TryGetValue(typeof(T), out collectionName))
            {
                throw new Exception("MongoDB collection was not defined for type: " + typeof(T).ToString());
            }

            return _db.GetCollection<T>(collectionName);
        }

        private static void _Init()
        {
            if (!_initialized)
            {
                lock(_initLocker)
                {
                    if (!_initialized)
                    {
                        var client = new MongoClient();
                        _db = client.GetDatabase("HappyWords");

                        _mappings.Add(typeof(Word), "Words");

                        _initialized = true;
                    }
                }
            }
        }
    }
}
