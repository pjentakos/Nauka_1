using System.Data;
using SqlLite_TEST.Configuration;
using Microsoft.Data.Sqlite;
using Dapper;
using SqlLite_TEST.LogController;

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
            this.Open();
            
        }
        
        public void Open()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                Log.Add(this, "Połączenie z bazą danych");
            }
        }

        public bool HasData (string sql)
        {
            
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;

                using (var r = cmd.ExecuteReader())
                {
                    return r.HasRows;
                }
            }
        }

        private void Execute(string sql)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }


        public void Update(string sql)
        {
            this.Execute(sql);
        }

        public int Insert(string sql)
        {
            this.Execute(sql);

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT last_insert_rowid();";

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        return r.GetInt32(0);
                        this.Close();
                    }

                    return -1;
                }
            }
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

        public object GetField(string tableName, string fieldName, string sqlWhere)
        {
            string sql = $"SELECT {fieldName} FROM {tableName} WHERE {sqlWhere} LIMIT 1";

            DataTable dt = this.GetTable(sql);

            return dt.Rows[0][fieldName].ToString();
        }

        public T GetModel<T>(string tableName, string sqlWhere)
        {
            string sql = $"SELECT * FROM {tableName} WHERE {sqlWhere} LIMIT 1";

            return conn.QuerySingleOrDefault<T>(sql);
        }

        public void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                Log.Add(this, "Zamknięcie połączenia z bazą danych");
            }
        }

        ~Database()
        {
            this.Close();
        }

    }
}
