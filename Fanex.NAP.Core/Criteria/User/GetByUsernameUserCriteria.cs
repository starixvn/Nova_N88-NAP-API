namespace Fanex.N88.Core.Criteria.User
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get user by username criteria.
    /// </summary>
    public class GetByUsernameUserCriteria : CriteriaBase
    {
        public string Username { get; set; }

        public bool IsLicenseeSite { get; set; }

        public int? SiteId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "N88_User_GetByUsername";
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