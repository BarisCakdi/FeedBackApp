using FeedBackApp.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FeedBackApp.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public DbSet<FeedBack> FeedBacks { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Commit> Commits { get; set; }

        public DbSet<Upload> Uploads { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // Ticket - Category (One-to-Many)
        //     modelBuilder.Entity<FeedBack>()
        //         .HasOne(t => t.Category)
        //         .WithMany(c => c.FeedBacks)
        //         .HasForeignKey(t => t.CategoryId)
        //         .OnDelete(DeleteBehavior.Cascade);
        //
        //     // Comment - Ticket (One-to-Many)
        //     modelBuilder.Entity<Commit>()
        //         .HasOne(c => c.FeedBack)
        //         .WithMany(t => t.Commits)
        //         .HasForeignKey(c => c.FeedBackId)
        //         .OnDelete(DeleteBehavior.Cascade);
        //
        //     // Comment - User (One-to-Many)
        //     modelBuilder.Entity<Commit>()
        //         .HasOne(c => c.User)
        //         .WithMany(u => u.Commits)
        //         .HasForeignKey(c => c.UserId)
        //         .OnDelete(DeleteBehavior.Cascade);
        //     
        //     // Vote - User (One-to-Many)
        //     modelBuilder.Entity<Upload>()
        //         .HasOne(v => v.User)
        //         .WithMany(u => u.Uploads)
        //         .HasForeignKey(v => v.UserId)
        //         .OnDelete(DeleteBehavior.Cascade);
        //
        //     // Vote - Ticket (One-to-Many)
        //     modelBuilder.Entity<Upload>()
        //         .HasOne(v => v.FeedBack)
        //         .WithMany()
        //         .HasForeignKey(v => v.FeedBackId)
        //         .OnDelete(DeleteBehavior.Cascade);
        //
        //     // Comment - MainCommentId (Optional Self-Referencing Relationship)
        //     modelBuilder.Entity<Commit>()
        //         .HasOne<Commit>()
        //         .WithMany()
        //         .HasForeignKey(c => c.CommitId)
        //         .OnDelete(DeleteBehavior.Restrict);
        //
        //     {
        //         modelBuilder.Entity<ApplicationUser>()
        //             .HasIndex(u => u.Email)
        //             .IsUnique();
        //     }
        // }
    }
}