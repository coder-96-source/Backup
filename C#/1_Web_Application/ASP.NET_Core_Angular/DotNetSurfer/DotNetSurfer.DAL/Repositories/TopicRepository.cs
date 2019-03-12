using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetSurfer.DAL.CDNs.Interfaces;
using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotNetSurfer.DAL.Repositories
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        private readonly ICdnHandler _cdnHandler;

        public TopicRepository(DotNetSurferDbContext dbContext, ICdnHandler cdnHandler)
            : base(dbContext)
        {
            this._cdnHandler = cdnHandler;
        }

        public async Task<bool> IsTopicExistAsync(int id)
        {
            return await this._context.Topics.AnyAsync(t => t.TopicId == id);
        }

        public async Task<bool> IsTitleExistAsync(string title)
        {
            return await this._context.Topics.AnyAsync(t => t.Title == title);
        }

        public async Task<Topic> GetTopicAsync(int id)
        {
            return await this._context.Topics
                .Include(t => t.User)
                .AsNoTracking()
                .SingleOrDefaultAsync(t => t.TopicId == id);
        }

        public async Task<IEnumerable<Topic>> GetTopicsAsync()
        {
            return await this._context.Topics
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<IEnumerable<Topic>> GetTopicsByUserIdAsync()
        {
            return await this._context.Topics
                        .Include(t => t.User)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<IEnumerable<Topic>> GetTopicsByUserIdAsync(int userId)
        {
            return await this._context.Topics
                    .Include(t => t.User)
                    .Where(a => a.UserId == userId)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<object> GetSideHeaderMenusAsync()
        {
            return await this._context.Topics
                    .Where(t => t.ShowFlag)
                    .Select(t => new {
                        Id = t.TopicId,
                        Title = t.Title,
                        SideNodes = t.Articles
                            .Where(a => a.ShowFlag)
                            .Select(a => new {
                                Id = a.ArticleId,
                                Title = a.Title
                            })
                    }).ToListAsync();
        }

        public override void Create(Topic entity)
        {
            if (entity.Picture != null)
            {
                base.Create(entity);
                SaveAsync().Wait(); // Wait for generated Identity
                var uri = this._cdnHandler.UploadImageToStorageAsync(entity.Picture, $"{nameof(Topic)}_{entity.TopicId}").Result;
                entity.PictureUrl = uri?.AbsoluteUri;
            }

            base.Update(entity);
        }

        public override void Update(Topic entity)
        {
            if (entity.Picture != null)
            {
                var uri = this._cdnHandler.UploadImageToStorageAsync(entity.Picture, $"{nameof(Topic)}_{entity.TopicId}").Result;
                entity.PictureUrl = uri?.AbsoluteUri;
            }

            base.Update(entity);
        }

        public override void Delete(Topic entity)
        {
            this._cdnHandler.DeleteImageFromStorageAsync($"{nameof(Topic)}_{entity.TopicId}").Wait();

            base.Delete(entity);
        }
    }
}
