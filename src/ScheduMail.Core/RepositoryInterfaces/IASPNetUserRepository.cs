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
    }
}
