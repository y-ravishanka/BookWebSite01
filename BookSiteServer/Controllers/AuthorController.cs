using BookSiteServer.Models;
using BookSiteServer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookSiteServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorData db = new AuthorData();

        [HttpPost]
        [Route("addAuthor")]
        public async Task<ActionResult<bool>> AddAuthor(Author author)
        {
            try
            {
                bool t = await db.AddAuthorAsync(author);
                if (t == true)
                { return Ok(true); }
                else
                { return BadRequest(false); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("updateAuthorName")]
        public async Task<ActionResult<bool>> UpdateAuthorName(string id, string name)
        {
            try
            {
                bool t = await db.UpdateAuthorAsync(Guid.Parse(id), name);
                if (t == true)
                { return Ok(true); }
                else
                { return BadRequest(false); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("updateAuthorAltName/{id}")]
        public async Task<ActionResult<bool>> UpdateAuthorAltName(string id, AuthorName name)
        {
            try
            {
                bool t = await db.UpdateAuthorAsync(Guid.Parse(id), name);
                if (t == true)
                { return Ok(true); }
                else
                { return BadRequest(false); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("addAuthorBook/{id}")]
        public async Task<ActionResult<bool>> AddAuthorBook(string id, Book book)
        {
            try
            {
                bool t = await db.UpdateAuthorAsync(Guid.Parse(id), book);
                if (t == true)
                { return Ok(true); }
                else
                { return BadRequest(false); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("getAuthorById/{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(string id)
        {
            try
            {
                Author author = await db.GetAuthorAsync(Guid.Parse(id));
                if (author != null && author is Author)
                { return Ok(author); }
                else
                { return NoContent(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("getAuthorByName/{name}")]
        public async Task<ActionResult<Author>> GetAuthorByName(string name)
        {
            try
            {
                Author author = await db.GetAuthorAsync(name);
                if (author != null && author is Author)
                { return Ok(author); }
                else
                { return NoContent(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                return StatusCode(500);
            }
        }


        [HttpGet]
        [Route("getAuthorBookByName/{name}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAuthorBookByName(string name)
        {
            try
            {
                IEnumerable<Book> book = await db.GetBooksAsync(name);
                if (book != null && book.Any())
                { return Ok(book); }
                else
                { return NoContent(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("getAuthorBookById/{id}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAuthorBookById(string id)
        {
            try
            {
                IEnumerable<Book> book = await db.GetBooksAsync(Guid.Parse(id));
                if (book != null && book.Any())
                { return Ok(book); }
                else
                { return NoContent(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                return StatusCode(500);
            }
        }
    }
}
