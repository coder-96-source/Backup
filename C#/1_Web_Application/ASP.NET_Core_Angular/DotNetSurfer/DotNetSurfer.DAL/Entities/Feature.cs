using System.ComponentModel.DataAnnotations;

namespace DotNetSurfer.DAL.Entities
{
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }

        public string GithubUrl { get; set; }

        public string DocumentUrl { get; set; }

        public string GuideUrl { get; set; }

        public string FeatureType { get; set; }

        public bool ShowFlag { get; set; }
    }
}
