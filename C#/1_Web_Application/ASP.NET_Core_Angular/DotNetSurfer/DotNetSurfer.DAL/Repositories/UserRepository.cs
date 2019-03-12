using DotNetSurfer.DAL.CDNs.Interfaces;
using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ICdnHandler _cdnHandler;

        public UserRepository(DotNetSurferDbContext dbContext, ICdnHandler cdnHandler)
            : base(dbContext)
        {
            this._cdnHandler = cdnHandler;
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

        public override void Create(User entity)
        {
            if (entity.Picture != null)
            {
                base.Create(entity);
                SaveAsync().Wait(); // Wait for generated Identity
                var uri = this._cdnHandler.UploadImageToStorageAsync(entity.Picture, $"{nameof(User)}_{entity.UserId}").Result;
                entity.PictureUrl = uri?.AbsoluteUri;
            }

            base.Update(entity);
        }

        public override void Update(User entity)
        {
            if (entity.Picture != null)
            {
                var uri = this._cdnHandler.UploadImageToStorageAsync(entity.Picture, $"{nameof(User)}_{entity.UserId}").Result;
                entity.PictureUrl = uri?.AbsoluteUri;
            }

            base.Update(entity);
        }

        public override void Delete(User entity)
        {
            this._cdnHandler.DeleteImageFromStorageAsync($"{nameof(User)}_{entity.UserId}").Wait();

            base.Delete(entity);
        }
    }
}
