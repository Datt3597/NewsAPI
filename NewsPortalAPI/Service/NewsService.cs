using NewsPortalAPI.Models;
using NewsPortalAPI.Repository.Interface;
using NewsPortalAPI.Service.Interface;
using Newtonsoft.Json.Linq;

namespace NewsPortalAPI.Service
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;
        private readonly INewsRepository _newsRepository;


        public NewsService(HttpClient httpClient, INewsRepository newsRepository)
        {
            _httpClient = httpClient;
            _newsRepository = newsRepository;
        }

        public async Task<List<NewsArticle>> FetchAndStoreNews(string apiKey)
        {
            var response = await _httpClient.GetStringAsync($"https://api.nytimes.com/svc/topstories/v2/home.json?api-key={apiKey}");
            var json = JObject.Parse(response);

            var articles = json["results"].Select(a => new NewsArticle
            {
                Title = a["title"].ToString(),
                Url = a["url"].ToString(),
                Byline = a["byline"].ToString(),
                Section = a["section"].ToString(),
                PublishedDate = DateTime.Parse(a["published_date"].ToString())
            }).ToList();

            foreach (var article in articles)
            {
                await _newsRepository.Add(article);
            }

            return articles;
        }

        public async Task<IEnumerable<NewsArticle>> GetStoredNews()
        {
            return await _newsRepository.GetAll();
        }


    }
}
