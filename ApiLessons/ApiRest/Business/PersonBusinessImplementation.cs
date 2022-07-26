using ApiRest.Model.Context;
using ApiRest.Model;
using System.Collections.Generic;
using System.Linq;
using ApiRest.Repository;

namespace ApiRest.Business
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
        public void Update(Person person)
        {
            _repository.Update(person);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Person GetPerson(int id)
        {
            return _repository.GetPerson(id);
        }
    }

}
