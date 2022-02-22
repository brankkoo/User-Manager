using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using View.Model;
using View.ViewModel;

namespace WpfApp1
{
    
    public partial class App : Application
    {
        private readonly User user;
        private readonly UserCollection userCollection;
        public App()
        {
            user = new User();
            userCollection = new UserCollection();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext= new UserLoginVM()
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
