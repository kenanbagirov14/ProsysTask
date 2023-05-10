using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPersistence.Migrations
{
    public partial class teacherIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Teachers");
        }
    }
}
