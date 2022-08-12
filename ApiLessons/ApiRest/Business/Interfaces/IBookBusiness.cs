using ApiRest.Model;
using System.Collections.Generic;
namespace ApiRest.Business.Interfaces
{
    public interface IBookBusiness
    {
        public Book GetBook(int id);
        public Book Create(Book book);
        public List<Book> FindAll();
        public void Update(Book book);
        public void Delete(int id);
    }
}
