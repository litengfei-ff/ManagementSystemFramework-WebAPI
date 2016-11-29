using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LTF.Migrations
{
    public partial class lognullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_User_NavUserId",
                table: "Log");

            migrationBuilder.AlterColumn<int>(
                name: "NavUserId",
                table: "Log",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Log_User_NavUserId",
                table: "Log",
                column: "NavUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_User_NavUserId",
                table: "Log");

            migrationBuilder.AlterColumn<int>(
                name: "NavUserId",
                table: "Log",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_User_NavUserId",
                table: "Log",
                column: "NavUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
