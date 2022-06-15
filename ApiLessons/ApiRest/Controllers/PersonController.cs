using ApiRest.Model;
using ApiRest.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonPersistence _personPersistence = new PersonPersistence();

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return Ok(_personPersistence.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetPerson(string id)
        {
            return Ok(_personPersistence.GetPerson(int.Parse(id)));
        }

        [HttpPost]
        public IActionResult CreateNewPerson([FromBody]Person person)
        {
            return Ok(_personPersistence.Create(person));
        }

        [HttpPut]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            return Ok(_personPersistence.Update(person));
        }

        [HttpDelete]
        public IActionResult DeletePerson([FromBody] string id)
        {
            if (String.IsNullOrEmpty(id))
                return BadRequest();

            _personPersistence.Delete(int.Parse(id));
            return Ok();
        }

    }
}
