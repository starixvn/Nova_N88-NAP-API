namespace Fanex.N88.Core.Repository.Interface
{
    using System.Linq;
    using Fanex.Data.Repository;
    using Fanex.N88.Core.Command;
    using Fanex.N88.Core.Criteria.Trace;
    using Fanex.N88.Core.Model.ValueObject;

    public interface ITraceRepository : IDynamicRepository
    {
        IQueryable<LogExecSp> SearchLogExecSp(GetAllLogCriteria criteria);

        IQueryable<LogUserLogin> SearchLogUserLogin(GetAllLogUserLoginCriteria criteria);

        LogExecSp GetById(ICriteria criteria);

        ICommandResult InsertLog(ICriteria criteria);
    }
}