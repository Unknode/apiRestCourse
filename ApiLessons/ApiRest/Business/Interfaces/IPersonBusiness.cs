using ApiRest.Data.VO;
using ApiRest.Model;
using System.Collections.Generic;

namespace ApiRest.Business
{
    public interface IPersonBusiness
    {
        public PersonVO GetPerson(int id);
        public PersonVO Create(PersonVO person);
        public List<PersonVO> FindAll();
        public void Update(PersonVO person);
        public void Delete (int id);
    }
}
