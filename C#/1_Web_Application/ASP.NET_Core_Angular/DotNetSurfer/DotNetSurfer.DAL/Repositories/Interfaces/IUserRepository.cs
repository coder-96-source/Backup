using DotNetSurfer.DAL.Entities;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> IsUserExistAsync(int id);
        Task<bool> IsEmailExistAsync(string email);
        Task<User> GetUserAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserAsNoTrackingAsync(int id);
    }
}
