using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotNetSurfer.DAL.Repositories
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        public TopicRepository(DotNetSurferDbContext dbContext) 
            : base(dbContext)
        {

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
    }
}
