namespace Fanex.N88.Core.Repository.Interface
{
    using System.Collections.Generic;
    using Fanex.Data.Repository;
    using Fanex.N88.Core.Command;
    using Fanex.N88.Core.Criteria.Site;
    using Fanex.N88.Core.Domain;
    using Fanex.N88.Core.Model.ValueObject;

    public interface ISiteRepository : IReadonlyRepository<ISite>
    {
        SiteUrl GetSiteUrl(ICriteria criteria);

        IEnumerable<SiteLevel> FetchSiteLevel(ICriteria criteria);

        IEnumerable<SiteUrl> FetchSiteUrl(ICriteria criteria);

        ICommandResult Insert(InsertSiteCriteria criteria, ICriteria logCriteria);

        ICommandResult InsertSiteUrl(InsertSiteUrlCriteria criteria, ICriteria logCriteria);

        ICommandResult Update(ICriteria criteria, ICriteria logCriteria);

        ICommandResult Delete(ICriteria criteria, ICriteria logCriteria);
    }
}