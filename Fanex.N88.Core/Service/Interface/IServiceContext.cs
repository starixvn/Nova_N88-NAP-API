namespace Fanex.N88.Core.Service.Interface
{
    public interface IServiceContext
    {
        int UserId { get; set; }

        int SiteId { get; set; }

        string Ip { get; set; }
    }
}