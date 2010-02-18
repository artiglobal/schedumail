using System.Collections.Generic;
using ScheduMail.Core.Domain;
using ScheduMail.Core.RepositoryInterfaces;

namespace ScheduMail.Core.FakeRepositories
{
    /// <summary>
    /// Fake Book Repository used to test IOC container
    /// </summary>
    public class FakeBookRepository : IEBookRepository
    {
        /// <summary>
        /// Lists the ebook.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> ListEbook()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book { ID = 1, Author = "Steven Sanderson", Name = "Pro ASP.NET MVC framewok" });
            books.Add(new Book { ID = 2, Author = "Stphan Waler", Name = "ASP.NET MVC framework Unleashed" });
            books.Add(new Book { ID = 3, Author = "Scott Guthrie", Name = "ASP.NET MVC 1.0" });           
            return books;
        }
    }
}
