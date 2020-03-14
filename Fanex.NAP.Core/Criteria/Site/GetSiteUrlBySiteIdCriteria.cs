namespace Fanex.N88.Core.Criteria.Site
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get site URL by site ID criteria.
    /// </summary>
    public class GetSiteUrlBySiteIdCriteria : CriteriaBase
    {
        public int SiteId { get; set; }

        public string Environment { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "N88_Site_GetSiteURLBySiteId";
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