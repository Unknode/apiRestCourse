using System.Collections.Generic;
using ApiRest.Model.Base;

namespace ApiRest.Repository.Generic
{
    public interface IRepository <T> where T: BaseEntity
    {
        public T GetItem(int id);
        public T Create(T item);
        public List<T> FindAll();
        public void Update(T item);
        public void Delete(int id);
    }
}
