using ApiRest.Repository.Generic;
using ApiRest.Model.Base;
using System.Collections.Generic;
using ApiRest.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiRest.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;
        private DbSet<T> dataSet;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }
        public T Create(T item)
        {
            if (item == null)
                return null;

            _context.Add(item);
            _context.SaveChanges();

            return item;
        }

        public void Delete(int id)
        {
            if (id == 0)
                return;

            _context.Remove(GetItem(id));
            _context.SaveChanges();
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T GetItem(int id)
        {
            if (id == 0)
                return null;

            return dataSet.SingleOrDefault(item => item.Id == id);
        }

        public void Update(T item)
        {
            if(item == null)
                return;

            var dbItem = dataSet.FirstOrDefault(x => x.Id == item.Id);
            if (dbItem == null)
                return;

            _context.Entry(dbItem).CurrentValues.SetValues(item);
            _context.SaveChanges();
        }
    }
}
