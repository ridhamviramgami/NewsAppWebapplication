using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.AppSettings
{
    public static class AppsettingsConnectionString
    {
        public static string Credentials { get; set; }
        public static string Host { get; set; }
        public static string Database { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
    }
}
