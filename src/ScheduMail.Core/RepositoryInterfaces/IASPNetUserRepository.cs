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
    }
}
