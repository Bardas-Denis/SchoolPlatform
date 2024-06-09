using SchoolPlatform.BussinesLogicLayer;
using SchoolPlatform.Helpers;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class TeacherPageVM:BaseVM
    {
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

        ClassBLL classBLL;
        StudentBLL studentBLL;
        GradeBLL gradeBLL;
        AttendanceBLL attendanceBLL;
        public TeacherPageVM(User user) 
        {
            CurrentUser = user;
            classBLL = new ClassBLL();
            studentBLL = new StudentBLL();
            gradeBLL = new GradeBLL();
            attendanceBLL = new AttendanceBLL();

            ClassesList = classBLL.GetAllClassesFromTeacher(CurrentUser);
            StudentsList = new ObservableCollection<Student>();
            GradesList = new ObservableCollection<Grade>();
            AttendancesList = new ObservableCollection<Attendance>();
        }
        #region DataMembers
        public ObservableCollection<Student> StudentsList
        {
            get => studentBLL.StudentsList;
            set
            {
                studentBLL.StudentsList = value;
                NotifyPropertyChanged("StudentsList");
            }
        }
        public ObservableCollection<Class> ClassesList
        {
            get => classBLL.ClassesList;
            set
            {
                classBLL.ClassesList = value;
                NotifyPropertyChanged("ClassesList");
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
                attendanceBLL.AttendancesList= value;
                NotifyPropertyChanged(nameof(AttendancesList));
            }
        }
        #endregion
        #region
        public void GetStudentsMethod(object obj)
        {
            StudentsList=studentBLL.GetAllStudentsFromClass(obj);
        }
        private ICommand getStudentsCommand;
        public ICommand GetStudentsCommand
        {
            get
            {
                if (getStudentsCommand == null)
                {
                    getStudentsCommand = new RelayCommand(GetStudentsMethod);
                }
                return getStudentsCommand;
            }
        }

        public void GetGradesMethod(object obj)
        {
            GradesList=gradeBLL.GetAllGradesForStudent(obj);
        }
        private ICommand getGradesCommand;
        public ICommand GetGradesCommand
        {
            get
            {
                if(getGradesCommand == null)
                {
                    getGradesCommand=new RelayCommand(GetGradesMethod);
                }
                return getGradesCommand;
            }
        }
        public void GetAbsencesMethod(object obj) 
        {
            AttendancesList=attendanceBLL.GetAllAttendancesForStudent(obj); 
        }
        private ICommand getAbsencesCommand;
        public ICommand GetAbsencesCommand
        {
            get
            {
                if(getAbsencesCommand == null)
                {
                    getAbsencesCommand=new RelayCommand(GetAbsencesMethod);
                }
                return getAbsencesCommand;
            }
        }
        public void AddGradeMethod(object obj)
        {
            gradeBLL.AddGradeMethod(obj, CurrentUser);
        }
        private ICommand addGradeCommand;
        public ICommand AddGradeCommand
        {
            get
            {
                if(addGradeCommand == null)
                {
                    addGradeCommand = new RelayCommand(AddGradeMethod);
                }
                return addGradeCommand;
            }
        }
        public void AddAbsenceMethod(object obj)
        {
            attendanceBLL.AddAttendanceMethod(obj, CurrentUser);
        }
        private ICommand addAbsenceCommand;
        public ICommand AddAbsenceCommand
        {
            get
            {
                if (addAbsenceCommand == null)
                {
                    addAbsenceCommand = new RelayCommand(AddAbsenceMethod);
                }
                return addAbsenceCommand;
            }
        }
        public void DeleteGradeMethod(object obj)
        {
            gradeBLL.DeleteGradeMethod(obj);
        }
        private ICommand deleteGradeCommand;
        public ICommand DeleteGradeCommand
        {
            get
            {
                if (deleteGradeCommand == null)
                {
                    deleteGradeCommand = new RelayCommand(DeleteGradeMethod);
                }
                return deleteGradeCommand;
            }
        }
        public void DeleteAbsenceMethod(object obj)
        {
           attendanceBLL.DeleteAbsenceMethod(obj);
        }
        private ICommand deleteAbsenceCommand;
        public ICommand DeleteAbsenceCommand
        {
            get
            {
                if (deleteAbsenceCommand == null)
                {
                    deleteAbsenceCommand = new RelayCommand(DeleteAbsenceMethod);
                }
                return deleteAbsenceCommand;
            }
        }
        #endregion



    }
}
