using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timely.Migrations
{
    public partial class OneTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectsTime_ProjectTimeId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectsTime");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectTimeId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectTimeId",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Projects",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StopDate",
                table: "Projects",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StopDate",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectTimeId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProjectsTime",
                columns: table => new
                {
                    ProjectTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StopDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsTime", x => x.ProjectTimeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTimeId",
                table: "Projects",
                column: "ProjectTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectsTime_ProjectTimeId",
                table: "Projects",
                column: "ProjectTimeId",
                principalTable: "ProjectsTime",
                principalColumn: "ProjectTimeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
