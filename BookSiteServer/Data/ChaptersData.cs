using BookSiteServer.Models;
using Microsoft.EntityFrameworkCore;

namespace BookSiteServer.Data
{
    internal class ChaptersData : IChaptersData
    {
        private BookSiteContext context = new();

        async Task<bool> IChaptersData.AddChapterAsync(Guid id, Chapter chapter)
        {
            try
            {
                Book book = await context.Books.Include(b => b.Chapters).SingleOrDefaultAsync(b => b.BookId == id);
                if (book != null)
                {
                    book.Chapters.Add(chapter);
                }
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.ToString() + "\n");
                return false;
            }
        }

        async Task<Chapter> IChaptersData.GetChapterAsync(Guid id)
        {
            try
            {
                Chapter chapter = await context.Chapters.FirstOrDefaultAsync(c => c.Id == id);
                if (chapter != null)
                { return chapter; }
                else
                { return null; }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.ToString() + "\n");
                return null;
            }
        }

        async Task<Chapter> IChaptersData.GetChapterAsync(string name, Guid id)
        {
            try
            {
                var chapter = from c in context.Chapters
                              where c.Title == name && c.Book.BookId == id
                              select c;

                if (chapter != null)
                { return (Chapter)chapter; }
                else
                { return null; }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.ToString() + "\n");
                return null;
            }
        }

        async Task<bool> IChaptersData.UpdateChapterAsync(Chapter chapter)
        {
            try
            {
                Chapter chap = await context.Chapters.FirstOrDefaultAsync(c => c.Id == chapter.Id);
                if (chap != null)
                {
                    chap.Title = chapter.Title;
                    chap.Content = chapter.Content;
                }
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
