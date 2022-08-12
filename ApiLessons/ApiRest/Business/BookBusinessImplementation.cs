using ApiRest.Business.Interfaces;
using ApiRest.Model;
using System.Collections.Generic;
using ApiRest.Repository.Interfaces;

namespace ApiRest.Business
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IBookRepository _bookRepository;

        public BookBusinessImplementation (IBookRepository bookRepository)
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

            return _bookRepository.GetBook(id);
        }

        public void Update(Book book)
        {
            if (book == null)
                return;

            _bookRepository.Update(book);
        }
    }
}
