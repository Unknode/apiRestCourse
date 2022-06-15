using System.Collections.Generic;
namespace ApiRest.Model
{
    public class MockedPersonData
    {
        public List<Person> PersonList { get; set; } = new List<Person>();

        public MockedPersonData ()
        {
            PersonList.Add(new Person
            {
                Id = 1,
                Name = "Carlos",
                LastName = "Menta"
            });

            PersonList.Add(new Person
            {
                Id = 2,
                Name = "Kauã",
                LastName = "Menta"
            });

            PersonList.Add(new Person
            {
                Id = 3,
                Name = "Marcio",
                LastName = "Menta"
            });
        }

        public List<Person> GetPeopleList ()
        {
            return PersonList;
        }
    }
}
