using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JKBlog.Models.DataModel
{
    public partial class JKBlogDbContext : DbContext
    {
        public JKBlogDbContext(DbContextOptions<JKBlogDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>(entity =>
            {
                // will add more property annotations
                entity.Property(t => t.Name)
                    .HasMaxLength(20)
                    .IsRequired(true);

                entity.HasMany(t => t.Articles)
                    .WithOne(a => a.Topic)
                    .HasForeignKey(a => a.TopicId);
            });

            modelBuilder.Entity<Article>(entity =>
            {
                // will add more property annotations
                entity.Property(a => a.Category)
                    .IsRequired(true);

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
                // will add more property annotations
                entity.Property(t => t.Content)
                    .IsUnicode(false);

                entity.HasOne(t => t.Article)
                    .WithOne(a => a.Tag)
                    .HasForeignKey<Article>(a => a.TagId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                // will add more property annotations
                entity.Property(u => u.Name)
                    .IsRequired(true);

                entity.HasMany(u => u.Articles)
                    .WithOne(a => a.User)
                    .HasForeignKey(a => a.UserId);

                entity.HasMany(u => u.Announcements)
                    .WithOne(a => a.User)
                    .HasForeignKey(a => a.UserId);

                entity.HasOne(u => u.Permission)
                    .WithMany(p => p.Users)
                    .HasForeignKey(p => p.PermissionId);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                // will add more property annotations
                entity.Property(p => p.PermissionType)
                    .IsRequired(true);

                entity.HasMany(p => p.Users)
                    .WithOne(u => u.Permission)
                    .HasForeignKey(u => u.PermissionId);
            });

            modelBuilder.Entity<Announcement>(entity =>
            {
                // will add more property annotations
                entity.Property(a => a.Content)
                    .IsRequired(true)
                    .HasMaxLength(50);

                entity.HasOne(a => a.User)
                    .WithMany(u => u.Announcements)
                    .HasForeignKey(u => u.AnnouncmentId);
            });
        }
    }
}