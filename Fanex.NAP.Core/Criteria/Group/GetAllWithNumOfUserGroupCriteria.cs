namespace Fanex.N88.Core.Criteria.Group
{
    using System.ComponentModel.DataAnnotations;
    using Fanex.Data.Repository;
    using Fanex.N88.Core.Web;

    /// <summary>
    /// Get all group with number of user criteria.
    /// </summary>
    public class GetAllWithNumOfUserGroupCriteria : CriteriaBase
    {
        public bool? IsActive { get; set; }

        [Display(Name = "Group_Name", ResourceType = typeof(ViewResources))]
        [StringLength(50, MinimumLength = 0,
            ErrorMessageResourceName = "InputLengthValidationMsg",
            ErrorMessageResourceType = typeof(ViewResources))]
        public string GroupName { get; set; }

        public string Environment { get; set; }

        public bool IsLicenseeGroup { get; set; }

        public int? SiteId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "N88_Group_GetAllWithNumOfUser";
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