namespace Fanex.N88.Core.Criteria.Group
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get group by name criteria.
    /// </summary>
    public class GetByNameGroupCriteria : CriteriaBase
    {
        public string GroupName { get; set; }

        public bool IsLicenseeGroup { get; set; }

        public int SiteId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "N88_Group_GetByName";
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