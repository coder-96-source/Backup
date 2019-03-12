using DotNetSurfer.DAL.CDNs.Interfaces;
using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        private readonly ICdnHandler _cdnHandler;

        public ArticleRepository(DotNetSurferDbContext dbContext, ICdnHandler cdnHandler) 
            : base(dbContext)
        {
            this._cdnHandler = cdnHandler;
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

        public override void Create(Article entity)
        {        
            if (entity.Picture != null)
            {
                base.Create(entity);
                SaveAsync().Wait(); // Wait for generated Identity
                var uri = this._cdnHandler.UploadImageToStorageAsync(entity.Picture, $"{nameof(Article)}_{entity.ArticleId}").Result;
                entity.PictureUrl = uri?.AbsoluteUri;
            }

            base.Update(entity);
        }

        public override void Update(Article entity)
        {
            if (entity.Picture != null)
            {
                var uri = this._cdnHandler.UploadImageToStorageAsync(entity.Picture, $"{nameof(Article)}_{entity.ArticleId}").Result;
                entity.PictureUrl = uri?.AbsoluteUri;
            }

            base.Update(entity);
        }

        public override void Delete(Article entity)
        {
            this._cdnHandler.DeleteImageFromStorageAsync($"{nameof(Article)}_{entity.ArticleId}").Wait();

            base.Delete(entity);
        }
    }
}
