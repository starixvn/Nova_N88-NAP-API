namespace Fanex.N88.Core.Criteria.User
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get all user criteria.
    /// </summary>
    public class GetAllUserCriteria : CriteriaBase
    {
        public bool IsLicenseeSite { get; set; }

        public int? SiteId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "N88_User_GetAll";
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