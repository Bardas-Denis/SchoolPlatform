using Microsoft.EntityFrameworkCore;
using SchoolPlatform.Models;
using SchoolPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolPlatform.BussinesLogicLayer
{
    public class LoginBLL
    {
        private MyContext context= new MyContext();
        public string ErrorMessage { get; set; }
        public void OpenWindow(User user)
        {
            Roles role = (Roles)user.Role;
            switch (role.ToString())
            {
                case "Admin":
                    AdminPage adminPage = new AdminPage();
                    adminPage.ShowDialog();
                    break;
                case "Student":
                    StudentPage studentPage = new StudentPage(user);
                    studentPage.ShowDialog();
                    break;
                case "Teacher":
                    TeacherPage teacherPage = new TeacherPage(user);
                    teacherPage.ShowDialog();
                    break;
                case "HomeroomTeacher":
                    
                    break;
            }
        }
        public void VerifyLogin(Object obj)
        {
            Tuple<string,string> loginCredentials=obj as Tuple<string,string>;
            if (loginCredentials!=null)
            {
                if(string.IsNullOrEmpty(loginCredentials.Item1) || string.IsNullOrEmpty(loginCredentials.Item2)) 
                {
                    ErrorMessage = "Please enter both email and password";
                }
                else 
                {
                    string email=loginCredentials.Item1;
                    string pass = loginCredentials.Item2;
                    var user = context.Users.FromSqlInterpolated($"GetUsersByCredentials {email},{pass}").ToList().FirstOrDefault();
                    if(user != null) 
                    {
                        ErrorMessage = "";
                        OpenWindow(user);
                    }
                    else
                    {
                        ErrorMessage = "Email or password are incorrect";
                    }
                }
            }
        }
    }
}
