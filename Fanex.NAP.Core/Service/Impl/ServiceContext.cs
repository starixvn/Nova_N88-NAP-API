namespace Fanex.N88.Core.Service.Impl
{
    using Fanex.N88.Core.Service.Interface;

    /// <summary>
    /// Service context.
    /// </summary>
    public class ServiceContext : IServiceContext
    {
        public int UserId { get; set; }

        public int SiteId { get; set; }

        public string Ip { get; set; }
    }
}