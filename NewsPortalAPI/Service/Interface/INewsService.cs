using NewsPortalAPI.Models;

namespace NewsPortalAPI.Service.Interface
{
    public interface INewsService
    {
        Task<List<NewsArticle>> FetchAndStoreNews(string apiKey);
        Task<IEnumerable<NewsArticle>> GetStoredNews();
    }
}
