using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.Domain;

namespace ScheduMail.Core.RepositoryInterfaces
{
    /// <summary>
    /// Test interface for Book repository.
    /// </summary>
    public interface IEBookRepository
    {
        /// <summary>
        /// Lists the ebook.
        /// </summary>
        /// <returns>IEnumerable list of Books.</returns>
        IEnumerable<Book> ListEbook();
    }
}
