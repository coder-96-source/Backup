using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(DotNetSurferDbContext dbContext) 
            : base(dbContext)
        {

        }

        public async Task<IEnumerable<Status>> GetStatusesAsync()
        {
            return await this._context.Statuses.ToListAsync();
        }
    }
}
