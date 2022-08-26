using ApiRest.Business.Interfaces;
using ApiRest.Model;
using System.Collections.Generic;
using ApiRest.Repository.Generic;

namespace ApiRest.Business
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _bookRepository;

        public BookBusinessImplementation (IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Book Create(Book book)
        {
            if (book == null)
                return null;

            _bookRepository.Create(book);

            return book;
        }

        public void Delete(int id)
        {
            if (id == 0)
                return;

            _bookRepository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _bookRepository.FindAll();
        }

        public Book GetBook(int id)
        {
            if (id == 0)
                return null;

            return _bookRepository.GetItem(id);
        }

        public void Update(Book book)
        {
            if (book == null)
                return;

            _bookRepository.Update(book);
        }
    }
}
