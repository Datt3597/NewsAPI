using Microsoft.EntityFrameworkCore;
using NewsPortalAPI.Models;
using NewsPortalAPI.Repository.Interface;

namespace NewsPortalAPI.Repository
{
    public class NewsRepository : Repository<NewsArticle>, INewsRepository
    {
        private readonly NewsDbContext _context;

        public NewsRepository(NewsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<NewsArticle>> GetBySection(string section)
        {
            return await _context.NewsArticles.Where(n => n.Section == section).ToListAsync();
        }
    }
}
