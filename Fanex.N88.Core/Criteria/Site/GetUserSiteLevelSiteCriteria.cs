namespace Fanex.N88.Core.Criteria.Site
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get user site level criteria.
    /// </summary>
    public class GetUserSiteLevelSiteCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public int SiteId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "N88_Site_GetUserSiteLevel";
        }

        /// <summary>
        /// Check data constraints.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}