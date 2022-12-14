using BookSiteServer.Models;

namespace BookSiteServer.Data
{
    internal class Books : IBooks
    {
        private BookSiteContext context = new();

    }
}
