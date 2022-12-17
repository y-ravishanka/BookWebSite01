using BookSiteServer.Models;

namespace BookSiteServer.Data
{
    internal interface IAuthorData
    {
        Task<bool> AddAuthorAsync(Author author);
        Task<bool> UpdateAuthorAsync(Guid id, string name);
        Task<bool> UpdateAuthorAsync(Guid id, AuthorName authorName);
        Task<bool> UpdateAuthorAsync(Guid id, Book book);
        Task<bool> UpdateAuthorAsync(Guid id, int altId, string altname);
        Task<Author> GetAuthorAsync(Guid id);
        Task<Author> GetAuthorAsync(string name);
        Task<List<Book>> GetBooksAsync(Guid id);
        Task<List<Book>> GetBooksAsync(string name);
        
    }
}
