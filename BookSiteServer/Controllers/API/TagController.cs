using BookSiteServer.Data;
using BookSiteServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookSiteServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagData db = new TagData();

        [HttpPost]
        [Route("addTag")]
        public async Task<ActionResult<bool>> AddTag(Tag tag)
        {
            try
            {
                bool tmp = await db.AddTagAsync(tag);
                if (tmp == true)
                { GC.Collect(); return Ok(true); }
                else
                { GC.Collect(); return BadRequest(false); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                GC.Collect(); return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("updateTag")]
        public async Task<ActionResult<bool>> UpdateTag(Tag tag)
        {
            try
            {
                bool tmp = await db.UpdateTagAsync(tag);
                if (tmp == true)
                { GC.Collect(); return Ok(true); }
                else
                { GC.Collect(); return BadRequest(false); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                GC.Collect(); return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("addBook")]
        public async Task<ActionResult<bool>> AddBook(string name, Book book)
        {
            try
            {
                bool tmp = await db.UpdateTagAsync(book, name);
                if (tmp == true)
                { GC.Collect(); return Ok(true); }
                else
                { GC.Collect(); return BadRequest(false); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                GC.Collect(); return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("getTagById/{id:int}")]
        public async Task<ActionResult<bool>> GetTagById(int id)
        {
            try
            {
                Tag tmp = await db.GetTagAsync(id);
                if (tmp != null && tmp is Tag)
                { GC.Collect(); return Ok(tmp); }
                else
                { GC.Collect(); return NoContent(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                GC.Collect(); return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("getTagByName/{name}")]
        public async Task<ActionResult<bool>> GetTagByName(string name)
        {
            try
            {
                Tag tmp = await db.GetTagAsync(name);
                if (tmp != null && tmp is Tag)
                { GC.Collect(); return Ok(tmp); }
                else
                { GC.Collect(); return NoContent(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                GC.Collect(); return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("getTagBooksById/{id:int}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetTagBooksById(int id)
        {
            try
            {
                IEnumerable<Book> tmp = await db.GetBooksAsync(id);
                if (tmp != null && tmp.Any())
                { GC.Collect(); return Ok(tmp); }
                else
                { GC.Collect(); return NoContent(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                GC.Collect(); return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("getTagBooksByName/{name}")]
        public async Task<ActionResult<bool>> GetTagBooksByName(string name)
        {
            try
            {
                IEnumerable<Book> tmp = await db.GetBooksAsync(name);
                if (tmp != null && tmp.Any())
                { GC.Collect(); return Ok(tmp); }
                else
                { GC.Collect(); return NoContent(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                GC.Collect(); return StatusCode(500);
            }
        }
    }
}
