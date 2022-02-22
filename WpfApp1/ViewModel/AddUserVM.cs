using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using View.Commands;

namespace View.ViewModel
{
    public class AddUserVM : Screen
    {
        private string username;
        private string password;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public ICommand AddCommand { get; }

        public AddUserVM()
        {
            AddCommand = new AddCommand(this);
        }
    }
}
