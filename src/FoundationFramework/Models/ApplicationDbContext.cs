using FoundationFramework.Models.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace FoundationFramework.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 添加映射
            modelBuilder.Entity<UserInfo>().HasMany(u => u.NavLog).WithOne(log => log.NavUser);
            modelBuilder.Entity<Department>().HasMany(d => d.NavUser).WithOne(u => u.NavDept);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Log> Log { get; set; }
    }
}
