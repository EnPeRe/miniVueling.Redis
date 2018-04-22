using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.LegacyConfiguration;
using StackExchange.Redis.Extensions.Newtonsoft;
using Vueling.Redis.Common;

namespace Vueling.Redis.Dao
{
    public class StudentDao
    {
        StackExchangeRedisCacheClient cacheClient;
        NewtonsoftSerializer serializer;

        public bool Save<T>(string key, T value)
        {
            bool isSuccess;

            serializer = new NewtonsoftSerializer();
            var redisConfiguration = RedisCachingSectionHandler.GetConfig();

            using (cacheClient = new StackExchangeRedisCacheClient(serializer, redisConfiguration))
            {
                isSuccess = cacheClient.Add<T>(key, value);                
            }
            return isSuccess;
        }

        public T Read<T>(string key)
        {
            serializer = new NewtonsoftSerializer();
            var redisConfiguration = RedisCachingSectionHandler.GetConfig();

            using (cacheClient = new StackExchangeRedisCacheClient(serializer, redisConfiguration))
            {
                return cacheClient.Get<T>(key);
            }
        }
    }
}
