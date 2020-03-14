namespace Fanex.N88.Core.Criteria.Site
{
    using Fanex.Data.Repository;
    using Fanex.N88.Core.Business;

    /// <summary>
    /// Get all site criteria.
    /// </summary>
    public class GetAllSiteCriteria : CriteriaBase
    {
        public GetAllSiteCriteria()
        {
            this.Environment = Constant.Uat;
        }

        public string Environment { get; set; }

        public bool? IsActive { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "N88_Site_GetAll";
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