namespace Fanex.N88.Core.Criteria.User
{
    using System;
    using Fanex.Data.Repository;

    /// <summary>
    /// Assign site to user criteria.
    /// </summary>
    public class AssignSiteUserCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public int SiteId { get; set; }

        public int Level { get; set; }

        public bool IsActive { get; set; }

        public bool IsNeverExpired { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public override string GetSettingKey()
        {
            return "N88_User_AssignNewSite";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}