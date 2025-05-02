using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite_TEST.LogController
{
    internal static class Log
    {
        public static void Add<T>(T value, string log)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] - ({value.GetType().Name}) -> {log}" );
        }

        public static void Add(string className, string log)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] - ({className}) -> {log}");
        }
    }
}
