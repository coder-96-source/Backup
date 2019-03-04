using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetSurfer.DAL.Entities
{
    public class Announcement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public int AnnouncementId { get; set; }

        [StringLength(100, ErrorMessage = "Content cannot be longer than 100 characters.")]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PostDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ModifyDate { get; set; }

        [Required]
        [Display(Name = "Show")]
        public bool ShowFlag { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}
