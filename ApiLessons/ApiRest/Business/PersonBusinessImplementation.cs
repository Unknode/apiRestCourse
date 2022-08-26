using ApiRest.Model.Context;
using ApiRest.Model;
using System.Collections.Generic;
using System.Linq;
using ApiRest.Repository;
using ApiRest.Repository.Generic;

namespace ApiRest.Business
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;

        public PersonBusinessImplementation(IRepository<Person> repository)
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
            return _repository.GetItem(id);
        }
    }

}
