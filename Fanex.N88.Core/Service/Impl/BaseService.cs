namespace Fanex.N88.Core.Service.Impl
{
    using System;
    using System.Collections.Generic;
    using Fanex.Common.Helper;
    using Fanex.Data.Repository;
    using Fanex.N88.Core.Criteria.Misc;
    using Fanex.N88.Core.Service.Interface;

    /// <summary>
    /// Base service.
    /// </summary>
    public class BaseService : IBaseService
    {
        private readonly IDynamicRepository _dynamicRepository;

        public BaseService(IDynamicRepository dynamicRepository = null)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public IServiceContext ServiceContext { get; set; }

        /// <summary>
        /// Gets the list data.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns>The list data.</returns>
        public virtual IEnumerable<T> GetData<T>(ICriteria criteria)
        {
            Check.Argument.IsNotNull(criteria, "criteria");

            if (criteria.IsValid())
            {
                return _dynamicRepository.Fetch<T>(criteria);
            }

            return new List<T>();
        }

        /// <summary>
        /// Gets item that are satisfied the passed criteria.
        /// </summary>
        /// <typeparam name="T">Type of Object return.</typeparam>
        /// <param name="criteria">Criteria to Query DB.</param>
        /// <returns>Enumerable of Type T.</returns>
        public virtual T GetItem<T>(ICriteria criteria) where T : new()
        {
            Check.Argument.IsNotNull(criteria, "criteria");

            if (criteria.IsValid())
            {
                return _dynamicRepository.Get<T>(criteria);
            }

            return new T();
        }

        /// <summary>
        /// Get execute store procedure log criteria.
        /// </summary>
        /// <returns>Execute SP log criteria.</returns>
        public LogExecSpCriteria GetLogExecSpCriteria()
        {
            Check.Argument.IsNotNull(this.ServiceContext, "ServiceContext");

            return new LogExecSpCriteria
            {
                CurrentUserId = this.ServiceContext.UserId,
                CurrentSiteId = this.ServiceContext.SiteId,
                LogDate = DateTime.Now,
                LoginIp = this.ServiceContext.Ip
            };
        }
    }
}