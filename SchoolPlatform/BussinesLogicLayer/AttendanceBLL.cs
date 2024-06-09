using Microsoft.EntityFrameworkCore;
using SchoolPlatform.Models;
using SchoolPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolPlatform.BussinesLogicLayer
{
    class AttendanceBLL
    {
        private MyContext context = new MyContext();
        public ObservableCollection<Attendance>? AttendancesList { get; set; }
        public void AddAttendanceMethod(object obj, User user)
        {
            Student student = obj as Student;
            if (student != null)
            {
                AddAbsence addAbsence = new AddAbsence();
                DateTime dateTime = DateTime.Now;
                bool verify = true;
                addAbsence.Closed += (s, args) =>
                {
                    if (addAbsence.absenceTextBox.Text != "")
                    {
                        dateTime= DateTime.Parse(addAbsence.absenceTextBox.Text);
                    }
                    else
                    {
                        verify = false;
                    }
                };
                addAbsence.ShowDialog();
                if (verify)
                {
                        var teacher = context.Teachers.First(t => t.PersonId == user.PersonId);
                        var ts = context.TeacherSubjects.First(t => t.TeacherId == teacher.TeacherId);
                        var id = ts.TeacherSubjectId;
                        var id1 = student.StudentId;
                        context.Database.ExecuteSqlInterpolated($"AddAbsence2 {id},{id1},{dateTime}");
                        context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Please enter a date");
                }

            }
        }
        public void DeleteAbsenceMethod(object obj)
        {
            Attendance absence = obj as Attendance;
            if (absence != null)
            {

                context.Attendances.Remove(absence);
                context.SaveChanges();
                AttendancesList.Remove(absence);
            }
            else
            {
                MessageBox.Show("Please select a absence");
            }
        }
        public ObservableCollection<Attendance> GetAllAttendancesForStudent(object obj)
        {
            Student student;
            if (obj is Student)
            {
                student = obj as Student;
            }
            else
            {
                User user = obj as User;
                student = context.Students.Where(s => s.PersonId == user.PersonId).FirstOrDefault();
            }
            List<Attendance> attendances = context.Attendances.Where(g => g.StudentId == student.StudentId).ToList();

            ObservableCollection<Attendance> result = new ObservableCollection<Attendance>();
            foreach (Attendance gr in attendances)
            {
                result.Add(gr);
            }
            return result;
        }
    }
}
