using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLite_TEST.ApplicationController.Models;
using SqlLite_TEST.DatabaseControler;

namespace SqlLite_TEST.ApplicationController
{
    internal class Application
    {
        

        public Application()
        {
            
        }

        public bool Authorization(string login, string pass)
        {
            string sql = $"SELECT id FROM users WHERE login = '{login}' AND password = '{pass}';";
            
            Database db = new();
            bool hasData = db.HasData(sql);
            db.Close();

            return hasData;
        }

        public void CreateUser(User user)
        {
            string sql = "INSERT INTO USERS " +
                         "(first_name, last_name, mail, login, pass, pass_salt, access_level) " +
                         "values " +
                         $"('{user.FristName}', '{user.LastName}', '{user.Mail}', '{user.Login}', '{user.Password}', '{user.PasswordSalt}', '{user.AccessLevel}')";

            Database db = new();

            db.Execute(sql);
            db.Close();

        }

        public User GetUser(int id)
        {
            User u = new();

            return u;
        }

        ~Application()
        {

        }

    }
}
