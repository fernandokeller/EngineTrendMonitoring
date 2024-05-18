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
        public DbSession(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }
        #endregion

        #region Public Methods
        public void Dispose() => Connection?.Dispose();
        #endregion
    }
}
