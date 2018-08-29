using Microsoft.EntityFrameworkCore;

namespace DotNetSurfer.Web.Models
{
    public class DotNetSurferDbContext : DbContext
    {
        public DotNetSurferDbContext(DbContextOptions<DotNetSurferDbContext> options)
            : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
}