namespace Fanex.N88.Core.Service.Interface
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Fanex.N88.Core.Business;
    using Fanex.N88.Core.Command;
    using Fanex.N88.Core.Criteria.Group;
    using Fanex.N88.Core.Domain;
    using Fanex.N88.Core.Model.ValueObject;

    public interface IGroupService : IBaseService
    {
        IGroup GetByUser(int userId);

        IGroup GetById(int id);

        IGroup GetByName(string name);

        IEnumerable<IGroup> GetAll(bool? isActive = null, bool isLicenseeGroup = true, int? siteId = null);

        /// <summary>
        /// Searches group by group name,site, but excludes ones who was assigned
        /// the function (functionId) already.
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <param name="siteId">The site ID.</param>
        /// <param name="functionId">The function ID.</param>
        /// <returns>List of group.</returns>
        IEnumerable<IGroup> SearchGroupExcludeFunction(string groupName, int siteId = 0, int functionId = 0);

        IList<SelectListItem> GetAllSelectListItem(bool? isActive = null, int selectedGroupId = 0);

        IEnumerable<GroupPolicy> GetByFunctionAndSite(int functionId, int siteId = 0);

        IEnumerable<IGroup> GetAllWithNumOfUser(string name, string env = Constant.Uat, bool? isActive = null);

        ICommandResult AssignFunction(AssignFunctionGroupCriteria criteria);

        ICommandResult UpdateStatus(UpdateStatusGroupCriteria criteria);

        ICommandResult Insert(InsertGroupCriteria criteria);

        ICommandResult Update(UpdateGroupCriteria criteria);
    }
}