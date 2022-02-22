using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using View;
using View.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for WindowUser.xaml
    /// </summary>
    public partial class WindowUser : Window
    {
        public WindowUser()
        {
            InitializeComponent();
            WindowUserViewModel windowUserViewModel = new WindowUserViewModel();
            this.DataContext = windowUserViewModel;
        }

        

        public object UserViewModel
        {
            get { return this.DataContext; }
            set {  this.DataContext = value; }
        }


        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowUserViewModel viewModel = (WindowUserViewModel)this.DataContext;
            EditUserWindow window = new EditUserWindow();
            window.DataContext = new EditWindowViewModel( viewModel.CurrentUser.Clone());
            window.Show();
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUser window = new AddUser();
            window.Show();

        }
    }
}
