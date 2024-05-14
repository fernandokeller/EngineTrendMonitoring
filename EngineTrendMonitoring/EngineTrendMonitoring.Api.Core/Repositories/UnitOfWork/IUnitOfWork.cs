namespace EngineTrendMonitoring.Api.Core.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
