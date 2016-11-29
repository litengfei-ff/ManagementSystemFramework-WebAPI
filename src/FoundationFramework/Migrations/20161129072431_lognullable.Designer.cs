using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LTF.Models;

namespace LTF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161129072431_lognullable")]
    partial class lognullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-preview1-22509")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LTF.Models.DomainModel.Department", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("DelFlag");

                    b.Property<string>("DepartmentName");

                    b.Property<int>("Level");

                    b.Property<int>("ParentId");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("LTF.Models.DomainModel.Log", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("DelFlag");

                    b.Property<string>("LogLevel");

                    b.Property<string>("Msg");

                    b.Property<int?>("NavUserId");

                    b.Property<string>("RequestUrl");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.HasIndex("NavUserId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("LTF.Models.DomainModel.MenuGroup", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("DelFlag");

                    b.Property<string>("Icon");

                    b.Property<string>("Name");

                    b.Property<int>("Sort");

                    b.HasKey("Id");

                    b.ToTable("MenuGroup");
                });

            modelBuilder.Entity("LTF.Models.DomainModel.MenuItem", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("ClientRouter");

                    b.Property<int>("DelFlag");

                    b.Property<string>("Name");

                    b.Property<int>("NavMenuGroupId");

                    b.Property<string>("ServerRouter");

                    b.Property<int>("Sort");

                    b.HasKey("Id");

                    b.HasIndex("NavMenuGroupId");

                    b.ToTable("MenuItem");
                });

            modelBuilder.Entity("LTF.Models.DomainModel.Role", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("DelFlag");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("LTF.Models.DomainModel.RoleMenuMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DelFlag");

                    b.Property<int>("NavMenuItemId");

                    b.Property<int>("NavRoleId");

                    b.HasKey("Id");

                    b.HasIndex("NavMenuItemId");

                    b.HasIndex("NavRoleId");

                    b.ToTable("RoleMenuMap");
                });

            modelBuilder.Entity("LTF.Models.DomainModel.User", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("DelFlag");

                    b.Property<string>("JobNumber")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<int>("NavDeptId");

                    b.Property<string>("Pwd")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("NavDeptId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LTF.Models.DomainModel.UserRoleMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DelFlag");

                    b.Property<int>("NavRoleId");

                    b.Property<int>("NavUserId");

                    b.HasKey("Id");

                    b.HasIndex("NavRoleId");

                    b.HasIndex("NavUserId");

                    b.ToTable("UserRoleMap");
                });

            modelBuilder.Entity("LTF.Models.DomainModel.Log", b =>
                {
                    b.HasOne("LTF.Models.DomainModel.User", "NavUser")
                        .WithMany("NavLogCollection")
                        .HasForeignKey("NavUserId");
                });

            modelBuilder.Entity("LTF.Models.DomainModel.MenuItem", b =>
                {
                    b.HasOne("LTF.Models.DomainModel.MenuGroup", "NavMenuGroup")
                        .WithMany("NavMenuItemCollection")
                        .HasForeignKey("NavMenuGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LTF.Models.DomainModel.RoleMenuMap", b =>
                {
                    b.HasOne("LTF.Models.DomainModel.MenuItem", "NavMenuItem")
                        .WithMany("NavRoleMenuMapCollection")
                        .HasForeignKey("NavMenuItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LTF.Models.DomainModel.Role", "NavRole")
                        .WithMany("NavRoleMenuMapCollection")
                        .HasForeignKey("NavRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LTF.Models.DomainModel.User", b =>
                {
                    b.HasOne("LTF.Models.DomainModel.Department", "NavDept")
                        .WithMany("NavUserCollection")
                        .HasForeignKey("NavDeptId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LTF.Models.DomainModel.UserRoleMap", b =>
                {
                    b.HasOne("LTF.Models.DomainModel.Role", "NavRole")
                        .WithMany("NavUserRoleMapCollection")
                        .HasForeignKey("NavRoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LTF.Models.DomainModel.User", "NavUser")
                        .WithMany("NavUserRoleMapCollection")
                        .HasForeignKey("NavUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
