namespace EngineTrendMonitoring.Api.Infrastructure.Repositories.Base
{
    public class BaseRepository
    {
        #region Properties
        protected DbSession _session;

        public BaseRepository(DbSession session)
        {
            _session = session;
        }
        #endregion
    }
}
