using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SqlLite_TEST.Configuration
{
    internal static class Config
    {
        public static string SourcesFolder { get => "Resources"; }
        public static string DatabaseName { get => "db"; }
        public static string DatabasePath { get => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SourcesFolder, $"{DatabaseName}.db" ); }
    }
}
