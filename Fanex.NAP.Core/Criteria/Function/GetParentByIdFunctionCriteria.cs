namespace Fanex.N88.Core.Criteria.Function
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Get parent function by ID criteria.
    /// </summary>
    public class GetParentByIdFunctionCriteria : CriteriaBase
    {
        public int FunctionId { get; set; }

        /// <summary>
        /// Get setting key.
        /// </summary>
        /// <returns>Setting key.</returns>
        public override string GetSettingKey()
        {
            return "N88_Function_GetParentById";
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