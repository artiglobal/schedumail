using System.Collections.Generic;
using System.Linq;
using ScheduMail.Core.Domain;

namespace ScheduMail.Core.RepositoryInterfaces
{
    /// <summary>
    /// Log Event Repository used for persietence of Log Files.
    /// </summary>
    public interface IASPNetUserRepository : ICrudRepository<AspnetUsers, string>
    {
        /// <summary>
        /// Lists the by web site id.
        /// </summary>
        /// <param name="id">The identification value.</param>
        /// <returns>List of Web Sites.</returns>
        IQueryable<ScheduMail.Core.Domain.AspnetUsers> ListByWebSiteId(long id);

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="user">The user instance.</param>
        /// <param name="isAdministrator">if set to <c>true</c> [is administrator].</param>
        /// <param name="selectedWebSites">The selected web sites.</param>
        /// <returns>Saved user instance.</returns>
        ScheduMail.Core.Domain.AspnetUsers Save(AspnetUsers user, bool isAdministrator, string[] selectedWebSites);
    }
}
