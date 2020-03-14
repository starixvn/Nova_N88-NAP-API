namespace Fanex.N88.Core.Repository.Interface
{
    using System.Collections.Generic;
    using Fanex.Data.Repository;
    using Fanex.N88.Core.Command;
    using Fanex.N88.Core.Criteria.Group;
    using Fanex.N88.Core.Domain;
    using Fanex.N88.Core.Model.ValueObject;

    public interface IGroupRepository : IReadonlyRepository<IGroup>
    {
        ICommandResult Insert(InsertGroupCriteria criteria, ICriteria logCriteria);

        ICommandResult Update(ICriteria criteria, ICriteria logCriteria);

        ICommandResult Delete(ICriteria criteria, ICriteria logCriteria);

        IEnumerable<GroupPolicy> GetGroupPolicy(ICriteria criteria);
    }
}