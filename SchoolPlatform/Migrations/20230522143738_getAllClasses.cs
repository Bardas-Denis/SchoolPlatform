using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{
    /// <inheritdoc />
    public partial class getAllClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Create Procedure GetAllClasses
            AS
            BEGIN
                  Select * from Classes;
            END;
        ";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Drop procedure GetAllClasses";
            migrationBuilder.Sql(procedure);
        }
    }
}
