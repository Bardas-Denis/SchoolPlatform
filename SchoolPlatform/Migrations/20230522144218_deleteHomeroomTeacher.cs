using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{
    /// <inheritdoc />
    public partial class deleteHomeroomTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Create procedure DeleteHomeroomTeacher
                @Id INT
            AS
            BEGIN
                Delete 
                FROM HomeroomTeachers
                WHERE HomeroomTeacherId=@Id
            END
        ";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Drop procedure DeleteHomeroomTeacher";
            migrationBuilder.Sql(procedure);
        }
    }
}
