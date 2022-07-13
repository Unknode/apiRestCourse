using ApiRest.Model.Context;
using ApiRest.Model;
using System.Collections.Generic;
using System.Linq;

namespace ApiRest.Service
{
    public class PersonPersistence : IPersonPersistence
    {
        private MySQLContext _context = new MySQLContext();

        public PersonPersistence (MySQLContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            if (person == null)
                return null;

            _context.Add(person);
            _context.SaveChanges();

            return person;
        }
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }
        public void Update(Person person)
        {
            if (person == null)
                return;

           _context.Persons.Update(person);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            if (id == 0)
                return;

            _context.Persons.Remove(GetPerson(id));
            _context.SaveChanges();
        }

        public Person GetPerson(int id)
        {
            if (id == 0)
                return null;

            return _context.Persons.SingleOrDefault(p => p.Id == id);
        }
    }

}
