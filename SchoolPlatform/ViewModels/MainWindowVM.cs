using SchoolPlatform.BussinesLogicLayer;
using SchoolPlatform.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    class MainWindowVM: BaseVM
    {
        private LoginBLL loginBLL;
        public MainWindowVM()
        {
            loginBLL = new LoginBLL();
        }
        #region Data Members
        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }
        #endregion
        #region Command Members
        public void VerifyLoginMethod(object obj)
        {
            loginBLL.VerifyLogin(obj);
            ErrorMessage=loginBLL.ErrorMessage;
        }
        private ICommand verifyLogin;
        public ICommand VerifyLogin
        {
            get
            {
                if(verifyLogin == null)
                {
                    verifyLogin = new RelayCommand(VerifyLoginMethod);
                }
                return verifyLogin;
            }
        }

        #endregion
    }
}
