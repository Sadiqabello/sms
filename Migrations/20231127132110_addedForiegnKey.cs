using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    /// <inheritdoc />
    public partial class addedForiegnKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "ClassManagements");

            migrationBuilder.DropColumn(
                name: "LecturerName",
                table: "ClassManagements");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "ClassManagements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LecturerId",
                table: "ClassManagements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClassManagements_CourseId",
                table: "ClassManagements",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassManagements_LecturerId",
                table: "ClassManagements",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassManagements_Courses_CourseId",
                table: "ClassManagements",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassManagements_Lecturers_LecturerId",
                table: "ClassManagements",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassManagements_Courses_CourseId",
                table: "ClassManagements");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassManagements_Lecturers_LecturerId",
                table: "ClassManagements");

            migrationBuilder.DropIndex(
                name: "IX_ClassManagements_CourseId",
                table: "ClassManagements");

            migrationBuilder.DropIndex(
                name: "IX_ClassManagements_LecturerId",
                table: "ClassManagements");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "ClassManagements");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "ClassManagements");

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "ClassManagements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LecturerName",
                table: "ClassManagements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
