using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StackExchange.Redis;

namespace UseCache
{
    class Program
    {
        static void Main(String[] args)
        {
            ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("localhost");
            IDatabase redisDb = conn.GetDatabase();
            redisDb.StringSet("1", "something 1");
            Console.WriteLine("Created value from redis = " + redisDb.StringGet("1"));
            redisDb.StringSet("1", "updated 1");
            Console.WriteLine("Updated value from redis = " + redisDb.StringGet("1"));
            Console.ReadKey();
        }
    }
}