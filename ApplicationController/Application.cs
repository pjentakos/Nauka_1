using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLite_TEST.ApplicationController.Models;
using SqlLite_TEST.DatabaseControler;
using SqlLite_TEST.LogController;

namespace SqlLite_TEST.ApplicationController
{
    internal class Application
    {
        public Application()
        {
            
        }

        public bool Authorization(string login, string pass)
        {
            Log.Add(this, "Autoryzacja rozpoczęta");

            string sql = $"SELECT id FROM users WHERE login = '{login}' AND pass = '{pass}';";
            
            Database db = new();
            bool hasData = db.HasData(sql);
            db.Close();

            Log.Add(this, hasData ? "Logowanie zakończone sukcesem" : "Niepoprawny login i hasło");
            return hasData;
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
