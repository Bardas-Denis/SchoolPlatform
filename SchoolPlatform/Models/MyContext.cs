using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class MyContext: DbContext
    {   
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<HomeroomTeacher> HomeroomTeachers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<ClassSubject> ClassSubjects { get; set; }
        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public MyContext() : base(GetDbContextOptions())
        {

        }

        private static string GetConnectionString()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder();

            

            connectionStringBuilder.DataSource = "DESKTOP-R06FFU1";
            connectionStringBuilder.InitialCatalog = "SchoolPlatformDatabase";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.TrustServerCertificate = true;

            return connectionStringBuilder.ToString();
        }

        private static DbContextOptions<MyContext> GetDbContextOptions()
        {
            var connectionString = GetConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return optionsBuilder.Options;

        }
    }

}
