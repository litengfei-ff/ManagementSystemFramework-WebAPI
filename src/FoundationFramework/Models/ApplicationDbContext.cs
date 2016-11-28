using System;
using System.ComponentModel.DataAnnotations.Schema;
using FoundationFramework.Implements;
using FoundationFramework.Interfaces;
using FoundationFramework.Models.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            // 移除自增长
            modelBuilder.Entity<UserInfo>().Property("Id").ValueGeneratedNever();
            modelBuilder.Entity<Department>().Property("Id").ValueGeneratedNever();
            modelBuilder.Entity<Log>().Property("Id").ValueGeneratedNever();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Log> Log { get; set; }



        public static void SetSeed(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var userLogic = serviceProvider.GetRequiredService<IUserInfoLogic>();
            var deptLogic = serviceProvider.GetRequiredService<IDepartmentLogic>();
            deptLogic.Add(new DomainModel.Department
            {
                DepartmentName = "公司",
                Level = 1,
                ParentId = 0
            });
            userLogic.Add(new DomainModel.UserInfo
            {
                JobNumber = "08001",
                Name = "农夫山泉",
                NavDeptId = 1,
                Pwd = "08001123"
            });
            deptLogic.SaveChanges();

        }
    }
}
