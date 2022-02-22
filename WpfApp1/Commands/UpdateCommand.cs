using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using View.ViewModel;

namespace View.Commands
{
    public class UpdateCommand : CommandBase
    {
        private readonly EditWindowViewModel evm;



        public UpdateCommand(EditWindowViewModel editUserWindow)
        {
            evm = editUserWindow;
        }
        public override void Execute(object? parameter)
        {
            evm.CurrentUser.UpdateUser();
            MessageBox.Show("Updated!");
        }


    }
}
