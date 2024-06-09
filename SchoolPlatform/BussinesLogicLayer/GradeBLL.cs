using Microsoft.EntityFrameworkCore;
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
    class GradeBLL
    {
        private MyContext context = new MyContext();
        public ObservableCollection<Grade>? GradesList { get; set; }
        public void AddGradeMethod(object obj, User user)
        {
            Student student = obj as Student;
            if (student != null)
            {
                AddGrade addGrade = new AddGrade();
                int grade = 0;
                bool verify = true;
                addGrade.Closed += (s, args) =>
                {
                    if(addGrade.gradeTextBox.Text!="")
                    {
                        grade = int.Parse(addGrade.gradeTextBox.Text);
                    }
                    else
                    {
                        verify=false;
                    }
                };
                addGrade.ShowDialog();
                if(verify)
                {
                    if (grade > 0 && grade < 11)
                    {
                        var teacher = context.Teachers.First(t => t.PersonId == user.PersonId);
                        var ts = context.TeacherSubjects.First(t => t.TeacherId == teacher.TeacherId);
                        var id = ts.TeacherSubjectId;
                        var id1 = student.StudentId;
                        context.Database.ExecuteSqlInterpolated($"AddGrade {id},{id1},{grade}");
                       
                        context.SaveChanges();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a grade");
                }
                
            }
        }
        public void DeleteGradeMethod(object obj)
        {
            Grade grade = obj as Grade;
            if (grade != null)
            {
               
                context.Grades.Remove(grade);
                context.SaveChanges();
                GradesList.Remove(grade);
            }
            else
            {
                MessageBox.Show("Please select a grade");
            }
        }
        public ObservableCollection<Grade> GetAllGradesForStudent(object obj)
        {
            Student student;
            if(obj is Student)
            {
                student = obj as Student;
            }
            else
            {
                User user=obj as User;
                student = context.Students.Where(s => s.PersonId == user.PersonId).FirstOrDefault();
            }

            List<Grade> grades=context.Grades.Where(g=>g.StudentId==student.StudentId).ToList();
            
            ObservableCollection<Grade> result = new ObservableCollection<Grade>();
            foreach (Grade gr in grades)
            {
                result.Add(gr);
            }
            return result;
        }
    }
}
