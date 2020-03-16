namespace Fanex.N88.Core.Service.Interface
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Fanex.Data.Repository;
    using Fanex.N88.Core.Criteria.Misc;

    public interface IBaseService
    {
        IServiceContext ServiceContext { get; set; }

        IEnumerable<T> GetData<T>(ICriteria criteria);

        T GetItem<T>(ICriteria criteria) where T : new();

        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        LogExecSpCriteria GetLogExecSpCriteria();
    }
}