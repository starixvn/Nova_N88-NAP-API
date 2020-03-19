namespace Fanex.N88.Core.Service.Impl
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Fanex.Common.Helper;
    using Fanex.N88.Core.Business;
    using Fanex.N88.Core.Command;
    using Fanex.N88.Core.Criteria.Function;
    using Fanex.N88.Core.Criteria.Misc;
    using Fanex.N88.Core.Criteria.Site;
    using Fanex.N88.Core.Criteria.User;
    using Fanex.N88.Core.Domain;
    using Fanex.N88.Core.Model;
    using Fanex.N88.Core.Model.ValueObject;
    using Fanex.N88.Core.Repository.Impl;
    using Fanex.N88.Core.Repository.Interface;
    using Fanex.N88.Core.Service.Interface;

    public class SiteService : BaseService, ISiteService
    {
        #region members

        private readonly ISiteRepository _siteRepository;
        private readonly IFunctionRepository _functionRepository;

        #endregion members

        #region ctors

        public SiteService()
            : this(null, null)
        {
        }

        public SiteService(ISiteRepository siteRepository, IFunctionRepository functionRepository)
        {
            this._siteRepository = siteRepository ?? new SiteRepository();
            this._functionRepository = functionRepository ?? new FunctionRepository();
        }

        #endregion ctors

        #region get

        public ISite GetById(int id)
        {
            // check parammeters
            Check.Argument.IsNotNegativeOrZero(id, "id");

            var criteria = new GetByIdSiteCriteria
            {
                SiteId = id
            };

            if (criteria.IsValid())
            {
                return this._siteRepository.Get(criteria);
            }

            return null;
        }

        public ISite GetByName(string name)
        {
            // check parammeters
            Check.Argument.IsNotEmpty(name, "name");

            var criteria = new GetByNameSiteCriteria
            {
                SiteName = name
            };

            if (criteria.IsValid())
            {
                return this._siteRepository.Get(criteria);
            }

            return null;
        }

        public ISite GetByKey(string key)
        {
            // check parammeters
            Check.Argument.IsNotEmpty(key, "key");

            var criteria = new GetBySiteKeyCriteria
            {
                SiteKey = key
            };

            if (criteria.IsValid())
            {
                return this._siteRepository.Get(criteria);
            }

            return null;
        }

        public bool GetStatusById(int id)
        {
            // check parammeters
            Check.Argument.IsNotNegativeOrZero(id, "id");

            bool isActive = false;

            var criteria = new GetByIdSiteCriteria
            {
                SiteId = id
            };

            if (criteria.IsValid())
            {
                ISite site = this._siteRepository.Get(criteria);

                if (site != null)
                {
                    isActive = site.IsActive;
                }
            }

            return isActive;
        }

        public IEnumerable<SiteLevel> GetSiteLevelByUser(int userId, string env = Constant.Uat, bool? isActive = null)
        {
            // check parammeters
            Check.Argument.IsNotNegativeOrZero(userId, "userId");
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new GetByUserSiteCriteria
            {
                UserId = userId,
                Environment = env,
                IsActive = isActive
            };

            if (criteria.IsValid())
            {
                return this._siteRepository.FetchSiteLevel(criteria).OrderBy(sl => sl.Site.Name);
            }

            return null;
        }

        public IEnumerable<ISite> GetAvailableSitesForUser(int userId, string env = Constant.Uat, bool? isActive = null)
        {
            Check.Argument.IsNotNegativeOrZero(userId, "userId");

            var criteria = new GetAvailableSitesCriteria
            {
                UserId = userId,
                Environment = env,
                IsActive = isActive
            };

            if (criteria.IsValid())
            {
                return this._siteRepository.Fetch(criteria).OrderBy(site => site.Name);
            }

            return null;
        }

        public IEnumerable<ISite> GetAllSiteByType(GetSiteByTypeCriteria criteria)
        {
            Check.Argument.IsNotNull(criteria, "criteria");

            if (criteria.IsValid())
            {
                return this._siteRepository.Fetch(criteria).OrderBy(site => site.Name);
            }

            return null;
        }

        public IEnumerable<ISite> GetAll(string env = Constant.Uat, bool? isActive = null)
        {
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new GetAllSiteCriteria
            {
                Environment = env,
                IsActive = isActive
            };

            if (criteria.IsValid())
            {
                return this._siteRepository.Fetch(criteria).OrderBy(s => s.Name);
            }

            return null;
        }

        public IList<SelectListItem> GetAllSelectListItem(
            string env = Constant.Uat,
            bool? isActive = null,
            int selectedSiteId = 0)
        {
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new GetAllSiteCriteria
            {
                Environment = env,
                IsActive = isActive
            };

            if (criteria.IsValid())
            {
                IEnumerable<ISite> siteList = this._siteRepository.Fetch(criteria).OrderBy(s => s.Name);

                if (siteList != null)
                {
                    return siteList.Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.Id.ToString(),
                        Selected = s.Id == selectedSiteId
                    }).ToList();
                }
            }

            return null;
        }

        public IEnumerable<ISite> GetAllWithNumOfUsers(string env = Constant.Uat, bool? isActive = null)
        {
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new GetAllSiteWithNumOfUserCriteria
            {
                Environment = env,
                IsActive = isActive
            };

            if (criteria.IsValid())
            {
                return this._siteRepository.Fetch(criteria).OrderBy(s => s.Name);
            }

            return null;
        }

        public IEnumerable<ISite> GetByUserAndFunctionKeyIncludeGroup(
            int userId,
            string functionKey,
            string env = Constant.Uat,
            Constant.Policy policy = Constant.Policy.Read)
        {
            // check parameters
            Check.Argument.IsNotNegativeOrZero(userId, "UserId");
            Check.Argument.IsNotEmpty(functionKey, "FunctionKey");
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new GetByUserAndFunctionKeyIncludeGroupFunctionCriteria
            {
                UserId = userId,
                FunctionKey = functionKey,
                Environment = env
            };

            if (criteria.IsValid())
            {
                IEnumerable<FunctionPolicy> functionPolicyList = this._functionRepository.FetchFunctionPolicy(criteria).OrderBy(s => s.Site.Name);

                if (functionPolicyList != null)
                {
                    return functionPolicyList.Where(f => f.Policy >= (int)policy)
                        .Select(s => new Site
                        {
                            Id = s.Site.Id,
                            Name = s.Site.Name
                        }).ToList();
                }
            }

            return null;
        }

        public IList<SelectListItem> GetSelectListItemByUserAndFunctionKeyIncludeGroup(
            int userId,
            string functionKey,
            string env = Constant.Uat,
            Constant.Policy policy = Constant.Policy.Read,
            int selectedSiteId = 0)
        {
            // check parameters
            Check.Argument.IsNotNegativeOrZero(userId, "UserId");
            Check.Argument.IsNotEmpty(functionKey, "FunctionKey");
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new GetByUserAndFunctionKeyIncludeGroupFunctionCriteria
            {
                UserId = userId,
                FunctionKey = functionKey,
                Environment = env
            };

            if (criteria.IsValid())
            {
                IEnumerable<FunctionPolicy> functionPolicyList = this._functionRepository.FetchFunctionPolicy(criteria).OrderBy(s => s.Site.Name);

                if (functionPolicyList != null)
                {
                    return functionPolicyList.Where(f => f.Policy >= (int)policy)
                        .Select(s => new SelectListItem
                        {
                            Text = s.Site.Name,
                            Value = s.Site.Id.ToString(),
                            Selected = s.Site.Id == selectedSiteId
                        }).ToList();
                }
            }

            return null;
        }

        #endregion get

        #region insert/update

        public ICommandResult Insert(InsertSiteCriteria criteria)
        {
            // check parameters
            Check.Argument.IsNotNull(criteria, "criteria");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return this._siteRepository.Insert(criteria, logCriteria);
            }

            return null;
        }

        public ICommandResult Update(UpdateSiteCriteria criteria)
        {
            // check parameters
            Check.Argument.IsNotNull(criteria, "criteria");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return this._siteRepository.Update(criteria, logCriteria);
            }

            return null;
        }

        public ICommandResult UpdateStatus(UpdateStatusSiteCriteria criteria)
        {
            // check parameters
            Check.Argument.IsNotNull(criteria, "criteria");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return this._siteRepository.Update(criteria, logCriteria);
            }

            return null;
        }

        #endregion insert/update

        #region SiteLevel services

        public SiteLevel GetUserSiteLevel(int userId, int siteId)
        {
            Check.Argument.IsNotNegativeOrZero(userId, "userId");
            Check.Argument.IsNotNegativeOrZero(siteId, "siteId");

            var criteria = new GetUserSiteLevelSiteCriteria
            {
                UserId = userId,
                SiteId = siteId
            };

            if (criteria.IsValid())
            {
                return this._siteRepository.FetchSiteLevel(criteria).FirstOrDefault<SiteLevel>();
            }

            return null;
        }

        #endregion SiteLevel services

        #region SiteUrl services

        public IEnumerable<SiteUrl> GetAllSiteUrl(string env)
        {
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new GetAllSiteUrlCriteria
            {
                Environment = env
            };

            if (criteria.IsValid())
            {
                return this._siteRepository.FetchSiteUrl(criteria);
            }

            return null;
        }

        public IEnumerable<SiteUrl> GetSiteUrlByUser(int userId, string env)
        {
            Check.Argument.IsNotNegativeOrZero(userId, "userId");
            Check.Argument.IsNotEmpty(env, "Environment");

            var result = new List<SiteUrl>();

            var criteria = new GetSiteUrlByUserCriteria
            {
                UserId = userId,
                Environment = env
            };

            if (criteria.IsValid())
            {
                result = this._siteRepository.FetchSiteUrl(criteria).OrderBy(su => su.Site.Name).ToList();
            }

            return result;
        }

        public IEnumerable<SiteUrl> GetSiteUrlBySiteId(int siteId, string env)
        {
            Check.Argument.IsNotNegativeOrZero(siteId, "siteId");

            var result = new List<SiteUrl>();

            var criteria = new GetSiteUrlBySiteIdCriteria
            {
                SiteId = siteId,
                Environment = env
            };

            if (criteria.IsValid())
            {
                result = this._siteRepository.FetchSiteUrl(criteria).OrderBy(su => su.Site.Name).ToList();
            }

            return result;
        }

        public SiteUrl GetSiteUrlById(int siteUrlId)
        {
            Check.Argument.IsNotNegativeOrZero(siteUrlId, "siteUrlId");

            SiteUrl result = null;

            var criteria = new GetSiteUrlByIdCriteria
            {
                SiteUrlId = siteUrlId
            };

            if (criteria.IsValid())
            {
                result = this._siteRepository.GetSiteUrl(criteria);
            }

            return result;
        }

        public ICommandResult UpdateSiteUrl(UpdateSiteUrlCriteria criteria)
        {
            Check.Argument.IsNotNull(criteria, "criteria");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return this._siteRepository.Update(criteria, logCriteria);
            }

            return null;
        }

        public ICommandResult UpdateDefaultSiteUrl(UpdateDefaultSiteUrlCriteria criteria)
        {
            Check.Argument.IsNotNull(criteria, "criteria");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return this._siteRepository.Update(criteria, logCriteria);
            }

            return null;
        }

        public ICommandResult InsertSiteUrl(InsertSiteUrlCriteria criteria)
        {
            Check.Argument.IsNotNull(criteria, "criteria");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return this._siteRepository.InsertSiteUrl(criteria, logCriteria);
            }

            return null;
        }

        #endregion SiteUrl services
    }
}