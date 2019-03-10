using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetSurfer.Web.Models;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using DotNetSurfer.Web.Helpers;

namespace DotNetSurfer.Web.Controllers
{
    public class FeaturesController : BaseController
    {
        public FeaturesController(IUnitOfWork unitOfWork, ILogger<FeaturesController> logger)
            : base(unitOfWork, logger)
        {

        }

        [HttpGet("{featureType}")]
        public async Task<IEnumerable<Feature>> GetFeaturesByFeatureType([FromRoute] string featureType)
        {
            IEnumerable<Feature> features = null;

            try
            {
                FeatureType featureTypeEnum;
                if (string.IsNullOrEmpty(featureType) || !Enum.TryParse(featureType, out featureTypeEnum))
                {
                    throw new ArgumentException($"Invalid FeatureType: {featureType}");
                }

                var entityModels = await this._unitOfWork.FeatureRepository
                    .GetFeaturesByFeatureTypeAsync(featureType);

                features = entityModels?.Select(f => f.MapToDomain());
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetFeaturesByFeatureType));
            }

            return features;
        }
    }
}