using System;
using System.Collections.Generic;
using LTF.Interfaces;
using LTF.Models.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LTF.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1.添加映射
            // 用户日志 一对多
            modelBuilder.Entity<User>().HasMany(u => u.NavLogCollection).WithOne(log => log.NavUser).HasForeignKey(log => log.NavUserId);
            // 用户部门 一对多
            modelBuilder.Entity<Department>().HasMany(d => d.NavUserCollection).WithOne(u => u.NavDept).HasForeignKey(dept => dept.NavDeptId);
            // 用户角色 多对多 貌似不支持 转换为两个一对多实现
            modelBuilder.Entity<User>().HasMany(u => u.NavUserRoleMapCollection).WithOne(map => map.NavUser).HasForeignKey(map => map.NavUserId);
            modelBuilder.Entity<Role>().HasMany(r => r.NavUserRoleMapCollection).WithOne(map => map.NavRole).HasForeignKey(map => map.NavRoleId);
            // 菜单组和菜单项 一对多
            modelBuilder.Entity<MenuGroup>().HasMany(g => g.NavMenuItemCollection).WithOne(i => i.NavMenuGroup).HasForeignKey(m => m.NavMenuGroupId);
            // 角色菜单项 多对多
            modelBuilder.Entity<MenuItem>().HasMany(m => m.NavRoleMenuMapCollection).WithOne(map => map.NavMenuItem).HasForeignKey(map => map.NavMenuItemId);
            modelBuilder.Entity<Role>().HasMany(r => r.NavRoleMenuMapCollection).WithOne(map => map.NavRole).HasForeignKey(map => map.NavRoleId);

            // 2.移除自增长
            modelBuilder.Entity<User>().Property("Id").ValueGeneratedNever();
            modelBuilder.Entity<Department>().Property("Id").ValueGeneratedNever();
            modelBuilder.Entity<Log>().Property("Id").ValueGeneratedNever();
            modelBuilder.Entity<MenuGroup>().Property("Id").ValueGeneratedNever();
            modelBuilder.Entity<MenuItem>().Property("Id").ValueGeneratedNever();
            modelBuilder.Entity<Role>().Property("Id").ValueGeneratedNever();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<MenuGroup> MenuGroup { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<Role> Role { get; set; }


        /// <summary>
        /// 设置默认值
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        public static void SetSeed(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var userLogic = serviceProvider.GetRequiredService<IUserLogic>();
            var deptLogic = serviceProvider.GetRequiredService<IDepartmentLogic>();
            var roleLogic = serviceProvider.GetRequiredService<IRoleLogic>();

            Department dept = null;
            Role role = null;
            if (deptLogic.GetFirst(p => true) == null)
            {
                dept = deptLogic.Add(new Department
                {
                    DepartmentName = "公司",
                    Level = 1,
                    ParentId = 0
                });
            }
            if (roleLogic.GetFirst(p => true) == null)
            {
                role = roleLogic.Add(new Role { Name = "管理员" });
            }
            if (userLogic.GetFirst(p => true) == null)
            {
                userLogic.Add(new User
                {
                    JobNumber = "08001",
                    Name = "农夫山泉",
                    Pwd = "08001123",
                    NavDept = dept,
                    NavUserRoleMapCollection = new List<UserRoleMap> { new UserRoleMap { NavRole = role } }
                });
            }

            deptLogic.SaveChanges();

        }
    }
}
