using ApiRest.Model.Context;
using ApiRest.Model;
using System.Collections.Generic;
using System.Linq;

namespace ApiRest.Repository
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
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

            Person dbPerson = _context.Persons.FirstOrDefault(x => x.Id == person.Id);
            if (dbPerson == null)
                return;

            _context.Entry(dbPerson).CurrentValues.SetValues(person);
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
