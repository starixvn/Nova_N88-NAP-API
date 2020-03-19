namespace Fanex.N88.Core.Service.Impl
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Fanex.Common.Helper;
    using Fanex.N88.Core.Business;
    using Fanex.N88.Core.Command;
    using Fanex.N88.Core.Criteria.MenuItem;
    using Fanex.N88.Core.Criteria.Misc;
    using Fanex.N88.Core.Domain;
    using Fanex.N88.Core.Repository.Impl;
    using Fanex.N88.Core.Repository.Interface;
    using Fanex.N88.Core.Service.Interface;

    public class MenuItemService : BaseService, IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService()
            : this(null)
        {
        }

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            this._menuItemRepository = menuItemRepository ?? new MenuItemRepository();
        }

        public IMenuItem GetById(int id)
        {
            // check parameters
            Check.Argument.IsNotNegativeOrZero(id, "Id");

            var criteria = new GetByIdMenuItemCriteria
            {
                MenuItemId = id
            };

            if (criteria.IsValid())
            {
                return this._menuItemRepository.Get(criteria);
            }

            return null;
        }

        public IMenuItem GetByKeyAndSite(string key, int siteId)
        {
            // check parameters
            Check.Argument.IsNotEmpty(key, "Key");
            Check.Argument.IsNotNegativeOrZero(siteId, "SiteId");

            var criteria = new GetByKeyAndSiteMenuItemCriteria
            {
                MenuItemKey = key,
                SiteId = siteId
            };

            if (criteria.IsValid())
            {
                return _menuItemRepository.Get(criteria);
            }

            return null;
        }

        public IMenuItem GetByNameAndSite(string name, int siteId)
        {
            // check parameters
            Check.Argument.IsNotEmpty(name, "Name");
            Check.Argument.IsNotNegativeOrZero(siteId, "SiteId");

            var criteria = new GetByNameAndSiteMenuItemCriteria
            {
                MenuItemName = name,
                SiteId = siteId
            };

            if (criteria.IsValid())
            {
                return this._menuItemRepository.Get(criteria);
            }

            return null;
        }

        public IEnumerable<IMenuItem> GetAll(string env = Constant.Uat, bool? isActive = null)
        {
            // check parameters
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new GetAllMenuItemCriteria
            {
                Environment = env,
                IsActive = isActive
            };

            if (criteria.IsValid())
            {
                return this._menuItemRepository.Fetch(criteria);
            }

            return null;
        }

        public IList<SelectListItem> GetAllSelectListItem(
            string env = Constant.Uat,
            bool? isActive = null,
            int selectedMenuItemId = 0)
        {
            // check parameters
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new GetAllMenuItemCriteria
            {
                Environment = env,
                IsActive = isActive
            };

            if (criteria.IsValid())
            {
                IEnumerable<IMenuItem> menuItemList = this._menuItemRepository.Fetch(criteria);

                if (menuItemList != null)
                {
                    return menuItemList.Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.Id.ToString(),
                        Selected = s.Id == selectedMenuItemId
                    }).ToList();
                }
            }

            return null;
        }

        public IEnumerable<IMenuItem> GetBySite(int siteId, string env = Constant.Uat, bool? isActive = null)
        {
            // check parameters
            Check.Argument.IsNotNegativeOrZero(siteId, "SiteId");
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new GetBySiteMenuItemCriteria
            {
                SiteId = siteId,
                Environment = env,
                IsActive = isActive
            };

            if (criteria.IsValid())
            {
                return this._menuItemRepository.Fetch(criteria);
            }

            return null;
        }

        public IList<SelectListItem> GetSelectListItemBySite(
            int siteId,
            string env = Constant.Uat,
            bool? isActive = null,
            int selectedMenuItemId = 0)
        {
            // check parameters
            Check.Argument.IsNotNegativeOrZero(siteId, "SiteId");
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new GetBySiteMenuItemCriteria
            {
                SiteId = siteId,
                Environment = env,
                IsActive = isActive
            };

            if (criteria.IsValid())
            {
                IEnumerable<IMenuItem> menuItemList = this._menuItemRepository.Fetch(criteria);

                if (menuItemList != null)
                {
                    return menuItemList.Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.Id.ToString(),
                        Selected = s.Id == selectedMenuItemId
                    }).ToList();
                }
            }

            return null;
        }

        public IEnumerable<IMenuItem> GetBySiteInHierarchy(int siteId, string env = Constant.Uat, bool? isActive = null)
        {
            // check parameters
            Check.Argument.IsNotNegativeOrZero(siteId, "SiteId");
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new GetBySiteMenuItemCriteria
            {
                SiteId = siteId,
                Environment = env,
                IsActive = isActive
            };

            if (criteria.IsValid())
            {
                IEnumerable<IMenuItem> menuItemList = this._menuItemRepository.Fetch(criteria).OrderBy(x => x.DisplayOrder);

                return this.SortMenuItemsInHierarchy(menuItemList);
            }

            return null;
        }

        public IEnumerable<IMenuItem> GetParentById(int id, string env = Constant.Uat)
        {
            // check parameters
            Check.Argument.IsNotNegativeOrZero(id, "Id");

            var criteria = new GetParentByIdMenuItemCriteria
            {
                MenuItemId = id,
                Environment = env
            };

            if (criteria.IsValid())
            {
                return this._menuItemRepository.Fetch(criteria);
            }

            return null;
        }

        public IList<SelectListItem> GetParentSelectListItemById(
            int id,
            int selectedMenuItemId = 0,
            string env = Constant.Uat)
        {
            // check parameters
            Check.Argument.IsNotNegativeOrZero(id, "Id");

            var criteria = new GetParentByIdMenuItemCriteria
            {
                MenuItemId = id,
                Environment = env
            };

            if (criteria.IsValid())
            {
                IEnumerable<IMenuItem> menuItemList = this._menuItemRepository.Fetch(criteria);

                if (menuItemList != null)
                {
                    return menuItemList.Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.Id.ToString(),
                        Selected = s.Id == selectedMenuItemId
                    }).ToList();
                }
            }

            return null;
        }

        public IEnumerable<IMenuItem> GetByUserAndSiteIncludeGroup(
            int userId,
            int siteId,
            string env = Constant.Uat,
            bool? isActive = null)
        {
            // check parameters
            Check.Argument.IsNotNegativeOrZero(userId, "UserId");
            Check.Argument.IsNotNegativeOrZero(siteId, "SiteId");
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new GetByUserAndSiteIncludeGroupMenuItemCriteria
            {
                UserId = userId,
                SiteId = siteId,
                Environment = env
            };

            if (criteria.IsValid())
            {
                return this._menuItemRepository.Fetch(criteria);
            }

            return null;
        }

        public IEnumerable<IMenuItem> Search(
            string menuItemName,
            int siteId,
            string env = Constant.Uat,
            bool? isActive = null)
        {
            // check parameters
            Check.Argument.IsNotEmpty(env, "Environment");

            var criteria = new SearchAllMenuItemCriteria
            {
                MenuItemName = menuItemName,
                SiteId = siteId,
                Environment = env,
                IsActive = isActive
            };

            if (criteria.IsValid())
            {
                return this._menuItemRepository.Fetch(criteria);
            }

            return null;
        }

        public ICommandResult Insert(InsertMenuItemCriteria criteria)
        {
            // check parameters
            Check.Argument.IsNotNull(criteria, "criteria");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return this._menuItemRepository.Insert(criteria, logCriteria);
            }

            return null;
        }

        public ICommandResult Update(UpdateMenuItemCriteria criteria)
        {
            // check parameters
            Check.Argument.IsNotNull(criteria, "criteria");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return this._menuItemRepository.Update(criteria, logCriteria);
            }

            return null;
        }

        public ICommandResult UpdateStatus(UpdateStatusMenuItemCriteria criteria)
        {
            // check parameters
            Check.Argument.IsNotNull(criteria, "criteria");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return this._menuItemRepository.Update(criteria, logCriteria);
            }

            return null;
        }

        private IEnumerable<IMenuItem> SortMenuItemsInHierarchy(IEnumerable<IMenuItem> menuItemList, int parentId = 0)
        {
            var sortedMenuItemList = new List<IMenuItem>();

            foreach (var menuItem in menuItemList)
            {
                // top menu items || sub menu items
                if ((menuItem.Parent == null && parentId == 0)
                    || (menuItem.Parent != null && menuItem.Parent.Id == parentId))
                {
                    sortedMenuItemList.Add(menuItem);
                    sortedMenuItemList.AddRange(this.SortMenuItemsInHierarchy(menuItemList, menuItem.Id));
                }
            }

            return sortedMenuItemList;
        }
    }
}