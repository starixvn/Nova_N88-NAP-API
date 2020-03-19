namespace Fanex.N88.Core.Criteria.Site
{
    using Fanex.Data.Repository;

    public class GetSiteByTypeCriteria : CriteriaBase
    {
        public bool IsLicenseeSite { get; set; }

        public bool? IsActive { get; set; }

        public override string GetSettingKey()
        {
            return "N88_Site_GetByType";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}