using System.Collections.Generic;
using ScheduMail.Core.Domain;

namespace ScheduMail.Core.RepositoryInterfaces
{
    /// <summary>
    /// IWeb site repository to define web site ad store web site template details
    /// </summary>
    public interface IWebSiteRepository : ICrudRepository<WebSite, long>
    {
        /// <summary>
        /// Gets the user E mails.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <returns>List of User EMails</returns>
        IList<UserEMails> GetUserEMails(int webSiteId);
    }
}
