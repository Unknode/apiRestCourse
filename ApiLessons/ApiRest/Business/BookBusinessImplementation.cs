using ApiRest.Business.Interfaces;
using ApiRest.Model;
using System.Collections.Generic;
using ApiRest.Repository.Generic;
using ApiRest.Data.Converter.Contract;
using ApiRest.Data.VO;

namespace ApiRest.Business
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _bookRepository;
        private IParser<Book,BookVO> _bookParser;
        private IParser<BookVO, Book> _bookVOParser;

        public BookBusinessImplementation (IRepository<Book> bookRepository, IParser<Book, BookVO> bookParser, IParser<BookVO, Book> bookVOParser)
        {
            _bookRepository = bookRepository;
            _bookParser = bookParser;
            _bookVOParser = bookVOParser;
        }
        public BookVO Create(BookVO book)
        {
            if (book == null)
                return null;

            Book convertedBook = _bookVOParser.Parse(book);

            return _bookParser.Parse(_bookRepository.Create(convertedBook));
        }

        public void Delete(int id)
        {
            if (id == 0)
                return;

            _bookRepository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _bookParser.Parse(_bookRepository.FindAll());
        }

        public BookVO GetBook(int id)
        {
            if (id == 0)
                return null;

            return _bookParser.Parse(_bookRepository.GetItem(id));
        }

        public void Update(BookVO book)
        {
            if (book == null)
                return;

            _bookRepository.Update(_bookVOParser.Parse(book));
        }
    }
}
