using Microsoft.AspNetCore.Mvc;

namespace DotNetSurfer.Web.Models
{
    public class Status
    {
        [HiddenInput(DisplayValue = false)]
        public int StatusId { get; set; }

        public StatusType CurrentStatus { get; set; }
    }

    public enum StatusType
    {
        Requested = 0,
        Ongoing = 1,
        Pending = 2,
        Completed = 3
    }
}
