using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetSurfer.Web.Models
{
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }

        [StringLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Title cannot be longer than 20 characters.")]
        public string Title { get; set; }

        [StringLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        public string Address { get; set; }

        [StringLength(100, ErrorMessage = "Introduction cannot be longer than 100 characters.")]
        public string Introduction { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }

        public byte[] Picture { get; set; }

        public string PictureMimeType { get; set; }

        public string PictureUrl { get; set; }

        public int PermissionId { get; set; }

        public Permission Permission { get; set; }

        public ICollection<Topic> Topics { get; set; }

        public ICollection<Article> Articles { get; set; }

        public ICollection<Announcement> Announcements { get; set; }
    }
}