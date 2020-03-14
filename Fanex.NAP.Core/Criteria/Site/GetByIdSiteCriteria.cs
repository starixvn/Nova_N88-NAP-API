namespace Fanex.N88.Core.Criteria.Site
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get site by ID criteria.
    /// </summary>
    public class GetByIdSiteCriteria : CriteriaBase
    {
        public int SiteId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "N88_Site_GetById";
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