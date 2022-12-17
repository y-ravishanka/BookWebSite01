using BookSiteServer.Models;

namespace BookSiteServer.Data
{
    internal interface IBooksData
    {
        Task<bool> AddBookAsync(Book book);

    }
}
