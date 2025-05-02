using System.Data;
using SqlLite_TEST.ApplicationController;
using SqlLite_TEST.ApplicationController.Models;
using SqlLite_TEST.DatabaseControler;

namespace SqlLite_TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var connectionString = @"Data Source=C:\Users\lpie\source\repos\\SqlLite TEST\db.db";

            //using (var conn = new SqliteConnection(connectionString))
            //{
            //    conn.Open();

            //    var cmd = conn.CreateCommand();

            //}

            //Utworzenie folderow i wrzucenie resoure:
            User u = new();
            u.FristName = "Eldoka";
            u.LastName = "Nawolno";
            u.Mail = "eldoka@nawolno.com";
            u.Login = "Eldo";
            u.Password = "NaWolno";
            u.PasswordSalt = "1213566";
            u.AccessLevel = 1;


            Application app = new();
            app.CreateUser(u);


            Database db = new();
            Console.WriteLine(db.Test().ToString());

            
            


            



        }
    }
}
