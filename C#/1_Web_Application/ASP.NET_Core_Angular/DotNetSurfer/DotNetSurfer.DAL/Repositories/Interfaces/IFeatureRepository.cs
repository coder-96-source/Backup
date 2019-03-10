using DotNetSurfer.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories.Interfaces
{
    public interface IFeatureRepository : IRepository<Feature>
    {
        Task<IEnumerable<Feature>> GetFeaturesByFeatureTypeAsync(string featureType);
    }
}
