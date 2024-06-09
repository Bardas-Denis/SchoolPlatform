using SchoolPlatform.BussinesLogicLayer;
using SchoolPlatform.Helpers;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.ViewModels
{
    public class StudentPageVM : BaseVM
    {
       
        StudentBLL studentBLL;
        GradeBLL gradeBLL;
        AttendanceBLL attendanceBLL;

        public StudentPageVM(User user)
        {
            CurrentUser = user;
            gradeBLL = new GradeBLL();
            attendanceBLL = new AttendanceBLL();

            GradesList = gradeBLL.GetAllGradesForStudent(CurrentUser);
            AttendancesList = attendanceBLL.GetAllAttendancesForStudent(CurrentUser);
        }
        #region DataMembers
        private User currentUser;
        public User CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
                NotifyPropertyChanged(nameof(CurrentUser));
            }
        }
    
        public ObservableCollection<Grade> GradesList
        {
            get => gradeBLL.GradesList;
            set
            {
                gradeBLL.GradesList = value;
                NotifyPropertyChanged(nameof(GradesList));
            }
        }
        public ObservableCollection<Attendance> AttendancesList
        {
            get => attendanceBLL.AttendancesList;
            set
            {
                attendanceBLL.AttendancesList = value;
                NotifyPropertyChanged(nameof(AttendancesList));
            }
        }
        #endregion
    }
}
