using ApiRest.Model;
using System.Collections.Generic;

namespace ApiRest.Repository
{
    public interface IPersonRepository
    {
        public Person GetPerson(int id);
        public Person Create(Person person);
        public List<Person> FindAll();
        public void Update(Person person);
        public void Delete (int id);
    }
}
