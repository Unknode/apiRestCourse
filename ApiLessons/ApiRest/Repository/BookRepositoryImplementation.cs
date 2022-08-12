using ApiRest.Model;
using ApiRest.Repository.Interfaces;
using System.Collections.Generic;
using ApiRest.Model.Context;
using System.Linq;

namespace ApiRest.Repository
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private readonly MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            if (book == null)
                return null;

            _context.Add(book);
            _context.SaveChanges();

            return book;
        }

        public void Delete(int id)
        {
            if (id == 0)
                return;

            _context.Remove(GetBook(id));
            _context.SaveChanges();

        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book GetBook(int id)
        {
            if (id == 0)
                return null;

            return _context.Books.SingleOrDefault(p => p.Id == id);
        }

        public void Update(Book book)
        {
            if (book == null)
                return;

            Book dbBook = _context.Books.FirstOrDefault(x => x.Id == book.Id);
            if (dbBook == null)
                return;

            _context.Entry(dbBook).CurrentValues.SetValues(book);
            _context.SaveChanges();
        }
    }
}
