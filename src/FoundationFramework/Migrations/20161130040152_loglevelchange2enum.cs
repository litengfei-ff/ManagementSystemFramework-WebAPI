using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LTF.Migrations
{
    public partial class loglevelchange2enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LogLevel",
                table: "Log",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LogLevel",
                table: "Log",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
