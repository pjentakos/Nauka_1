using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLite_TEST.DatabaseControler;
using SqlLite_TEST.LogController;


namespace SqlLite_TEST.ApplicationController.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int AccessLevel { get; set; }

        public bool got;
        

        public User()
        {

        }

        public User(string sqlWhere)
        {
            Database db = new();
            UserDB u = db.GetModel<UserDB>("USERS", sqlWhere);

            this.Id = u.id;
            this.FristName = u.first_name;
            this.LastName = u.last_name;
            this.Mail = u.mail;
            this.Login = u.login;
            this.Password = u.pass;
            this.PasswordSalt = u.pass_salt;
            this.AccessLevel = u.access_level;

            Log.Add(this, $"Pobrałem użytkownika o id: {this.Id}");
            got = true;
        }

        public void Create()
        {

            try
            {
                if (got)
                {
                    string error = "Próba dodania użytkownika, który został pobrany przez klasę.";

                    Log.Add(this, error);
                    throw new ArgumentException(error);
                }
                else
                {
                    string sql = "INSERT INTO USERS " +
                     "(first_name, last_name, mail, login, pass, pass_salt, access_level) " +
                     "values " +
                     $"('{this.FristName}', '{this.LastName}', '{this.Mail}', '{this.Login}', '{this.Password}', '{this.PasswordSalt}', '{this.AccessLevel}')";

                    Database db = new();

                    this.Id = db.Insert(sql);
                    db.Close();

                    Log.Add(this, $"Dodałem użytkownika o id: {this.Id}");
                }
            }
            catch
            {
                
            }
        }





    }
}
