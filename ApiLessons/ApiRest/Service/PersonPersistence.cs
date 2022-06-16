using ApiRest.Model;
using System.Collections.Generic;

namespace ApiRest.Service
{
    public class PersonPersistence : IPersonPersistence
    {
        private static MockedPersonData _data = new MockedPersonData();
        public Person Create(Person person)
        {
            if (person == null)
                return null;

            _data.PersonList.Add(person);

            return person;
        }
        public List<Person> FindAll()
        {
            return _data.GetPeopleList();
        }
        public Person Update(Person person)
        {
            if (person == null)
                return null;

            return person;
        }
        public void Delete(int id)
        {
            if (id == 0)
                return;

            _data.PersonList.RemoveAll(x => x.Id == id);
        }

        public Person GetPerson(int id)
        {
            if (id == 0)
                return null;

            return _data.PersonList.Find(x => x.Id == id);
        }
    }

}
