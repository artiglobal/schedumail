using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.Domain;

namespace ScheduMail.Core.RepositoryInterfaces
{
    /// <summary>
    /// Provides a standard interface for Schedul operations
    /// </summary>
    public interface IMailRespository : ICrudRepository<Mail, long>
    {        
    }
}
