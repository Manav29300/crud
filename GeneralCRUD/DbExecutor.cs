using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;


namespace GeneralCRUD
{

    public class DbExecutor
    {
        private readonly NpgsqlConnection _connection;

        public DbExecutor(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        // Execute non-query for Insert, Update, Delete
        public int ExecuteNonQuery(string sql, object parameters = null)
        {
            return _connection.Execute(sql, parameters);
        }

        // Execute a scalar query (e.g., count, sum)
        public T ExecuteScalar<T>(string sql, object parameters = null)
        {
            return _connection.ExecuteScalar<T>(sql, parameters);
        }

        // Execute a query to return a list of T (generic result)
        public List<T> ExecuteQuery<T>(string sql, object parameters = null)
        {
            return _connection.Query<T>(sql, parameters).AsList();
        }
    }

}
