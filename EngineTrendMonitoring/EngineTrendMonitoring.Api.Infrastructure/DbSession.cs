using Microsoft.Data.SqlClient;
using System.Data;

namespace EngineTrendMonitoring.Api.Infrastructure
{
    public class DbSession : IDisposable
    {
        #region Properties
        public IDbConnection Connection { get; }
        public IDbTransaction? Transaction { get; set; }
        #endregion

        #region Constructor
        public DbSession()
        {
            var csBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = @"..\Database\EngineTrendDatabase.mdf",
                IntegratedSecurity = true
            };

            Connection = new SqlConnection(csBuilder.ConnectionString);
            Connection.Open();
        }
        #endregion

        #region Public Methods
        public void Dispose() => Connection?.Dispose();
        #endregion
    }
}
