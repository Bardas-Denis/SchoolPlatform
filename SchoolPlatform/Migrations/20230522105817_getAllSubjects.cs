using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{
    /// <inheritdoc />
    public partial class getAllSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Create Procedure GetAllSubjects
            AS
            BEGIN
                  Select * from Subjects;
            END;
        ";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Drop procedure GetAllSubjects";
            migrationBuilder.Sql(procedure);
        }
    }
}
