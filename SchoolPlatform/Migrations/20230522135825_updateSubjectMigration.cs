using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{
    /// <inheritdoc />
    public partial class updateSubjectMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Create procedure UpdateSubject
                @Id INT,
                @SubjectName NVARCHAR(50)
            AS
            BEGIN
                Update Subjects
                Set SubjectName=@SubjectName
                WHERE SubjectId=@Id
            END
        ";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Drop procedure UpdateSubject";
            migrationBuilder.Sql(procedure);
        }
    }
}
