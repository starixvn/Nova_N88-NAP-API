namespace Fanex.N88.Core.Repository.Interface
{
    using Fanex.Data.Repository;
    using Fanex.N88.Core.Command;
    using Fanex.N88.Core.Criteria.MenuItem;
    using Fanex.N88.Core.Domain;

    public interface IMenuItemRepository : IReadonlyRepository<IMenuItem>
    {
        ICommandResult Insert(InsertMenuItemCriteria criteria, ICriteria logCriteria);

        ICommandResult Update(ICriteria criteria, ICriteria logCriteria);

        ICommandResult Delete(ICriteria criteria, ICriteria logCriteria);
    }
}