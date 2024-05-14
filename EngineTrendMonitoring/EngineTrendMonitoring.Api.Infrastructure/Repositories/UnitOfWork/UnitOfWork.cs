using EngineTrendMonitoring.Api.Core.Repositories.UnitOfWork;

namespace EngineTrendMonitoring.Api.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        private readonly DbSession _session;
        #endregion

        #region Constructor
        public UnitOfWork(DbSession session)
        {
            _session = session;
        }
        #endregion

        #region Public Methods

        #region Begin Transaction
        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }
        #endregion

        #region Commit
        public void Commit()
        {
            _session.Transaction?.Commit();
            Dispose();
        }
        #endregion

        #region Rollback
        public void Rollback()
        {
            _session.Transaction?.Rollback();
            Dispose();
        }
        #endregion

        #region Dispose
        public void Dispose() => _session.Transaction?.Dispose();
        #endregion

        #endregion
    }
}
