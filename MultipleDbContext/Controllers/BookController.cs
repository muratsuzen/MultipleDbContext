using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultipleDbContext.Models;
using MultipleDbContext.Repository;

namespace MultipleDbContext.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [Route("{contextName}")]
        public List<Book> Get([FromRoute] string contextName)
        {
            var books = _bookRepository.Get(contextName);
            return books;
        }

        [HttpPost]
        [Route("{contextName}")]
        public IActionResult Post([FromRoute] string contextName,[FromBody] Book book)
        {
            try
            {
                _bookRepository.Add(book,contextName);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("{contextName}")]
        public IActionResult Put([FromRoute] string contextName, [FromBody] Book book)
        {
            try
            {
                _bookRepository.Update(book, contextName);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
