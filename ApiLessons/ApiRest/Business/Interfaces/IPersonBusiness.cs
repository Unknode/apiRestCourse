using ApiRest.Model;
using System.Collections.Generic;

namespace ApiRest.Business
{
    public interface IPersonBusiness
    {
        public Person GetPerson(int id);
        public Person Create(Person person);
        public List<Person> FindAll();
        public void Update(Person person);
        public void Delete (int id);
    }
}
