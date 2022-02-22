using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using View.Model;
using View.ViewModel;
using WpfApp1;

namespace View.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly UserLoginVM uvm;

        public LoginCommand()
        {
        }

        public LoginCommand(UserLoginVM uvm)
        {
            this.uvm = uvm;
        }
      
        public override void Execute(object? parameter)
        {
            string CS = ConfigurationManager.ConnectionStrings["masterDatabase"].ConnectionString;
            bool log = User.Login(CS, uvm.Username, uvm.Password);

            if (log == true)
            {
                WindowUser window = new WindowUser();
                window.DataContext = new WindowUserViewModel();
                window.Show();
                Application.Current.MainWindow.Close();

            }
            else { MessageBox.Show("Login failed. Please try again"); }
        }
    }
}
