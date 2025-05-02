using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite_TEST.ApplicationController.Models
{
    internal class User
    {
        public int Id { get;}
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int AccessLevel { get; set; }

    }
}
