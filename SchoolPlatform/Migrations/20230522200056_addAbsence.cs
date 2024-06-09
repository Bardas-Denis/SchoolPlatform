using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addAbsence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure AddAbsence
                   @TSId INT,
                   @StudentId INT,
                   @date DateTime
            AS
            BEGIN
                   INSERT INTO Attendance (TeacherSubjectId,StudentId,AbsenceDate)
                   VALUES (@TSId, @StudentId, @date);
            END;";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Drop procedure AddAbsence";
            migrationBuilder.Sql(procedure);
        }
    }
}
