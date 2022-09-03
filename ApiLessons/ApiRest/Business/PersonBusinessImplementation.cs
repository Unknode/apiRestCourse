using ApiRest.Model;
using System.Collections.Generic;
using ApiRest.Repository.Generic;
using ApiRest.Data.VO;
using ApiRest.Data.Converter.Contract;


namespace ApiRest.Business
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private IParser <PersonVO, Person>_personVOParser;
        private IParser<Person, PersonVO>_personParser;

        public PersonBusinessImplementation(IRepository<Person> repository, IParser <PersonVO, Person> personVOParser, IParser<Person, PersonVO> personParser)
        {
            _repository = repository;
            _personVOParser = personVOParser;
            _personParser = personParser;
         }

        public PersonVO Create(PersonVO person)
        {
            Person convertedPerson = _personVOParser.Parse(person);
        
            return _personParser.Parse(_repository.Create(convertedPerson));
        }
        public List<PersonVO> FindAll()
        {
            return _personParser.Parse(_repository.FindAll());
        }
        public void Update(PersonVO person)
        {
            _repository.Update(person);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public PersonVO GetPerson(int id)
        {
            return _repository.GetItem(id);
        }
    }

}
