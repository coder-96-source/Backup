using Microsoft.AspNetCore.Mvc;

namespace DotNetSurfer.Web.Models
{
    public class Tag
    {
        [HiddenInput(DisplayValue = false)]
        public int TagId { get; set; }

        public string Content { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}