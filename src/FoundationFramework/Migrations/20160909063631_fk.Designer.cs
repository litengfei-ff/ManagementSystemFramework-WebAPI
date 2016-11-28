using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FoundationFramework.Models;

namespace FoundationFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160909063631_fk")]
    partial class fk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-preview1-22509")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoundationFramework.Models.DomainModel.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DelFlag");

                    b.Property<string>("DepartmentName");

                    b.Property<int>("Level");

                    b.Property<int>("ParentId");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("FoundationFramework.Models.DomainModel.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("DelFlag");

                    b.Property<string>("LogLevel");

                    b.Property<string>("Msg");

                    b.Property<int>("NavUserId");

                    b.Property<string>("RequestUrl");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.HasIndex("NavUserId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("FoundationFramework.Models.DomainModel.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DelFlag");

                    b.Property<string>("JobNumber")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<int>("NavDeptId");

                    b.Property<string>("Pwd")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("NavDeptId");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("FoundationFramework.Models.DomainModel.Log", b =>
                {
                    b.HasOne("FoundationFramework.Models.DomainModel.UserInfo", "NavUser")
                        .WithMany("NavLog")
                        .HasForeignKey("NavUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FoundationFramework.Models.DomainModel.UserInfo", b =>
                {
                    b.HasOne("FoundationFramework.Models.DomainModel.Department", "NavDept")
                        .WithMany("NavUser")
                        .HasForeignKey("NavDeptId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
