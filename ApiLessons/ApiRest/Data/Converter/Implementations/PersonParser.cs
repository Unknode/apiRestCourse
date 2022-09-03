using ApiRest.Data.Converter.Contract;
using ApiRest.Data.VO;
using ApiRest.Model;
using System.Collections.Generic;

namespace ApiRest.Data.Converter.Implementations
{
    public class PersonParser : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO source)
        {
            if (source == null)
                return null;

            return new Person
            {
                Name = source.Name,
                Address = source.Address,
                Gender = source.Gender,
                LastName = source.LastName
            };
        }

        public List<Person> Parse(List<PersonVO> source)
        {
            if (source == null || source.Count == 0)
                return null;

            List<Person> persons = new List<Person>();
            foreach (PersonVO persoVO in source)
            {
                Person person = new Person
                {
                    Name = persoVO.Name,
                    LastName = persoVO.LastName,
                    Gender = persoVO.Gender,
                    Address = persoVO.Address
                };

                persons.Add(person);
            }
            return persons;
        }

        public PersonVO Parse(Person source)
        {
            if (source == null)
                return null;

            return new PersonVO
            {
                Address = source.Address,
                Gender = source.Gender,
                LastName = source.LastName,
                Name = source.Name
            };
        }

        public List<PersonVO> Parse(List<Person> source)
        {
            if (source == null || source.Count == 0)
                return null;

            List<PersonVO> persons = new List<PersonVO>();

            foreach (Person person in source)
            {
                PersonVO personVO = new PersonVO
                {
                    Name = person.Name,
                    LastName = person.LastName,
                    Address = person.Address,
                    Gender = person.Gender
                };
                persons.Add(personVO);
            }
            return persons;
        }
    }
}
