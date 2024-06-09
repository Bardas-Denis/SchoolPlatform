using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{
    /// <inheritdoc />
    public partial class deleteHomeroomTeacherMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Create procedure DeleteHomeroomTeacher2
                @Id INT,
                @PersonId INT
            AS
            BEGIN
                SET NOCOUNT ON;
                Delete 
                FROM HomeroomTeachers
                WHERE HomeroomTeacherId=@Id
                Delete From Users where PersonId=@PersonId and Role=3
            END
        ";
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Drop procedure DeleteHomeroomTeacher2";
            migrationBuilder.Sql(procedure);
        }
    }
}
