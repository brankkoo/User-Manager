using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Model;
using View;
using Model;
using System.Windows.Data;
using System.ComponentModel;

namespace View.ViewModel
{
    public class WindowUserViewModel :INotifyPropertyChanged
    {
        private UserCollection users;
        private ListCollectionView userListView;
        private User currentUser;
        public event PropertyChangedEventHandler? PropertyChanged;

        
        public User CurrentUser { get { return currentUser; } set {
                if (currentUser == value)
                {
                    return;
                }
                currentUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentUser)));


            } }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
       
        public ListCollectionView UserListView
        {
            get { return userListView; }
            set
            {
                if (userListView == value)
                {
                    return;
                }
                userListView = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserListView"));
            }
        }


        public UserCollection Users
        {
            get { return users; }
            set {if (users == value) { return; }
                
                users = value;
                OnPropertyChanged( new PropertyChangedEventArgs(nameof(Users)));
            }
        }

        public WindowUserViewModel()
        {
            
            users = UserCollection.GetAllUsers();
            currentUser = new User();
            UserListView = new ListCollectionView(users);
        }
    }
}
    
       

