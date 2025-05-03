using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLite_TEST.DatabaseControler;
using SqlLite_TEST.LogController;
using SqlLite_TEST.ApplicationController;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace SqlLite_TEST.ApplicationController.Models
{
    public record User
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Login { get; set; }
        public string Password 
        {
            set
            {
                (this.PasswordHash, this.PasswordSalt) = ApplicationController.Password.HashPassword(value);
            }
        }
        [JsonIgnore]
        public string PasswordHash { get; private set; }
        [JsonIgnore]
        public string PasswordSalt { get; private set; }
        public int AccessLevel { get; set; }

        private bool got = false;
        private bool created = false;

        public User()
        {
            
        }


        public User(string sqlWhere)
        {
            Database db = new();
            UserDB u = db.GetModel<UserDB>("USERS", sqlWhere);

            if(u != null)
            {
                this.Id = u.id;
                this.FirstName = u.first_name;
                this.LastName = u.last_name;
                this.Mail = u.mail;
                this.Login = u.login;
                this.PasswordHash = u.pass;
                this.PasswordSalt = u.pass_salt;
                this.AccessLevel = u.access_level;

                Log.Add(this, $"Pobrałem użytkownika o id: {this.Id}");
                got = true;
            }

        }

        public void Update()
        {
            if (got || created)
            {
                string sql = "UPDATE USERS SET " +
                             $"first_name = '{this.FirstName}', " +
                             $"last_name = '{this.LastName}', " +
                             $"mail = '{this.Mail}', " +
                             $"login = '{this.Login}', " +
                             $"pass = '{this.PasswordHash}', " +
                             $"pass_salt = '{this.PasswordSalt}', " +
                             $"access_level = {this.AccessLevel} " +
                             $"WHERE id = {this.Id}";

                Database db = new();
                db.Update(sql);
                db.Close();

                Log.Add(this, $"Zaktualizowałem użytkownika o id: {this.Id}");

            }
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
                     $"('{this.FirstName}', '{this.LastName}', '{this.Mail}', '{this.Login}', '{this.PasswordHash}', '{this.PasswordSalt}', '{this.AccessLevel}')";

                    Database db = new();

                    this.Id = db.Insert(sql);
                    db.Close();

                    created = true;

                    Log.Add(this, $"Dodałem użytkownika o id: {this.Id}");
                }
            }
            catch
            {
                
            }
        }
    }
}
