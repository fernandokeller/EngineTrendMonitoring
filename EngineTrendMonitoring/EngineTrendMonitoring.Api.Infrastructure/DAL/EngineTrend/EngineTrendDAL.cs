using EngineTrendMonitoring.Api.Core.DAL.EngineTrend;
using EngineTrendMonitoring.Api.Infrastructure.Repositories.Base;

namespace EngineTrendMonitoring.Api.Infrastructure.DAL.EngineTrend
{
    public class EngineTrendDAL : BaseRepository, IEngineTrendDAL
    {
        #region Properties
        #endregion

        #region Constructor
        public EngineTrendDAL(DbSession session) : base(session)
        {
        }
        #endregion

        #region Public Methods
        #endregion
    }
}
