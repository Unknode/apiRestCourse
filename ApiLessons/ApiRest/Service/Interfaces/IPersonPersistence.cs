using ApiRest.Model;
using System.Collections.Generic;

namespace ApiRest.Service
{
    public interface IPersonPersistence
    {
        public Person GetPerson(int id);
        public Person Create(Person person);
        public List<Person> FindAll();
        public Person Update(Person person);
        public void Delete (int id);
    }
}
