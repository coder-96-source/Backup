using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories
{
    public class AnnouncementRepository : BaseRepository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(DotNetSurferDbContext dbContext) 
            : base(dbContext)
        {

        }

        public async Task<bool> IsAnnouncementExistAsync(int id)
        {
            return await this._context.Announcements.AnyAsync(a => a.AnnouncementId == id);
        }

        public async Task<Announcement> GetAnnouncementAsync(int id)
        {
            return await this._context.Announcements
                    .Include(a => a.User)
                    .Include(a => a.Status)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(a => a.AnnouncementId == id);
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync()
        {
            return await this._context.Announcements
                    .Include(a => a.User)
                    .Include(a => a.Status)
                    .Where(a => a.ShowFlag)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsByUserIdAsync()
        {
            return await this._context.Announcements
                        .Include(a => a.User)
                        .Include(a => a.Status)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsByUserIdAsync(int userId)
        {
            return await this._context.Announcements
                  .Include(a => a.User)
                  .Include(a => a.Status)
                  .Where(a => a.UserId == userId)
                  .AsNoTracking()
                  .ToListAsync();
        }
    }
}
