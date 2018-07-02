using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JKBlog.Models
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
