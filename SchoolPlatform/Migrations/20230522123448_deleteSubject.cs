using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{
    /// <inheritdoc />
    public partial class deleteSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Create procedure DeleteSubject
                @Id INT
            AS
            BEGIN
                Delete 
                FROM Subjects
                WHERE SubjectId=@Id
            END
        ";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Drop procedure DeleteSubject";
            migrationBuilder.Sql(procedure);
        }
    }
}
