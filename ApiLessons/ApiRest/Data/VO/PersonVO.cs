using System.ComponentModel.DataAnnotations.Schema;
using ApiRest.Model.Base;

namespace ApiRest.Data.VO
{
    public class PersonVO : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
