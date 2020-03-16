namespace Fanex.N88.Core.Criteria.Function
{
    using System;
    using Fanex.Data.Repository;

    /// <summary>
    /// Update function status criteria.
    /// </summary>
    public class UpdateStatusFunctionCriteria : CriteriaBase
    {
        public int FunctionId { get; set; }

        public bool IsActive { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "N88_Function_UpdateStatus";
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