using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPlatform.Migrations
{

    public partial class addClass : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Create Procedure AddClass
                   @TeacherId INT,
                   @Specialization NVARCHAR(50),
                   @GradeLevel INT
            AS
            BEGIN
                   INSERT INTO Classes (HomeroomTeacherId, Specialization, GradeLevel)
                   VALUES (@TeacherId, @Specialization, @GradeLevel);
            END;
        ";
            migrationBuilder.Sql(procedure);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
            Drop procedure AddClass";
            migrationBuilder.Sql(procedure);
        }
    }
}
