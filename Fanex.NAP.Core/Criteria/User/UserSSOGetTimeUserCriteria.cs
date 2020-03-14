namespace Fanex.N88.Core.Criteria.User
{
    using System;
    using Fanex.Data.Repository;

    /// <summary>
    /// SSO get time user criteria.
    /// </summary>
    public class UserSSOGetTimeUserCriteria : CriteriaBase
    {
        public DateTime Time { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "N88_User_SSOGetTime";
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