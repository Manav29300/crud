using Npgsql;
using Microsoft.Extensions.Configuration;

namespace GeneralCRUD
{
  
    public sealed class DbConnection
    {
        private static NpgsqlConnection _connection;
        private static readonly object _lock = new object();

        // Private constructor to prevent instantiation
        private DbConnection() { }

        public static NpgsqlConnection GetConnection(string connectionString)
        {
            if (_connection == null)
            {
                lock (_lock)
                {
                    if (_connection == null)
                    {
                        _connection = new NpgsqlConnection(connectionString);
                        _connection.Open();
                    }
                }
            }
            return _connection;
        }
    }

}
