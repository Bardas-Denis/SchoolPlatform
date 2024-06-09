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
    class AdminPageVM
    {
        private StudentBLL studentBLL;
        private TeacherBLL teacherBLL;
        private HomeroomTeacherBLL homeroomTeacherBLL;
        private ClassBLL classBLL;
        private SubjectBLL subjectBLL;
        private LinkBLL linkBLL;
        public AdminPageVM()
        {
            studentBLL = new StudentBLL();
            teacherBLL = new TeacherBLL();
            homeroomTeacherBLL = new HomeroomTeacherBLL();
            classBLL = new ClassBLL();
            subjectBLL = new SubjectBLL();
            linkBLL = new LinkBLL();

            TeachersList = teacherBLL.GetAllTeachers();
            StudentsList = studentBLL.GetAllStudents();
            HomeroomTeachersList = homeroomTeacherBLL.GetAllTeachers();
            ClassesList = classBLL.GetAllClasses();
            SubjectsList = subjectBLL.GetAllSubjects();
        }
        #region Data Members
        public ObservableCollection<Student> StudentsList
        {
            get => studentBLL.StudentsList;
            set => studentBLL.StudentsList = value;
        }
        public ObservableCollection<Teacher> TeachersList
        {
            get => teacherBLL.TeachersList;
            set => teacherBLL.TeachersList = value;
        }
        public ObservableCollection<HomeroomTeacher> HomeroomTeachersList
        {
            get => homeroomTeacherBLL.HomeroomTeachersList;
            set => homeroomTeacherBLL.HomeroomTeachersList = value;
        }
        public ObservableCollection<Class> ClassesList
        {
            get => classBLL.ClassesList;
            set => classBLL.ClassesList = value;
        }
        public ObservableCollection<Subject> SubjectsList
        {
            get => subjectBLL.SubjectsList;
            set => subjectBLL.SubjectsList = value;
        }
        #endregion
        #region Command Members
        public void AddStudentMethod(object obj)
        {
            studentBLL.AddStudentMethod();
        }
        private ICommand addStudentCommand;
        public ICommand AddStudentCommand
        {
            get
            {
                if (addStudentCommand == null)
                {
                    addStudentCommand = new RelayCommand(AddStudentMethod);
                }
                return addStudentCommand;
            }
        }
        public void AddTeacherMethod(object obj)
        {
            teacherBLL.AddTeacherMethod();
        }
        private ICommand addTeacherCommand;
        public ICommand AddTeacherCommand
        {
            get
            {
                if (addTeacherCommand == null)
                {
                    addTeacherCommand = new RelayCommand(AddTeacherMethod);
                }
                return addTeacherCommand;
            }
        }
        public void AddHomeroomTeacherMethod(object obj)
        {
            homeroomTeacherBLL.AddHomeroomTeacherMethod();
        }
        private ICommand addHomeroomTeacherCommand;
        public ICommand AddHomeroomTeacherCommand
        {
            get
            {
                if (addHomeroomTeacherCommand == null)
                {
                    addHomeroomTeacherCommand = new RelayCommand(AddHomeroomTeacherMethod);
                }
                return addHomeroomTeacherCommand;
            }
        }

        public void AddClassMethod(object obj)
        {
            classBLL.AddClassMethod();
        }
        private ICommand addClassCommand;
        public ICommand AddClassCommand
        {
            get
            {
                if (addClassCommand == null)
                {
                    addClassCommand = new RelayCommand(AddClassMethod);
                }
                return addClassCommand;
            }
        }
        public void AddSubjectMethod(object obj)
        {
            subjectBLL.AddSubjectMethod();
        }
        private ICommand addSubjectCommand;
        public ICommand AddSubjectCommand
        {
            get
            {
                if (addSubjectCommand == null)
                {
                    addSubjectCommand = new RelayCommand(AddSubjectMethod);
                }
                return addSubjectCommand;
            }
        }

        public void DeleteStudentMethod(object obj)
        {
            studentBLL.DeleteStudentMethod(obj);
        }
        private ICommand deleteStudentCommand;
        public ICommand DeleteStudentCommand
        {
            get
            {
                if (deleteStudentCommand == null)
                {
                    deleteStudentCommand = new RelayCommand(DeleteStudentMethod);
                }
                return deleteStudentCommand;
            }
        }

        public void DeleteTeacherMethod(object obj)
        {
            teacherBLL.DeleteTeacherMethod(obj);
        }
        private ICommand deleteTeacherCommand;
        public ICommand DeleteTeacherCommand
        {
            get
            {
                if (deleteTeacherCommand == null)
                {
                    deleteTeacherCommand = new RelayCommand(DeleteTeacherMethod);
                }
                return deleteTeacherCommand;
            }
        }
        public void DeleteHomeroomTeacherMethod(object obj)
        {
            homeroomTeacherBLL.DeleteHomeroomTeacherMethod(obj);
        }
        private ICommand deleteHomeroomTeacherCommand;
        public ICommand DeleteHomeroomTeacherCommand
        {
            get
            {
                if (deleteHomeroomTeacherCommand == null)
                {
                    deleteHomeroomTeacherCommand = new RelayCommand(DeleteHomeroomTeacherMethod);
                }
                return deleteHomeroomTeacherCommand;
            }
        }

        public void DeleteClassMethod(object obj)
        {
            classBLL.DeleteClassMethod(obj);
        }
        private ICommand deleteClassCommand;
        public ICommand DeleteClassCommand
        {
            get
            {
                if (deleteClassCommand == null)
                {
                    deleteClassCommand = new RelayCommand(DeleteClassMethod);
                }
                return deleteClassCommand;
            }
        }
        public void DeleteSubjectMethod(object obj)
        {
            subjectBLL.DeleteSubjectMethod(obj);
        }
        private ICommand deleteSubjectCommand;
        public ICommand DeleteSubjectCommand
        {
            get
            {
                if (deleteSubjectCommand == null)
                {
                    deleteSubjectCommand = new RelayCommand(DeleteSubjectMethod);
                }
                return deleteSubjectCommand;
            }
        }
        public void UpdateSubjectMethod(object obj)
        {
            subjectBLL.ModifySubjectMethod(obj);
        }
        private ICommand updateSubjectCommand;
        public ICommand UpdateSubjectCommand
        {
            get
            {
                if(updateSubjectCommand == null)
                {
                    updateSubjectCommand= new RelayCommand(UpdateSubjectMethod);
                }
                return updateSubjectCommand;
            }
        }
        public void UpdateClassMethod(object obj)
        {
            classBLL.UpdateClassMethod(obj);
        }
        private ICommand updateClassCommand;
        public ICommand UpdateClassCommand
        {
            get
            {
                if(updateClassCommand == null)
                {
                    updateClassCommand= new RelayCommand(UpdateClassMethod);
                }
                return updateClassCommand;
            }
        }
        public void UpdateStudentMethod(object obj)
        {
            studentBLL.UpdateStudentMethod(obj);
        }
        private ICommand updateStudentCommand;
        public ICommand UpdateStudentCommand
        {
            get
            {
                if(updateStudentCommand== null)
                {
                    updateStudentCommand= new RelayCommand(UpdateStudentMethod);
                }
                return updateStudentCommand;
            }
        }
        public void UpdateTeacherMethod(object obj) 
        {
            teacherBLL.UpdateTeacherMethod(obj);
        }
        private ICommand updateTeacherCommand;
        public ICommand UpdateTeacherCommand
        {
            get
            {
                if(updateTeacherCommand== null)
                {
                    updateTeacherCommand=new RelayCommand(UpdateTeacherMethod);
                }    
                return updateTeacherCommand;
            }
        }
        public void Test(object obj)
        {
            linkBLL.Linking(obj);
        }
        private ICommand testCoommand;
        public ICommand TestCoommand
        {
            get
            {
                if (testCoommand == null)
                {
                    testCoommand = new RelayCommand(Test);
                }
                return testCoommand;
            }
        }
        #endregion 
    }
}
