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
    class SubjectBLL
    {
        private MyContext context = new MyContext();
        public ObservableCollection<Subject> SubjectsList { get; set; }
        public void AddSubjectMethod()
        {
            AddSubject addSubject = new AddSubject();
            string subjectName = "";
            bool verify = true;
            addSubject.Closed += (s, args) =>
            {
                subjectName = addSubject.SubjectNameTextBox.Text;
                if (subjectName == "")
                {
                    verify = false;
                }
            };
            addSubject.ShowDialog();
            if (verify)
            {
                if (context.Subjects.FirstOrDefault(s => s.SubjectName == subjectName) == null)
                {
                    context.Database.ExecuteSqlInterpolatedAsync($"AddSubject {subjectName}");
                    context.SaveChanges();
                    
                }
                else
                {
                    MessageBox.Show("The subject already exists");
                }
            }
            else
            {
                MessageBox.Show("Some data is missing");
            }
        }
        public void DeleteSubjectMethod(object obj)
        {
            Subject subject = obj as Subject;
            if (subject != null)
            {
                int id = subject.SubjectId;
                context.Database.ExecuteSqlInterpolatedAsync($"DeleteSubject {id}");
                context.SaveChanges();
                SubjectsList.Remove(subject);
            }
            else
            {
                MessageBox.Show("Please select a subject");
            }
        }
        public void ModifySubjectMethod(object obj) 
        {
            Subject subject = obj as Subject;
            if (subject != null)
            {
                int subjId=subject.SubjectId;
                AddSubject addSubject = new AddSubject();
                string subjectName = "";
                bool verify = true;
                addSubject.Closed += (s, args) =>
                {
                    subjectName = addSubject.SubjectNameTextBox.Text;
                    if (subjectName == "")
                    {
                        verify = false;
                    }
                };
                addSubject.ShowDialog();
                if (verify)
                {
                    if (context.Subjects.FirstOrDefault(s => s.SubjectName == subjectName) == null)
                    {
                        context.Database.ExecuteSqlInterpolatedAsync($"UpdateSubject {subjId},{subjectName}");
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("The subject already exists");
                    }
                }
                else
                {
                    MessageBox.Show("Some data is missing");
                }
            }
            else
            {
                MessageBox.Show("Please select a subject");
            }
        }
        public ObservableCollection<Subject> GetAllSubjects()
        {
            List<Subject> subjects = context.Subjects.FromSqlInterpolated($"GetAllSubjects").ToList();
            ObservableCollection<Subject> result = new ObservableCollection<Subject>();
            foreach (Subject subj in subjects)
            {
                result.Add(subj);
            }
            return result;
        }
    }
}
