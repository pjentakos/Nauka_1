using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite_TEST.ApplicationController.Models
{
    internal class UserDB
    {
        public int id { get; init; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string mail { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public string pass_salt { get; set; }
        public int access_level { get; set; }
    }
}
