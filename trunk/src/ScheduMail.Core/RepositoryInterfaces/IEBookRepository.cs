using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.Domain;

namespace ScheduMail.Core.RepositoryInterfaces
{
    public interface IEBookRepository
    {
        IEnumerable<Book> ListEbook();
    }
}
