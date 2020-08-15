using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyArticles.Models
{
    public class EFDbContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}