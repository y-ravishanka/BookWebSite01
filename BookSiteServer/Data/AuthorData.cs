using BookSiteServer.Models;
using BookSiteServer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Linq;

namespace BookSiteServer.Data
{
    internal class AuthorData : IAuthorData
    {
        private readonly BookSiteContext context = new();
        private readonly ICalculation cal = new Calculation();
        private readonly string ecTitle = "AuthorData EF Core Method Exception";

        async Task<bool> IAuthorData.AddAuthorAsync(Author author)
        {
            try
            {
                await context.Authors.AddAsync(author);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                cal.DisplayExceptions(ecTitle, ex.ToString());
                return false;
            }
        }

        async Task<Author> IAuthorData.GetAuthorAsync(Guid id)
        {
            try
            {
                var author = from a in context.Authors
                             where a.AuthorId == id
                             select a;

                if (author == null)
                { return null; }
                else
                { return await author.FirstOrDefaultAsync(); }
            }
            catch (Exception ex)
            {
                cal.DisplayExceptions(ecTitle, ex.ToString());
                return null;
            }
        }

        async Task<Author> IAuthorData.GetAuthorAsync(string name)
        {
            try
            {
                var author = from a in context.Authors
                             from aa in a.AltName
                             where a.Name == name || aa.Name == name
                             select a;

                if (author == null)
                { return null; }
                else
                { return await author.FirstOrDefaultAsync(); }

            }
            catch (Exception ex)
            {
                cal.DisplayExceptions(ecTitle, ex.ToString());
                return null;
            }
        }

        async Task<List<Book>> IAuthorData.GetBooksAsync(Guid id)
        {
            try
            {
                var books = from a in context.Authors
                            where a.AuthorId == id
                            select a.Books;
                return new List<Book>(books.FirstOrDefault());
            }
            catch (Exception ex)
            {
                cal.DisplayExceptions(ecTitle, ex.ToString());
                return null;
            }
        }

        async Task<List<Book>> IAuthorData.GetBooksAsync(string name)
        {
            try
            {
                var books = from a in context.Authors
                            from aa in a.AltName
                            where a.Name.Equals(name) || aa.Name.Equals(name)
                            select a.Books;
                return new List<Book>(books.FirstOrDefault());
            }
            catch (Exception ex)
            {
                cal.DisplayExceptions(ecTitle, ex.ToString());
                return null;
            }
        }

        async Task<bool> IAuthorData.UpdateAuthorAsync(Guid id, AuthorName authorName)
        {
            try
            {
                Author author = await context.Authors.Include(a => a.AltName).FirstOrDefaultAsync(a => a.AuthorId == id);
                if (author is Author)
                {
                    author.AltName.Add(authorName);
                }
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                cal.DisplayExceptions(ecTitle, ex.ToString());
                return false;
            }
        }

        async Task<bool> IAuthorData.UpdateAuthorAsync(Guid id, Book book)
        {
            try
            {
                Author author = await context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.AuthorId == id);
                if (author is Author)
                {
                    author.Books.Add(book);
                }
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                cal.DisplayExceptions(ecTitle, ex.ToString());
                return false;
            }
        }

        async Task<bool> IAuthorData.UpdateAuthorAsync(Guid id, string name)
        {
            try
            {
                Author author = await context.Authors.FirstOrDefaultAsync(a => a.AuthorId == id);
                if (author is Author)
                {
                    author.Name = name;
                }
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                cal.DisplayExceptions(ecTitle, ex.ToString());
                return false;
            }
        }

        async Task<bool> IAuthorData.UpdateAuthorAsync(Guid id, int altId, string altname)
        {
            try
            {
                AuthorName author = await context.AuthorNames.FirstOrDefaultAsync(a => a.AltNameId == altId && a.Author.AuthorId == id);
                if (author is AuthorName)
                {
                    author.Name = altname;
                }
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                cal.DisplayExceptions(ecTitle, ex.ToString());
                return false;
            }
        }
    }
}
