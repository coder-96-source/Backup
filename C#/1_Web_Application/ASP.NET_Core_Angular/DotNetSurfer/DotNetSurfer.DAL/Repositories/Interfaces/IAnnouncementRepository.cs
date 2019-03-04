using DotNetSurfer.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories.Interfaces
{
    public interface IAnnouncementRepository : IRepository<Announcement>
    {
        Task<bool> IsAnnouncementExistAsync(int id);
        Task<Announcement> GetAnnouncementAsync(int id);
        Task<IEnumerable<Announcement>> GetAnnouncementsAsync();
        Task<IEnumerable<Announcement>> GetAnnouncementsByUserIdAsync();
        Task<IEnumerable<Announcement>> GetAnnouncementsByUserIdAsync(int userId);
    }
}
