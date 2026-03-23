using Microsoft.EntityFrameworkCore;
using WalkingpatternsCore.Models;

namespace WalkingpatternsCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<ClientDetails> ClientDetails { get; set; }

        public DbSet<ProjectVersionDetails> ProjectVersionDetails { get; set; }

        public DbSet<ProjectDetails> ProjectDetails { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
