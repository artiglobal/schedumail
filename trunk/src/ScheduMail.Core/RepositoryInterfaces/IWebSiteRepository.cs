using ScheduMail.DBModel;

namespace ScheduMail.Core.RepositoryInterfaces
{
    /// <summary>
    /// IWeb site repository to define web site ad store web site template details
    /// </summary>
    public interface IWebSiteRepository : ICrudRepository<WebSite, int>
    {
    }
}
