namespace Fanex.N88.Core.Service.Interface
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Fanex.N88.Core.Business;
    using Fanex.N88.Core.Command;
    using Fanex.N88.Core.Criteria.Site;
    using Fanex.N88.Core.Domain;
    using Fanex.N88.Core.Model.ValueObject;

    public interface ISiteService : IBaseService
    {
        ISite GetById(int id);

        ISite GetByName(string name);

        ISite GetByKey(string key);

        bool GetStatusById(int id);

        SiteLevel GetUserSiteLevel(int userId, int siteId);

        IEnumerable<SiteLevel> GetSiteLevelByUser(int userId, string env = Constant.Uat, bool? isActive = null);

        IEnumerable<ISite> GetAvailableSitesForUser(int userId, string env = Constant.Uat, bool? isActive = null);

        IEnumerable<ISite> GetAllSiteByType(GetSiteByTypeCriteria criteria);

        IEnumerable<ISite> GetAll(string env = Constant.Uat, bool? isActive = null);

        IList<SelectListItem> GetAllSelectListItem(
            string env = Constant.Uat,
            bool? isActive = null,
            int selectedSiteId = 0);

        IEnumerable<ISite> GetAllWithNumOfUsers(string env = Constant.Uat, bool? isActive = null);

        IEnumerable<ISite> GetByUserAndFunctionKeyIncludeGroup(
            int userId,
            string functionKey,
            string env = Constant.Uat,
            Constant.Policy policy = Constant.Policy.Read);

        IList<SelectListItem> GetSelectListItemByUserAndFunctionKeyIncludeGroup(
            int userId,
            string functionKey,
            string env = Constant.Uat,
            Constant.Policy policy = Constant.Policy.Read,
            int selectedSiteId = 0);

        ICommandResult Insert(InsertSiteCriteria criteria);

        ICommandResult Update(UpdateSiteCriteria criteria);

        ICommandResult UpdateStatus(UpdateStatusSiteCriteria criteria);

        #region SiteUrl services

        IEnumerable<SiteUrl> GetAllSiteUrl(string env);

        IEnumerable<SiteUrl> GetSiteUrlByUser(int userId, string env);

        IEnumerable<SiteUrl> GetSiteUrlBySiteId(int siteId, string env);

        SiteUrl GetSiteUrlById(int siteUrlId);

        ICommandResult UpdateSiteUrl(UpdateSiteUrlCriteria criteria);

        ICommandResult UpdateDefaultSiteUrl(UpdateDefaultSiteUrlCriteria criteria);

        ICommandResult InsertSiteUrl(InsertSiteUrlCriteria criteria);

        #endregion SiteUrl services
    }
}