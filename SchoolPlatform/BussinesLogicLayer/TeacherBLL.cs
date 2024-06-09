using Microsoft.EntityFrameworkCore;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;

namespace SchoolPlatform.BussinesLogicLayer
{
    public class TeacherBLL
    {
        private MyContext context = new MyContext();
        public ObservableCollection<Teacher> TeachersList { get; set; }
        public void AddTeacherMethod()
        {
            AddTeacher addTeacher = new AddTeacher();
            string firstName = "";
            string lastName = "";
            DateTime birthdate = DateTime.Now;
            string email = "";
            string password = "";
            string degree = "";
            bool verify = true;
            addTeacher.Closed += (s, args) =>
            {
                firstName = addTeacher.FirstNameTextBox.Text;
                lastName = addTeacher.LastNameTextBox.Text;
                if (addTeacher.BirthDateTextBox.Text != "")
                {
                    birthdate = DateTime.Parse(addTeacher.BirthDateTextBox.Text);
                }
                email = addTeacher.EmailTextBox.Text;
                password = addTeacher.PassTextBox.Text;
                degree = addTeacher.DegreeTextBox.Text;
                if(firstName=="" || lastName=="" ||  email=="" || password=="" || degree=="")
                {
                    verify = false;
                }
            };
            addTeacher.ShowDialog();
            if (verify)
            {
                Person newPerson = new Person { FirstName = firstName, LastName = lastName, BirthDate = birthdate };
                context.People.Add(newPerson);
                context.SaveChanges();
                User newUser = new User { PersonId = newPerson.PersonId, Email = email, Password = password, Role = Roles.Teacher };
                context.Users.Add(newUser);
                context.SaveChanges();
                Teacher newTeacher = new() { PersonId = newPerson.PersonId, Degree = degree };
                context.Teachers.Add(newTeacher);
                context.SaveChanges();
                TeachersList.Add(newTeacher);
            }
            else
            {
                MessageBox.Show("The data introduced was not correct or was missing");
            }
        }
        public void UpdateTeacherMethod(object obj)
        {
            Teacher teach = obj as Teacher;
            if (teach != null)
            {
                AddTeacher addTeacher = new AddTeacher();
                string firstName = "";
                string lastName = "";
                DateTime birthdate = DateTime.Now;
                string email = "";
                string password = "";
                string degree = "";
                bool verify = true;
                addTeacher.Closed += (s, args) =>
                {
                    firstName = addTeacher.FirstNameTextBox.Text;
                    lastName = addTeacher.LastNameTextBox.Text;
                    if (addTeacher.BirthDateTextBox.Text != "")
                    {
                        birthdate = DateTime.Parse(addTeacher.BirthDateTextBox.Text);
                    }
                    email = addTeacher.EmailTextBox.Text;
                    password = addTeacher.PassTextBox.Text;
                    degree = addTeacher.DegreeTextBox.Text;
                    if (firstName == "" || lastName == "" || email == "" || password == "" || degree == "")
                    {
                        verify = false;
                    }
                };
                addTeacher.ShowDialog();
                if (verify)
                {

                    var person = context.People.FirstOrDefault(p => p.PersonId == teach.PersonId);
                    person.FirstName = firstName; person.LastName = lastName; person.BirthDate = birthdate;
                    context.Update(person);
                    context.SaveChanges();

                    var user = context.Users.FirstOrDefault(u => u.PersonId == teach.PersonId);
                    user.Email = email; user.Password = password;
                    context.Update(user);
                    context.SaveChanges();

                    var modified_teach=context.Teachers.FirstOrDefault(t=>t.TeacherId == teach.TeacherId);
                    modified_teach.Degree = degree;
                    context.Update(modified_teach);
                    context.SaveChanges();
                    
                }
                else
                {
                    MessageBox.Show("The data introduced was not correct or was missing");
                }
            }
            else
            {
                MessageBox.Show("Please select a teacher");
            }
        }
        public void DeleteTeacherMethod(object obj)
        {
            Teacher teach = obj as Teacher;
            if (teach != null)
            {
                context.People.Remove(teach.Person);
                context.Teachers.Remove(teach);
                context.SaveChanges();
                TeachersList.Remove(teach);
            }
            else
            {
                MessageBox.Show("Please select a teacher");
            }
        }
        public ObservableCollection<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = context.Teachers.Include(s => s.Person).ToList();
            ObservableCollection<Teacher> result = new ObservableCollection<Teacher>();
            foreach (Teacher stud in teachers)
            {
                result.Add(stud);
            }
            return result;
        }
    }
}
