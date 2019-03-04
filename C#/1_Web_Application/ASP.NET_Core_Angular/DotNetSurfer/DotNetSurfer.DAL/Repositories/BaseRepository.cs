using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DotNetSurferDbContext _context { get; set; }

        public BaseRepository(DotNetSurferDbContext context)
        {
            this._context = context;
        }

        public void Create(T entity)
        {
            this._context.Add<T>(entity);
        }

        public void Update(T entity)
        {
            this._context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            this._context.Entry<T>(entity).State = EntityState.Deleted;
        }

        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
    }
}
