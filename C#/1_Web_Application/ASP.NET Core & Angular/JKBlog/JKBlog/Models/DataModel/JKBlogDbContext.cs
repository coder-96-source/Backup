using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JKBlog.Models.DataModel
{
    public class JKBlogDbContext : DbContext
    {
        public JKBlogDbContext(DbContextOptions<JKBlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasMany(t => t.Articles)
                    .WithOne(a => a.Topic)
                    .HasForeignKey(a => a.TopicId);
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasOne(a => a.Topic)
                    .WithMany(t => t.Articles) // topic
                    .HasForeignKey(t => t.ArticleId);

                entity.HasOne(a => a.Tag)
                    .WithOne(t => t.Article) // tag
                    .HasForeignKey<Tag>(t => t.ArticleId);

                entity.HasOne(a => a.User)
                     .WithMany(u => u.Articles)
                     .HasForeignKey(u => u.ArticleId);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasOne(t => t.Article)
                    .WithOne(a => a.Tag)
                    .HasForeignKey<Article>(a => a.TagId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(u => u.Articles)
                    .WithOne(a => a.User).HasForeignKey(a => a.UserId);

                entity.HasOne(u => u.Permission)
                    .WithMany(p => p.Users)
                    .HasForeignKey(p => p.PermissionId);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasMany(p => p.Users)
                    .WithOne(u => u.Permission)
                    .HasForeignKey(u => u.PermissionId);
            });
        }
    }
}