using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LTF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DelFlag = table.Column<int>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DelFlag = table.Column<int>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DelFlag = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DelFlag = table.Column<int>(nullable: false),
                    JobNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NavDeptId = table.Column<int>(nullable: false),
                    Pwd = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Department_NavDeptId",
                        column: x => x.NavDeptId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ClientRouter = table.Column<string>(nullable: true),
                    DelFlag = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NavMenuGroupId = table.Column<int>(nullable: false),
                    ServerRouter = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_MenuGroup_NavMenuGroupId",
                        column: x => x.NavMenuGroupId,
                        principalTable: "MenuGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DelFlag = table.Column<int>(nullable: false),
                    LogLevel = table.Column<string>(nullable: true),
                    Msg = table.Column<string>(nullable: true),
                    NavUserId = table.Column<int>(nullable: false),
                    RequestUrl = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_User_NavUserId",
                        column: x => x.NavUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DelFlag = table.Column<int>(nullable: false),
                    NavRoleId = table.Column<int>(nullable: false),
                    NavUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleMap_Role_NavRoleId",
                        column: x => x.NavRoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleMap_User_NavUserId",
                        column: x => x.NavUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenuMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DelFlag = table.Column<int>(nullable: false),
                    NavMenuItemId = table.Column<int>(nullable: false),
                    NavRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenuMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleMenuMap_MenuItem_NavMenuItemId",
                        column: x => x.NavMenuItemId,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleMenuMap_Role_NavRoleId",
                        column: x => x.NavRoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_NavUserId",
                table: "Log",
                column: "NavUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_NavMenuGroupId",
                table: "MenuItem",
                column: "NavMenuGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenuMap_NavMenuItemId",
                table: "RoleMenuMap",
                column: "NavMenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenuMap_NavRoleId",
                table: "RoleMenuMap",
                column: "NavRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_NavDeptId",
                table: "User",
                column: "NavDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMap_NavRoleId",
                table: "UserRoleMap",
                column: "NavRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMap_NavUserId",
                table: "UserRoleMap",
                column: "NavUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "RoleMenuMap");

            migrationBuilder.DropTable(
                name: "UserRoleMap");

            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MenuGroup");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
