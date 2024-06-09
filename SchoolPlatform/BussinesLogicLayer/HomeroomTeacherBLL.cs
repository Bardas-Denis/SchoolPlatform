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
    class HomeroomTeacherBLL
    {

        private MyContext context = new MyContext();
        public ObservableCollection<HomeroomTeacher> HomeroomTeachersList { get; set; }
        public void AddHomeroomTeacherMethod()
        {
            AddHomeroomTeacher addHomeroomTeacher = new AddHomeroomTeacher();
            string firstName = "";
            string lastName = "";
            string email = "";
            string password = "";
            bool verify = true;
            addHomeroomTeacher.Closed += (s, args) =>
            {
                firstName = addHomeroomTeacher.FirstNameTextBox.Text;
                lastName = addHomeroomTeacher.LastNameTextBox.Text;
                email = addHomeroomTeacher.EmailTextBox.Text;
                password = addHomeroomTeacher.PassTextBox.Text;
                if (firstName == "" || lastName == "" || email == "" || password == "")
                {
                    verify = false;
                }
            };
            addHomeroomTeacher.ShowDialog();
            if (verify)
            {
                Person person = context.People.Include(p => p.Users).FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);
                if (person != null && person.Users.FirstOrDefault(u => u.Role == Roles.Teacher) != null)
                {

                    User newUser = new User { PersonId = person.PersonId, Email = email, Password = password, Role = Roles.HomeroomTeacher };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    HomeroomTeacher newHomeroomTeacher = new() { PersonId = person.PersonId };
                    context.HomeroomTeachers.Add(newHomeroomTeacher);
                    context.SaveChanges();
                    HomeroomTeachersList.Add(newHomeroomTeacher);

                }
                else
                {
                    MessageBox.Show("This teacher does not exist");
                }
            }
            else
            {
                MessageBox.Show("The data is missing");
            }


        }
        
        public void DeleteHomeroomTeacherMethod(object obj)
        {
            HomeroomTeacher hmteach = obj as HomeroomTeacher;
            if (hmteach != null)
            {
                int id = hmteach.HomeroomTeacherId;
                int PId= hmteach.PersonId;
                context.Database.ExecuteSqlInterpolatedAsync($"DeleteHomeroomTeacher2 {id},{PId}");
                context.SaveChanges();
                HomeroomTeachersList.Remove(hmteach);
            }
            else
            {
                MessageBox.Show("Please select a homeroom teacher");
            }
        }
        public ObservableCollection<HomeroomTeacher> GetAllTeachers()
        {
            List<HomeroomTeacher> HMteachers = context.HomeroomTeachers.Include(h => h.Person).ToList();
            ObservableCollection<HomeroomTeacher> result = new ObservableCollection<HomeroomTeacher>();
            foreach (HomeroomTeacher hmteach in HMteachers)
            {
                result.Add(hmteach);
            }
            return result;
        }
    }
}

