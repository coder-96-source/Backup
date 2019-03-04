using DotNetSurfer.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories.Interfaces
{
    public interface IStatusRepository : IRepository<Status>
    {
        Task<IEnumerable<Status>> GetStatusesAsync();
    }
}
