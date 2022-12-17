using BookSiteServer.Models;

namespace BookSiteServer.Data
{
    internal class BooksData : IBooksData
    {
        private BookSiteContext context = new();

        async Task<bool> IBooksData.AddBookAsync(Book book)
        {
            try
            {
                await context.Books.AddAsync(book);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.ToString() + "\n");
                return false;
            }
        }
    }
}
