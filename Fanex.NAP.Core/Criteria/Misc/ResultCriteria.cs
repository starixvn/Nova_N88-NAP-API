namespace Fanex.N88.Core.Criteria.Misc
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Result criteria.
    /// </summary>
    public class ResultCriteria : CriteriaBase
    {
        public ResultCriteria()
        {
            this.ErrCode = 0;
            this.ErrMsg = string.Empty;
        }

        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }
    }
}