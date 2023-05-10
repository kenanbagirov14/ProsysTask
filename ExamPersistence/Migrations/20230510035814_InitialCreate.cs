using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamPersistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Teachers_IsDeleted",
                table: "Teachers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IsDeleted",
                table: "Students",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_IsDeleted",
                table: "Lessons",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_IsDeleted",
                table: "Exams",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_IsDeleted",
                table: "ClassRooms",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_IsDeleted",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_IsDeleted",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_IsDeleted",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Exams_IsDeleted",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_ClassRooms_IsDeleted",
                table: "ClassRooms");
        }
    }
}
