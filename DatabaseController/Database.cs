using System.Data;
using SqlLite_TEST.Configuration;
using Microsoft.Data.Sqlite;

namespace SqlLite_TEST.DatabaseControler
{
    public class Database
    {
        string connString;
        SqliteConnection conn;

        public Database()
        {
            connString = $"Data Source={Config.DatabasePath}";
            conn = new SqliteConnection(connString);
            conn.Open();
            
        }
        
        public void Open()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        public bool HasData (string sql)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            using (var r = cmd.ExecuteReader())
            {
                return r.HasRows;
            }
        }

        public void Execute(string sql)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();
        }

        public DataTable GetTable(string sql)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            DataTable dt = new();

            using (var r = cmd.ExecuteReader())
            {
                dt.Load(r);
            }
            
            return dt;
        }

        public object GetField(string tableName, string fieldName, params )


        public object Test()
        {
            DataTable dt = this.GetTable("SELECT first_name from USERS WHERE id = 2");


            return dt.Rows[0]["first_name"].ToString();


        }

        public void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        ~Database()
        {
            this.Close();
        }

    }
}
