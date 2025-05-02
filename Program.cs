using System.Data;
using SqlLite_TEST.ApplicationController;
using SqlLite_TEST.ApplicationController.Models;
using SqlLite_TEST.DatabaseControler;
using SqlLite_TEST.LogController;

namespace SqlLite_TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log.Add("Main", "Aplikacja uruchomiona");
            Application app = new();

            string login = "pjntk";
            string haslo = "Test";

            if(app.Authorization(login, haslo))
            {
                //User curentUser

                //User u = new();
                //u.FristName = "Eldoka";
                //u.LastName = "Nawolno";
                //u.Mail = "eldoka@nawolno.com";
                //u.Login = "Eldo";
                //u.Password = "NaWolno";
                //u.PasswordSalt = "1213566";
                //u.AccessLevel = 1;

                //u.Create();


                //User u1 = new("id = 1");

                //User u2 = new();
                //u.FristName = "Eldoka";
                //u.LastName = "Nawolno";
                //u.Mail = "eldoka@nawolno.com";
                //u2.Login = "Eldo";
                //u2.Password = "NaWolno";
                //u2.PasswordSalt = "1213566";
                //u2.AccessLevel = 1;

                //u2.Create();
            }
            


        }
    }
}
