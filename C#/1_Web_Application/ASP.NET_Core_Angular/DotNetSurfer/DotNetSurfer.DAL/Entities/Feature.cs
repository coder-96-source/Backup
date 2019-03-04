using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotNetSurfer.DAL.Entities
{
    public class Feature
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int FeatureId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string FeatureType { get; set; }

        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Description cannot be longer than 200 characters.")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "Version cannot be longer than 100 characters.")]
        public string Version { get; set; }

        public string GithubUrl { get; set; }

        public string DocumentUrl { get; set; }

        public string GuideUrl { get; set; }

        [Required]
        public bool ShowFlag { get; set; }
    }

    public enum FeatureType
    {
        Backend = 0,
        Frontend = 1
    }
}
