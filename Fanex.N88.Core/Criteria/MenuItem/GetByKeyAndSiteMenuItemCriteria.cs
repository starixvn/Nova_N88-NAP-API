namespace Fanex.N88.Core.Criteria.MenuItem
{
    using Fanex.Data.Repository;

    public class GetByKeyAndSiteMenuItemCriteria : CriteriaBase
    {
        public string MenuItemKey { get; set; }

        public int SiteId { get; set; }

        public override string GetSettingKey()
        {
            return "N88_MenuItem_GetByKeyAndSite";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}