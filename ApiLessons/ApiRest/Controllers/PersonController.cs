﻿using ApiRest.Model;
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

        public PersonController(IPersonPersistence personPersistence)
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
                return BadRequest(ex.Message);
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
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateNewPerson([FromBody] Person person)
        {
            try
            {
                if (person == null)
                    return BadRequest("Null value");

                _personPersistence.Create(person);

                return Ok("Person successfully created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            try
            {
                if (person == null)
                    return BadRequest("Null value");

                _personPersistence.Update(person);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id))
                    return BadRequest();

                if (!int.TryParse(id, out int idValue))
                    return BadRequest("Incorrect value");

                _personPersistence.Delete(int.Parse(id));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}