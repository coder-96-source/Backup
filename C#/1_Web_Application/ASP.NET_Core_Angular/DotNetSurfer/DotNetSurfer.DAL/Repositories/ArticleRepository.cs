using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(DotNetSurferDbContext dbContext) 
            : base(dbContext)
        {

        }

        public async Task<bool> IsArticleExistAsync(int id)
        {
            return await this._context.Articles.AnyAsync(a => a.ArticleId == id);
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            return await this._context.Articles
                 .Include(a => a.User)
                 .Include(a => a.Topic)
                 .Include(a => a.Tags)
                 .AsNoTracking()
                 .SingleOrDefaultAsync(a => a.ArticleId == id);
        }

        public async Task<IEnumerable<Article>> GetArticlesByUserIdAsync()
        {
            return await this._context.Articles
                .Include(a => a.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetArticlesByUserIdAsync(int userId)
        {
            return await this._context.Articles
                .Include(a => a.User)
                .Where(a => a.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetArticlesByPageAsync(int pageId, int itemPerPage)
        {
            return await this._context.Articles
                .Include(article => article.User)
                .Include(article => article.Topic)
                .Where(a => a.ShowFlag)
                .OrderByDescending(article => article.PostDate)
                .Skip((pageId - 1) * itemPerPage)
                .Take(itemPerPage)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetTopArticlesAsync(int item)
        {
            return await this._context.Articles
                .Include(article => article.User)
                .Where(article => article.ShowFlag)
                .OrderByDescending(a => a.ReadCount)
                .Take(item)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task IncreaseArticleReadCountAsync(int id)
        {
            var article = await _context.Articles.FirstAsync(a => a.ArticleId == id);
            article.ReadCount++;
        }
    }
}
