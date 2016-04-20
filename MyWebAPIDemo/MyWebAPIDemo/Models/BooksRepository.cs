using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebAPIDemo.Models
{
    public class BooksRepository
    {
        public IEnumerable<Book> GetBooks() =>
            new List<Book>()
            {
                new Book { BookId = 1, Publisher = "Wrox Press", Title = "Professional C# 6" },
                new Book { BookId = 2, Publisher = "Self", Title = "C# 7 Programming" },
            };
        
    }
}
