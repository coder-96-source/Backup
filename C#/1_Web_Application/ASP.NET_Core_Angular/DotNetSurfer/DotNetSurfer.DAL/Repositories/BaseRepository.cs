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

        public virtual void Create(T entity)
        {
            this._context.Add<T>(entity);
        }

        public virtual void Update(T entity)
        {
            this._context.Entry<T>(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            this._context.Entry<T>(entity).State = EntityState.Deleted;
        }

        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
    }
}
