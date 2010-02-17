using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.Domain;
using ScheduMail.Core.RepositoryInterfaces;

namespace ScheduMail.Core.FakeRepositories
{
    public class FakeBookRepository : IEBookRepository
    {
        private string dummy;
        public IEnumerable<Book> ListEbook()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book { ID = 1, Author = "Steven Sanderson", Name = "Pro ASP.NET MVC framewok" });
            books.Add(new Book { ID = 2, Author = "Stphan Waler", Name = "ASP.NET MVC framework Unleashed" });
            books.Add(new Book { ID = 3, Author = "Scott Guthrie", Name = "ASP.NET MVC 1.0" });
            dummy = "Test this ..";
            return books;
        }
    }
}
