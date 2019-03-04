using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DotNetSurferDbContext dbContext) 
            : base(dbContext)
        {

        }

        public async Task<bool> IsUserExistAsync(int id)
        {
            return await this._context.Users
                .AnyAsync(u => u.UserId == id);
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await this._context.Users
                .AnyAsync(u => u.Email == email);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await this._context.Users
                .SingleOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await this._context.Users
                    .Include(u => u.Permission)
                    .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserAsNoTrackingAsync(int id)
        {
            return await this._context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}
