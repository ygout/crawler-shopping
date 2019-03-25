using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace crawler_shopping.src.DbConnection
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
        public IDbConnection GetConnection
        {
            get
            {
                Console.WriteLine("Get connection");
                DbProviderFactory factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
                System.Data.Common.DbConnection conn = factory.CreateConnection();
                Console.WriteLine($"connectionString {connectionString}");
                conn.ConnectionString = connectionString;
                conn.Open();
                Console.WriteLine("Connection open");
                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection working");
                }
                else
                {
                    Console.WriteLine("Connection failed");
                }
                return conn;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redudant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }
        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ConnectionFactory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
