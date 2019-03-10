using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories
{
    public class FeatureRepository : BaseRepository<Feature>, IFeatureRepository
    {
        public FeatureRepository(DotNetSurferDbContext dbContext) 
            : base(dbContext)
        {

        }

        public async Task<IEnumerable<Feature>> GetFeaturesByFeatureTypeAsync(string featureType)
        {
            return await this._context.Features
                .Where(f => f.FeatureType == featureType)
                .ToListAsync();                  
        }
    }
}
