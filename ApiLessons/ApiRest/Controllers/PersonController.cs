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

        private IPersonPersistence _personPersistence;

        public PersonController (IPersonPersistence personPersistence)
        {
            _personPersistence = personPersistence;
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            try
            {
                return Ok(_personPersistence.FindAll());
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPerson(string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id))
                    return BadRequest("Empty value");

                if (!int.TryParse(id, out int idValue))
                    return BadRequest("Incorrect value");

                return Ok(_personPersistence.GetPerson(int.Parse(id)));
            }
            catch (Exception ex)

            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateNewPerson([FromBody]Person person)
        {
            if (person==null)
                return BadRequest("Null value");

            _personPersistence.Create(person);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            if (person == null)
                return BadRequest("Null value");

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(string id)
        {
            if (String.IsNullOrEmpty(id))
                return BadRequest();

            if(!int.TryParse(id, out int idValue))
                return BadRequest("Incorrect value");

            _personPersistence.Delete(int.Parse(id));

            return Ok();
        }

    }
}
