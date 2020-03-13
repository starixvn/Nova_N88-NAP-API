namespace Fanex.NAP.Core.Criteria.MenuItem
{
    using System.ComponentModel.DataAnnotations;
    using Fanex.Data.Repository;
    using Fanex.NAP.Core.Web;

    /// <summary>
    /// Get menu item by site criteria.
    /// </summary>
    public class GetBySiteMenuItemCriteria : CriteriaBase
    {
        [Required]
        [Display(Name = "Site", ResourceType = typeof(ViewResources))]
        public int SiteId { get; set; }

        [Display(Name = "Environment", ResourceType = typeof(ViewResources))]
        public string Environment { get; set; }

        public bool? IsActive { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "N88_MenuItem_GetBySite";
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