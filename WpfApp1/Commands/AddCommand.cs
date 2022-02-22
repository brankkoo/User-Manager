using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using View.ViewModel;

namespace View.Commands
{
    public class AddCommand : CommandBase
    {
        private AddUserVM avm;

        public AddCommand(AddUserVM addUserVM)
        {
            avm = addUserVM;
        }

        public override void Execute(object? parameter)
        {
            User user = new User(avm.Username,avm.Password);
            user.AddUser();

            MessageBox.Show("Added!");
         
        }
    }
}
