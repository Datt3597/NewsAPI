using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortalAPI.Service.Interface;

namespace NewsPortalAPI.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("{apiKey}")]
        public async Task<IActionResult> FetchNews(string apiKey)
        {
            var news = await _newsService.FetchAndStoreNews(apiKey);
            return Ok(news);
        }

        [HttpGet]
        public async Task<IActionResult> GetStoredNews()
        {
            var news = await _newsService.GetStoredNews();
            return Ok(news);
        }
    }
}