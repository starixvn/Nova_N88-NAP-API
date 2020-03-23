namespace Fanex.N88.Core.Criteria.User
{
    using System.Collections.Generic;
    using System.Text;
    using System.Web.Mvc;
    using Data.Repository;

    public class GetAllByUsernameGroupSiteUserCriteria : CriteriaBase
    {
        private readonly string _siteTml = "<Site SiteId='{0}'></Site>";

        public string Username { get; set; }

        public int GroupId { get; set; }

        public string Site
        {
            get
            {
                if (ListSite != null)
                {
                    var value = new StringBuilder("<ROOT>");

                    foreach (SelectListItem siteId in ListSite)
                    {
                        value.AppendFormat(this._siteTml, siteId.Value); // 1 -> read
                    }

                    return value.Append("</ROOT>").ToString();
                }

                return string.Empty;
            }
        }

        [SpParam(Ignored = true)]
        public List<SelectListItem> ListSite { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalRows { get; set; }

        public int Status { get; set; }

        public string Environment { get; set; }

        public override string GetSettingKey()
        {
            return "N88_User_GetAllByUsernameGroupSite";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}