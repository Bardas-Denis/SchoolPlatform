using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{
    /// <inheritdoc />
    public partial class deleteClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Create procedure DeleteClass
                @Id INT
            AS
            BEGIN
                Delete 
                FROM Classes
                WHERE ClassId=@Id
            END
        ";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Drop procedure DeleteClass";
            migrationBuilder.Sql(procedure);
        }
    }
}
