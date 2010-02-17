using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.DBModel;

namespace ScheduMail.Core.RepositoryInterfaces
{
    public interface IUserRepository : ICrudRepository<User, int>
    {        
    }
}
