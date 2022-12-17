using BookSiteServer.Models;

namespace BookSiteServer.Data
{
    internal interface ITagData
    {
        Task<bool> AddTagAsync(Tag tag);
        Task<bool> UpdateTagAsync(Tag tag);
        Task<bool> UpdateTagAsync(Book book, string tagName);
        Task<Tag> GetTagAsync(int id);
        Task<Tag> GetTagAsync(string name);
        Task<List<Book>> GetBooksAsync(int id);
        Task<List<Book>> GetBooksAsync(string name);
    }
}
