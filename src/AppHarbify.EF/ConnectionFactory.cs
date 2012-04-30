using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AppHarbify.EF
{
    public class ConnectionFactory : IDbConnectionFactory
    {
        public static string ConnectionStringAppSetting = "SQLSERVER_CONNECTION_STRING";

        public static void Enable()
        {
            var connectionString = ConfigurationManager.AppSettings[ConnectionStringAppSetting];
            if (!String.IsNullOrEmpty(connectionString))
            {
                Database.DefaultConnectionFactory = new ConnectionFactory(connectionString);
            }
        }

        private readonly string _ConnectionString;

        public ConnectionFactory(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            var conn = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();
            conn.ConnectionString = _ConnectionString;
            return conn;
        }
    }
}