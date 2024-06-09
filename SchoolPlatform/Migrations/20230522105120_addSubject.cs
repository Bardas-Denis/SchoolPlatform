using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Create Procedure AddSubject
                   @SubjectName NVARCHAR(50)
            AS
            BEGIN
                   INSERT INTO Subjects (SubjectName)
                   VALUES (@SubjectName);
            END;
        ";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            string procedure = @"
            Drop procedure AddSubject";
            migrationBuilder.Sql(procedure);
        }
    }
}
