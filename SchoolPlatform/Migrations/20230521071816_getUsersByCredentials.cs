using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{

    public partial class getUsersByCredentials : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Create procedure GetUsersByCredentials
                @Email NVARCHAR(100),
                @Password NVARCHAR(100)
            AS
            BEGIN
                SELECT *
                FROM Users
                WHERE Email = @Email AND Password = @Password
            END
        ";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Drop procedure GetUsersByCredentials";
            migrationBuilder.Sql(procedure);
        }
    }
}
