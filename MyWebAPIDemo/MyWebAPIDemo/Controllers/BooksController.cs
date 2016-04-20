using MyWebAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebAPIDemo.Controllers
{
    public class BooksController : ApiController
    {
        static IEnumerable<Book> _books = new BooksRepository().GetBooks();

        // GET: api/Books
        public IEnumerable<Book> Get()
        {
            return _books;
        }

        // GET: api/Books/5
        public Book Get(int id)
        {
            return _books.Single(b => b.BookId == id);
        }

        // POST: api/Books
        public void Post([FromBody]Book value)
        {
        }

        // PUT: api/Books/5
        public void Put(int id, [FromBody]Book value)
        {
        }

        // DELETE: api/Books/5
        public void Delete(int id)
        {
        }
    }
}
