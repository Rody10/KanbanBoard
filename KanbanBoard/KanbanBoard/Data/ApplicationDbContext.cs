using KanbanBoard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext<KanbanBoardUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<KanbanBoardTask> KanbanBoardTasks { get; set; }
        public DbSet<KanbanBoardUser> KanbanBoardUsers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.KanbanBoardUser)
                .WithMany(u => u.Projects) 
                .HasForeignKey(p => p.ProjectOwnerId)
                // Disable cascade delete (User -> Project).
                // Doing this to prevent cascade error when adding ProjectID FK to Task 
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }

}
