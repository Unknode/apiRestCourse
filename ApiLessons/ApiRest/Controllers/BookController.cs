using ApiRest.Data.VO;
using ApiRest.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class BookController : ControllerBase
    {
        private IBookBusiness _bookPersistence;

        public BookController (IBookBusiness bookBusiness)
        {
            _bookPersistence = bookBusiness;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                return Ok(_bookPersistence.FindAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id))
                    return BadRequest("Empty value");

                if (!int.TryParse(id, out int idValue))
                    return BadRequest("Incorrect value");

                return Ok(_bookPersistence.GetBook(int.Parse(id)));
            }
            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateNewBook([FromBody] BookVO book)
        {
            try
            {
                if (book == null)
                    return BadRequest("Null value");

                _bookPersistence.Create(book);

                return Ok("Book successfully created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public IActionResult UpdateBook([FromBody] BookVO book)
        {
            try
            {
                if (book == null)
                    return BadRequest("Null value");

                _bookPersistence.Update(book);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id))
                    return BadRequest();

                if (!int.TryParse(id, out int idValue))
                    return BadRequest("Incorrect value");

                _bookPersistence.Delete(int.Parse(id));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
