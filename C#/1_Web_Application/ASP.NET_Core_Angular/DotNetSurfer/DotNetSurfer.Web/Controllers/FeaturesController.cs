using System;
using System.Collections.Generic;
using System.Linq;
using DotNetSurfer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Controllers
{
    public class FeaturesController : BaseController
    {
        public FeaturesController(DotNetSurferDbContext context, ILogger<FeaturesController> logger)
            : base(context, logger)
        {

        }

        [HttpGet("{featureType}")]
        public IEnumerable<Feature> GetFeaturesByFeatureType([FromRoute] string featureType)
        {
            IEnumerable<Feature> features = null;

            try
            {
                features = this._context.Features
                    .Where(f => f.FeatureType == featureType)
                    .ToList();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetFeaturesByFeatureType));
            }

            return features;
        }
    }
}