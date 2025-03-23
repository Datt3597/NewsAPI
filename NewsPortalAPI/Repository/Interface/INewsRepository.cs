using NewsPortalAPI.Models;

namespace NewsPortalAPI.Repository.Interface
{
    public interface INewsRepository : IRepository<NewsArticle>
    {
        Task<List<NewsArticle>> GetBySection(string section);
    }
}
