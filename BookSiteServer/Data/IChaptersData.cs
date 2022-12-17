using BookSiteServer.Models;

namespace BookSiteServer.Data
{
    internal interface IChaptersData
    {
        Task<bool> AddChapterAsync(Guid id, Chapter chapter);
        Task<bool> UpdateChapterAsync(Chapter chapter);
        Task<Chapter> GetChapterAsync(Guid id);
        Task<Chapter> GetChapterAsync(string name, Guid id);
    }
}
