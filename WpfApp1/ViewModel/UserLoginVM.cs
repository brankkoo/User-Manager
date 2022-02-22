using Caliburn.Micro;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using View.Commands;

namespace View.ViewModel
{
    public class UserLoginVM : Screen
    {
        private string _userName;

        public string Username
        {
            get { return _userName; }
            set {
                _userName = value; 
            NotifyOfPropertyChange(() => Username);
            }
        }

        private string _password;

        public  string Password
        {
            get { return _password; }
            set {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public ICommand LoginCommand { get; }

        public UserLoginVM()
        {
            LoginCommand = new LoginCommand(this);
        }
    
    }
}
