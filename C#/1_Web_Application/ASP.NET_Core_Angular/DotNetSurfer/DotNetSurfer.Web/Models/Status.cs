using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotNetSurfer.Web.Models
{
    public class Status
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int StatusId { get; set; }

        public string CurrentStatus { get; set; }
    }

    public enum StatusType
    {
        Requested = 0,
        Ongoing = 1,
        Pending = 2,
        Completed = 3
    }
}
