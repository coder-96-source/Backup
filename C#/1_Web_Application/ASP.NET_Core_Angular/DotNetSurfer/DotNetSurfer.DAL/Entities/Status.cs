using System.ComponentModel.DataAnnotations;

namespace DotNetSurfer.DAL.Entities
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        public string CurrentStatus { get; set; }
    }
}
