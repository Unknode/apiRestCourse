using ApiRest.Data.Converter.Contract;
using ApiRest.Data.VO;
using ApiRest.Model;
using System.Collections.Generic;

namespace ApiRest.Data.Converter.Implementations
{
    public class BookParser : IParser<Book, BookVO>, IParser<BookVO, Book>
    {
        public BookVO Parse(Book source)
        {
            if (source == null)
                return null;

            return new BookVO
            {
                Author = source.Author,
                Date = source.Date,
                Title = source.Title,
                Id = source.Id
            };
        }

        public List<BookVO> Parse(List<Book> source)
        {
            if (source == null || source.Count == 0)
                return null;
            
            List<BookVO> books = new List<BookVO>();

            foreach (Book book in source)
            {
                books.Add(Parse(book));
            }

            return books;
        }

        public Book Parse(BookVO source)
        {
            if (source == null)
                return null;

            return new Book
            {
                Author = source.Author,
                Date = source.Date,
                Title = source.Title,
                Id = source.Id
            };
        }

        public List<Book> Parse(List<BookVO> source)
        {
            if (source == null || source.Count == 0)
                return null;

            List<Book> books = new List<Book>();

            foreach (BookVO book in source)
            {
                books.Add(Parse(book));
            }

            return books;
        }
    }
}
