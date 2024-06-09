using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addAbsence2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure AddAbsence2
                   @TSId INT,
                   @StudentId INT,
                   @date DateTime
            AS
            BEGIN
                   INSERT INTO Attendances (TeacherSubjectId,StudentId,AbsenceDate)
                   VALUES (@TSId, @StudentId, @date);
            END;";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Drop procedure AddAbsence2";
            migrationBuilder.Sql(procedure);
        }
    }
}
