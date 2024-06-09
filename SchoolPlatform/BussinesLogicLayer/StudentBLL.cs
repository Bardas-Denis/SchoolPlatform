using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class StudentBLL
    {
        private MyContext context = new MyContext();
        public ObservableCollection<Student>? StudentsList { get; set; }
        public void AddStudentMethod()
        {
            AddStudent addStudent = new AddStudent();
            string firstName = "";
            string lastName = "";
            DateTime birthdate = DateTime.Now;
            string email = "";
            string password = "";
            string specialization = "";
            int gradeLevel = 9;
            bool verify = true;
            addStudent.Closed += (s, args) =>
            {
                if (addStudent.FirstNameTextBox.Text != "")
                {

                    firstName = addStudent.FirstNameTextBox.Text;
                }
                else
                {
                    verify = false;
                }
                if (addStudent.LastNameTextBox.Text != "")
                {
                    lastName = addStudent.LastNameTextBox.Text;
                }
                else
                {
                    verify = false;
                }
                if (addStudent.BirthDateTextBox.Text != "")
                {
                    birthdate = DateTime.Parse(addStudent.BirthDateTextBox.Text);
                }
                else
                {
                    verify = false;
                }
                if (addStudent.EmailTextBox.Text != "")
                {
                    email = addStudent.EmailTextBox.Text;
                }
                else
                {
                    verify = false;
                }
                if (addStudent.PassTextBox.Text != "")
                {
                    password = addStudent.PassTextBox.Text;
                }
                else
                {
                    verify = false;
                }
                if (addStudent.SpecializationTextBox.Text != "")
                {
                    specialization = addStudent.SpecializationTextBox.Text;
                }
                else
                {
                    verify = false;
                }
                if(addStudent.ClassTextBox.Text!="")
                {
                    gradeLevel = int.Parse(addStudent.ClassTextBox.Text);
                }
                else { verify = false; }
            };
            addStudent.ShowDialog();
            var class1 = context.Classes.FirstOrDefault(c => c.Specialization == specialization && c.GradeLevel == gradeLevel);
            int classId = 1;
            if (class1 == null)
            {
                verify = false;
            }
            else
            {
                classId = class1.ClassId;
            }
            if(verify)
            {
                Person newPerson = new Person { FirstName = firstName, LastName = lastName, BirthDate = birthdate };
                context.People.Add(newPerson);
                context.SaveChanges();
                User newUser = new User { PersonId = newPerson.PersonId, Email = email, Password = password, Role = Roles.Student };
                context.Users.Add(newUser);
                context.SaveChanges();

                Student newStudent = new() { ClassId = classId, PersonId = newPerson.PersonId };
                context.Students.Add(newStudent);
                context.SaveChanges();
                StudentsList.Add(newStudent);
            }
            else
            {
                MessageBox.Show("The data introduced was not correct or was missing");
            }
            
        }
        public void UpdateStudentMethod(object obj)
        {
            Student student = obj as Student;
            if(student != null)
            {
                AddStudent addStudent = new AddStudent();
                string firstName = "";
                string lastName = "";
                DateTime birthdate = DateTime.Now;
                string email = "";
                string password = "";
                string specialization = "";
                int gradeLevel = 9;
                bool verify = true;
                addStudent.Closed += (s, args) =>
                {
                    if (addStudent.FirstNameTextBox.Text != "")
                    {

                        firstName = addStudent.FirstNameTextBox.Text;
                    }
                    else
                    {
                        verify = false;
                    }
                    if (addStudent.LastNameTextBox.Text != "")
                    {
                        lastName = addStudent.LastNameTextBox.Text;
                    }
                    else
                    {
                        verify = false;
                    }
                    if (addStudent.BirthDateTextBox.Text != "")
                    {
                        birthdate = DateTime.Parse(addStudent.BirthDateTextBox.Text);
                    }
                    else
                    {
                        verify = false;
                    }
                    if (addStudent.EmailTextBox.Text != "")
                    {
                        email = addStudent.EmailTextBox.Text;
                    }
                    else
                    {
                        verify = false;
                    }
                    if (addStudent.PassTextBox.Text != "")
                    {
                        password = addStudent.PassTextBox.Text;
                    }
                    else
                    {
                        verify = false;
                    }
                    if (addStudent.SpecializationTextBox.Text != "")
                    {
                        specialization = addStudent.SpecializationTextBox.Text;
                    }
                    else
                    {
                        verify = false;
                    }
                    if (addStudent.ClassTextBox.Text != "")
                    {
                        gradeLevel = int.Parse(addStudent.ClassTextBox.Text);
                    }
                    else { verify = false; }
                };
                addStudent.ShowDialog();
                var class1 = context.Classes.FirstOrDefault(c => c.Specialization == specialization && c.GradeLevel == gradeLevel);
                int classId = 1;
                if (class1 == null)
                {
                    verify = false;
                }
                else
                {
                    classId = class1.ClassId;
                }
                if (verify)
                {
                    var person=context.People.FirstOrDefault(p=>p.PersonId==student.PersonId);
                    person.FirstName=firstName; person.LastName=lastName;person.BirthDate = birthdate;
                    context.Update(person);
                    context.SaveChanges();
                    var user=context.Users.FirstOrDefault(u=>u.PersonId==student.PersonId);
                    user.Email = email;user.Password=password;
                    context.Update(user);
                    context.SaveChanges();
                    var modiefied_student = context.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
                    modiefied_student.ClassId = classId;
                    context.Update(modiefied_student);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("The data introduced was not correct or was missing");
                }
            }
            else
            {
                MessageBox.Show("Please select a student");
            }
        }
        public void DeleteStudentMethod(object obj)
        {
            Student stud = obj as Student;
            if (stud != null)
            {
                context.People.Remove(stud.Person);
                context.Students.Remove(stud);
                context.SaveChanges();
                StudentsList.Remove(stud);
            }
            else
            {
                MessageBox.Show("Please select a student");
            }
        }

        public ObservableCollection<Student> GetAllStudents()
        {
            List<Student> students = context.Students.Include(s => s.Person).ToList();
            ObservableCollection<Student> result = new ObservableCollection<Student>();
            foreach (Student stud in students)
            {
                result.Add(stud);
            }
            return result;
        }
        public ObservableCollection<Student> GetAllStudentsFromClass(object obj)
        {
            Class class1= obj as Class;
            List<Student> students=context.Students.Where(s=>s.ClassId==class1.ClassId).Include(p=>p.Person).ToList();
            ObservableCollection<Student> result = new ObservableCollection<Student>();
            foreach (Student stud in students)
            {
                result.Add(stud);
            }
            return result;
        }
    }
}
