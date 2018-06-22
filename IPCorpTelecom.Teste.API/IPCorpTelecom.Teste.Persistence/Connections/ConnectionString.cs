using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace IPCorpTelecom.Teste.Persistence.Connections
{
    public class ConnectionsString
    {
        /// <summary>
        /// Seleciona a connection string do arquivo de configuração
        /// </summary>
        public static string DefaultConnectionString
        {
            get
            {
               var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
               var configuration = builder.Build();

                string connectionString = configuration.GetConnectionString("Connection");
                
                return connectionString;
            }
        }

        public static SqlConnection GetDefaultSqlServerConnection()
        {
            var _conn = new SqlConnection(DefaultConnectionString);
            _conn.Open();

            return _conn;
        }
    }
}



