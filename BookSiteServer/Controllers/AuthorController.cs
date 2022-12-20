using BookSiteServer.Data;
using BookSiteServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookSiteServer.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorData db = new AuthorData();

        private void DisplayExceptionMessage(string message)
        { Console.WriteLine("\nAuthorController Exception : \n###----------\n" + message + "\n"); }

        public async Task<IActionResult> Books(int id, string value)
        {
            Author author;
            if (id == 1)
            {
                try
                {
                    author = await db.GetAuthorAsync(Guid.Parse(value));
                }
                catch (Exception ex)
                {
                    DisplayExceptionMessage(ex.ToString());
                    author = null;
                }
            }
            else
            { author = await db.GetAuthorAsync(value); }
            if (author is null)
            { return Redirect("../Warning/NotFoundView"); }
            else
            { return View(); }
        }
    }
}
