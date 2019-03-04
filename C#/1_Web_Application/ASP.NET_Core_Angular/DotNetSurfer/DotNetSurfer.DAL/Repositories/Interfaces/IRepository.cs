using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveAsync();
    }
}
