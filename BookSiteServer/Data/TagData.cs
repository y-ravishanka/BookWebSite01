using BookSiteServer.Models;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Immutable;

namespace BookSiteServer.Data
{
    internal class TagData : ITagData
    {
        private BookSiteContext context = new();

        async Task<bool> ITagData.AddTagAsync(Tag tag)
        {
            try
            {
                await context.Tags.AddAsync(tag);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.ToString() + "\n");
                return false;
            }
        }

        async Task<List<Book>> ITagData.GetBooksAsync(int id)
        {
            try
            {
                var book = from t in context.Tags
                           where t.TagId == id
                           select t.Books;
                return (List<Book>)book;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.ToString()+"\n");
                return null;
            }
        }

        async Task<List<Book>> ITagData.GetBooksAsync(string name)
        {
            try
            {
                var book = from t in context.Tags
                           where t.TagName == name
                           select t.Books;
                return (List<Book>)book;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.ToString() + "\n");
                return null;
            }
        }

        async Task<Tag> ITagData.GetTagAsync(int id)
        {
            try
            {
                var tag = from t in context.Tags
                          where t.TagId == id
                          select t;
                return (Tag)tag;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.ToString() + "\n");
                return null;
            }
        }

        async Task<Tag> ITagData.GetTagAsync(string name)
        {
            try
            {
                var tag = from t in context.Tags
                          where t.TagName == name
                          select t;
                return (Tag)tag;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.ToString() + "\n");
                return null;
            }
        }

        async Task<bool> ITagData.UpdateTagAsync(Tag tag)
        {
            try
            {
                Tag tag1 = await context.Tags.FirstOrDefaultAsync(t => t.TagId == tag.TagId);
                if (tag1 is Tag)
                {
                    tag1.TagName = tag.TagName;
                    tag1.Description = tag.Description;
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

        async Task<bool> ITagData.UpdateTagAsync(Book book, string tagName)
        {
            try
            {
                Tag tagEl = await context.Tags.Include(t => t.Books).FirstOrDefaultAsync(t => t.TagName == tagName);
                if (tagEl is Tag)
                {
                    tagEl.Books.Add(book);
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
