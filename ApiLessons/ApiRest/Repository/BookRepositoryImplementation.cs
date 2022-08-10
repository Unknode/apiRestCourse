using ApiRest.Model;
using ApiRest.Repository.Interfaces;
using System.Collections.Generic;
using ApiRest.Model.Context;

namespace ApiRest.Repository
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private readonly MySQLContext _context;
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
            throw new System.NotImplementedException();
        }

        public List<Book> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Book GetPerson(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Book book)
        {
            throw new System.NotImplementedException();
        }
    }
}
