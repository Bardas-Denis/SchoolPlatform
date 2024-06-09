using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addGrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Students_StudentId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_TeacherSubjects_TeacherSubjectId",
                table: "Attendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_TeacherSubjectId",
                table: "Attendances",
                newName: "IX_Attendances_TeacherSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_StudentId",
                table: "Attendances",
                newName: "IX_Attendances_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Students_StudentId",
                table: "Attendances",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_TeacherSubjects_TeacherSubjectId",
                table: "Attendances",
                column: "TeacherSubjectId",
                principalTable: "TeacherSubjects",
                principalColumn: "TeacherSubjectId",
                onDelete: ReferentialAction.Restrict);
            string procedure = @"Create Procedure AddGrade
                   @TSId INT,
                   @StudentId INT,
                   @Mark INT
            AS
            BEGIN
                   INSERT INTO Grades (TeacherSubjectId,StudentId,Mark)
                   VALUES (@TSId, @StudentId, @Mark);
            END;";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Students_StudentId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_TeacherSubjects_TeacherSubjectId",
                table: "Attendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_TeacherSubjectId",
                table: "Attendance",
                newName: "IX_Attendance_TeacherSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendance",
                newName: "IX_Attendance_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Students_StudentId",
                table: "Attendance",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_TeacherSubjects_TeacherSubjectId",
                table: "Attendance",
                column: "TeacherSubjectId",
                principalTable: "TeacherSubjects",
                principalColumn: "TeacherSubjectId",
                onDelete: ReferentialAction.NoAction);
            string procedure = @"
            Drop procedure AddGrade";
            migrationBuilder.Sql(procedure);
        }
    }
}
