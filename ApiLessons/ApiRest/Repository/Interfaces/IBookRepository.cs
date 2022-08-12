using ApiRest.Model;
using System.Collections.Generic;
namespace ApiRest.Repository.Interfaces
{
    public interface IBookRepository
    {
        public Book GetBook(int id);
        public Book Create(Book book);
        public List<Book> FindAll();
        public void Update(Book book);
        public void Delete(int id);
    }
}
