using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolPlatform.BussinesLogicLayer
{
    class ClassBLL
    {
        private MyContext context = new MyContext();
        public ObservableCollection<Class> ClassesList { get; set; } 
        public void AddClassMethod()
        {
            AddClass addClass = new AddClass();
            string firstName = "";
            string lastName = "";
            string specialization = "";
            int gradeLevel = 9;
            bool verify = true;
            addClass.Closed += (s, args) =>
            {
                firstName = addClass.FirstNameTextBox.Text;
                lastName = addClass.LastNameTextBox.Text;
                specialization = addClass.SpecializationTextBox.Text;
                gradeLevel=int.Parse(addClass.GradeLevelTextBox.Text);
                if (firstName == "" || lastName == "" || specialization == "" || gradeLevel <9 || gradeLevel>12)
                {
                    verify = false;
                }
            };
            addClass.ShowDialog();
            if (verify)
            {
                Person person = context.People.Include(p => p.Users).FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);
                if (person != null && person.Users.FirstOrDefault(u => u.Role == Roles.HomeroomTeacher) != null)
                {
                    HomeroomTeacher homeroomTeacher = context.HomeroomTeachers.FirstOrDefault(p => p.PersonId == person.PersonId);
                    int newClassHMTId = homeroomTeacher.HomeroomTeacherId;
                    context.Database.ExecuteSqlInterpolated($"AddClass {newClassHMTId},{specialization},{gradeLevel}");
                    context.SaveChanges();
                    var newClass=context.Classes.First(c=>c.HomeroomTeacherId==newClassHMTId);
                    ClassesList.Add(newClass);
                }
                else
                {
                    MessageBox.Show("The homeroomteacher does not exist");
                }
            }
            else
            {
                MessageBox.Show("Some data is missing or is not correct");
            }
        }
        public void DeleteClassMethod(object obj)
        {
            Class class1 = obj as Class;
            if (class1 != null)
            {
                int classId = class1.ClassId;
                context.Database.ExecuteSqlInterpolatedAsync($"DeleteClass {classId}");
                context.SaveChanges();
                ClassesList.Remove(class1);
            }
            else
            {
                MessageBox.Show("Please select a class");
            }
        }
        public void UpdateClassMethod(object obj)
        {
            AddClass addClass = new AddClass();
            string firstName = "";
            string lastName = "";
            string specialization = "";
            int gradeLevel = 9;
            bool verify = true;
            addClass.Closed += (s, args) =>
            {
                firstName = addClass.FirstNameTextBox.Text;
                lastName = addClass.LastNameTextBox.Text;
                specialization = addClass.SpecializationTextBox.Text;
                gradeLevel = int.Parse(addClass.GradeLevelTextBox.Text);
                if (firstName == "" || lastName == "" || specialization == "" || gradeLevel < 9 || gradeLevel > 12)
                {
                    verify = false;
                }
            };
            addClass.ShowDialog();
            if (verify)
            {
                Class class1 = obj as Class;
                int id = class1.ClassId;
                Person person = context.People.Include(p => p.Users).FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);
                if (person != null && person.Users.FirstOrDefault(u => u.Role == Roles.HomeroomTeacher) != null)
                {
                    HomeroomTeacher homeroomTeacher = context.HomeroomTeachers.FirstOrDefault(p => p.PersonId == person.PersonId);
                    int newClassHMTId = homeroomTeacher.HomeroomTeacherId;
                    context.Database.ExecuteSqlInterpolatedAsync($"UpdateClass {id},{newClassHMTId},{specialization},{gradeLevel}");
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("The homeroomteacher does not exist");
                }
            }
            else
            {
                MessageBox.Show("Some data is missing or is not correct");
            }
        }
        public ObservableCollection<Class> GetAllClasses()
        {
            List<Class> classes = context.Classes.FromSqlInterpolated($"GetAllClasses").ToList();
            ObservableCollection<Class> result = new ObservableCollection<Class>();
            foreach (Class class1 in classes)
            {
                result.Add(class1);
            }
            return result;
        }
        public ObservableCollection<Class> GetAllClassesFromTeacher(User user)
        {
            var teacher=context.Teachers.First(t=>t.PersonId == user.PersonId);
            var ts = context.TeacherSubjects.First(t => t.TeacherId == teacher.TeacherId);
            var subject = context.Subjects.First(s => s.SubjectId == ts.SubjectId);
            var cs=context.ClassSubjects.First(cs=>cs.SubjectId == subject.SubjectId);
            List<Class> classes=context.Classes.Where(c=>c.ClassId==cs.ClassId).ToList();
            ObservableCollection<Class> result = new ObservableCollection<Class>();
            foreach (Class class1 in classes)
            {
                result.Add(class1);
            }
            return result;
        }
    }
}
