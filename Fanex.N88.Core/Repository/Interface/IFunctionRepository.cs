namespace Fanex.N88.Core.Repository.Interface
{
    using System.Collections.Generic;
    using Fanex.Data.Repository;
    using Fanex.N88.Core.Command;
    using Fanex.N88.Core.Criteria.Function;
    using Fanex.N88.Core.Domain;
    using Fanex.N88.Core.Model.ValueObject;

    public interface IFunctionRepository : IReadonlyRepository<IFunction>
    {
        IEnumerable<FunctionPolicy> FetchFunctionPolicy(ICriteria criteria);

        IEnumerable<FunctionPolicy> FetchFullFunctionPolicy(ICriteria criteria);

        ICommandResult Duplicate(DuplicateFunctionCriteria criteria, ICriteria logCriteria);

        ICommandResult CopyPermission(CopyPermissionCriteria criteria, ICriteria logCriteria);

        ICommandResult Insert(InsertFunctionCriteria criteria, ICriteria logCriteria);

        ICommandResult Update(ICriteria criteria, ICriteria logCriteria);

        ICommandResult Delete(ICriteria criteria, ICriteria logCriteria);
    }
}