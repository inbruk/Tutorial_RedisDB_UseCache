using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;

namespace UseCache
{
    class Program
    {
        private static RedisClient client = new RedisClient("localhost");

        static void Main(String[] args)
        {
            CreateData("2", "something 2");
            String result = ReadData("2");
            Console.WriteLine("Created value = " + result);

            result = ReadData("3");
            Console.WriteLine("Not created value = " + result);

            UpdateData("2", "updated 2");
            result = ReadData("2");
            Console.WriteLine("Updated value = " + result);

            UpdateData("3", "updated 3");
            result = ReadData("3");
            Console.WriteLine("Not existed updated value = " + result);

            CreateOrUpdateData("4", "createdOrUpdated 4");
            result = ReadData("4");
            Console.WriteLine("CreateOrUpdated value = " + result);

            CreateOrUpdateData("4", "createdOrUpdated 44");
            result = ReadData("4");
            Console.WriteLine("CreateOrUpdated value = " + result);

            client.DeleteAll<String>();

            Console.ReadKey();
        }

        private static String ReadData(String key  )
        {
            String value = client.Get<String>(key);
            return value;
        }
        private static void CreateData(String key, String value)
        {
            if (client.Get(key) == null)
                client.Set(key, value);
        }

        private static void UpdateData(String key, String value)
        {
            if (client.Get(key) != null)
                client.Set(key, value);
        }

        private static void CreateOrUpdateData(String key, String value)
        {
            client.Set(key, value);
        }

        private static void DeleteData(String key)
        {
            client.Delete<String>(key);
        }

        private static void DeleteAllData()
        {
            client.DeleteAll<String>();
        }
    }
}