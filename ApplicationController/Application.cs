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

        public void Init()
        {
            // Tworzenie defaultopwego usera
            User u = new();

            u.FirstName = "Default";
            u.LastName = "Admin";
            u.Mail = "default@admin.com";
            u.Login = "Admin";
            u.Password = "Admin";
            u.AccessLevel = 0;

            u.Create();
        }



        public bool Authorization(string login, string pass)
        {
            //Log.Add(this, "Autoryzacja rozpoczęta");

            User u = new($"login = '{login}'");

            if (u.Id == 0)
            {
                Log.Add(this, $"Nieznaleziono użytkownika {login}!");
            }
            else
            {
                if(Password.VerifyPassword(pass, u.PasswordHash, u.PasswordSalt))
                {
                    return true;
                }
                else
                {
                    Log.Add(this, $"Haslo dla uzytkownika {u.Login} nieprawidłowe!");
                    return false;
                }
                
            }
                

            //string sql = $"SELECT id FROM users WHERE login = '{login}' AND pass = '{pass}';";

            //Database db = new();
            //bool hasData = db.HasData(sql);
            //db.Close();

            //Log.Add(this, hasData ? "Logowanie zakończone sukcesem" : "Niepoprawny login i hasło");
            //return hasData;

            return true;
        }

        ~Application()
        {

        }

    }
}
