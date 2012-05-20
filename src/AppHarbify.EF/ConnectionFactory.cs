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

        public static void Enable(bool enableMARS = false)
        {
            var connectionString = ConfigurationManager.AppSettings[ConnectionStringAppSetting];
            if (!String.IsNullOrEmpty(connectionString))
            {
                Database.DefaultConnectionFactory = new ConnectionFactory(connectionString, enableMARS);
            }
        }

        private readonly string _ConnectionString;

        public ConnectionFactory(string connectionString, bool enableMars)
        {
            _ConnectionString = connectionString;

            if (enableMars && !_ConnectionString.Contains("MultipleActiveResultSets=True"))
            {
                _ConnectionString += (_ConnectionString.EndsWith(";") ? "" : ";") + "MultipleActiveResultSets=True;";
            }
        }

        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            var conn = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();
            conn.ConnectionString = _ConnectionString;
            return conn;
        }

    }
}