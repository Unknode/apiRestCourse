using ApiRest.Data.VO;
using System.Collections.Generic;
namespace ApiRest.Business.Interfaces
{
    public interface IBookBusiness
    {
        public BookVO GetBook(int id);
        public BookVO Create(BookVO book);
        public List<BookVO> FindAll();
        public void Update(BookVO book);
        public void Delete(int id);
    }
}
