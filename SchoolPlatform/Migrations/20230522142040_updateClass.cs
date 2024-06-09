using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{
    /// <inheritdoc />
    public partial class updateClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            string procedure = @"
            Create procedure UpdateClass
                @Id INT,
                @HMTId INT,
@Specialization NVARCHAR(50),
@GradeLevel INT
            AS
            BEGIN
                Update Classes
                Set HomeroomTeacherId=@HMTId, Specialization=@Specialization, GradeLevel=@GradeLevel
                WHERE ClassId=@Id
            END
        ";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Drop procedure UpdateClass";
            migrationBuilder.Sql(procedure);
        }
    }
}
