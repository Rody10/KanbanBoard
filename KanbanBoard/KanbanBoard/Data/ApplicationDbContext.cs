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
    }
}
