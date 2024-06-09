﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolPlatform.Models;

#nullable disable

namespace SchoolPlatform.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230522135825_updateSubjectMigration")]
    partial class updateSubjectMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolPlatform.Models.Attendance", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendanceId"));

                    b.Property<DateTime>("AbsenceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherSubjectId")
                        .HasColumnType("int");

                    b.HasKey("AttendanceId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherSubjectId")
                        .IsUnique();

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<int>("GradeLevel")
                        .HasColumnType("int");

                    b.Property<int>("HomeroomTeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassId");

                    b.HasIndex("HomeroomTeacherId")
                        .IsUnique();

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("SchoolPlatform.Models.ClassSubject", b =>
                {
                    b.Property<int>("ClassSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassSubjectId"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("ClassSubjectId");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.ToTable("ClassSubjects");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeId"));

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherSubjectId")
                        .HasColumnType("int");

                    b.HasKey("GradeId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherSubjectId")
                        .IsUnique();

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("SchoolPlatform.Models.HomeroomTeacher", b =>
                {
                    b.Property<int>("HomeroomTeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HomeroomTeacherId"));

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("HomeroomTeacherId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("HomeroomTeachers");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("TeacherId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolPlatform.Models.TeacherSubject", b =>
                {
                    b.Property<int>("TeacherSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherSubjectId"));

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("TeacherSubjectId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherSubjects");
                });

            modelBuilder.Entity("SchoolPlatform.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("PersonId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Attendance", b =>
                {
                    b.HasOne("SchoolPlatform.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolPlatform.Models.TeacherSubject", "TeacherSubject")
                        .WithOne("Attendance")
                        .HasForeignKey("SchoolPlatform.Models.Attendance", "TeacherSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("TeacherSubject");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Class", b =>
                {
                    b.HasOne("SchoolPlatform.Models.HomeroomTeacher", "HomeroomTeacher")
                        .WithOne("Class")
                        .HasForeignKey("SchoolPlatform.Models.Class", "HomeroomTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HomeroomTeacher");
                });

            modelBuilder.Entity("SchoolPlatform.Models.ClassSubject", b =>
                {
                    b.HasOne("SchoolPlatform.Models.Class", "Class")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolPlatform.Models.Subject", "Subject")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Grade", b =>
                {
                    b.HasOne("SchoolPlatform.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolPlatform.Models.TeacherSubject", "TeacherSubject")
                        .WithOne("Grade")
                        .HasForeignKey("SchoolPlatform.Models.Grade", "TeacherSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("TeacherSubject");
                });

            modelBuilder.Entity("SchoolPlatform.Models.HomeroomTeacher", b =>
                {
                    b.HasOne("SchoolPlatform.Models.Person", "Person")
                        .WithOne("HomeroomTeacher")
                        .HasForeignKey("SchoolPlatform.Models.HomeroomTeacher", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Student", b =>
                {
                    b.HasOne("SchoolPlatform.Models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolPlatform.Models.Person", "Person")
                        .WithOne("Student")
                        .HasForeignKey("SchoolPlatform.Models.Student", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Teacher", b =>
                {
                    b.HasOne("SchoolPlatform.Models.Person", "Person")
                        .WithOne("Teacher")
                        .HasForeignKey("SchoolPlatform.Models.Teacher", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SchoolPlatform.Models.TeacherSubject", b =>
                {
                    b.HasOne("SchoolPlatform.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolPlatform.Models.Teacher", "Teacher")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolPlatform.Models.User", b =>
                {
                    b.HasOne("SchoolPlatform.Models.Person", "Person")
                        .WithMany("Users")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Class", b =>
                {
                    b.Navigation("ClassSubjects");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolPlatform.Models.HomeroomTeacher", b =>
                {
                    b.Navigation("Class")
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolPlatform.Models.Person", b =>
                {
                    b.Navigation("HomeroomTeacher")
                        .IsRequired();

                    b.Navigation("Student")
                        .IsRequired();

                    b.Navigation("Teacher")
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Student", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Subject", b =>
                {
                    b.Navigation("ClassSubjects");
                });

            modelBuilder.Entity("SchoolPlatform.Models.Teacher", b =>
                {
                    b.Navigation("TeacherSubjects");
                });

            modelBuilder.Entity("SchoolPlatform.Models.TeacherSubject", b =>
                {
                    b.Navigation("Attendance")
                        .IsRequired();

                    b.Navigation("Grade")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
