namespace Fanex.N88.Core.Service.Interface
{
    using System.Linq;
    using Fanex.N88.Core.Criteria.Trace;
    using Fanex.N88.Core.Model.ValueObject;

    public interface ITraceService : IBaseService
    {
        LogExecSp GetById(int logId);

        IQueryable<LogExecSp> SearchExecSp(GetAllLogCriteria criteria);

        IQueryable<LogUserLogin> SearchUserLogin(GetAllLogUserLoginCriteria criteria);
    }
}