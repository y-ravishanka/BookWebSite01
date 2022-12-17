using BookSiteServer.Data;
using BookSiteServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BookSiteServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly IChaptersData db = new ChaptersData();

        [HttpGet]
        [Route("getChapterById/{id}")]
        public async Task<ActionResult<Chapter>> GetChapterById(string id)
        {
            try
            {
                Chapter chapter = await db.GetChapterAsync(Guid.Parse(id));
                if (chapter != null && chapter is Chapter)
                { GC.Collect(); return Ok(chapter); }
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
        [Route("getChapter")]
        public async Task<ActionResult<Chapter>> GetChapter(string title, string id)
        {
            try
            {
                Chapter chapter = await db.GetChapterAsync(title, Guid.Parse(id));
                if (chapter != null && chapter is Chapter)
                { GC.Collect(); return Ok(chapter); }
                else
                { GC.Collect(); return NoContent(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAPI Error: \n" + ex.ToString() + "\n");
                GC.Collect(); return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("addChapter/{id}")]
        public async Task<ActionResult<bool>> AddChapter(string id, Chapter chapter)
        {
            try
            {
                bool tmp = await db.AddChapterAsync(Guid.Parse(id), chapter);
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
        [Route("updateChapter")]
        public async Task<ActionResult<bool>> UpdateChapter(Chapter chapter)
        {
            try
            {
                bool tmp = await db.UpdateChapterAsync(chapter);
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
    }
}
