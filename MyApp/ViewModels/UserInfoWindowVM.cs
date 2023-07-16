using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyApp.Models;
using MyApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyApp.ViewModels
{
    public partial class UserInfoWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string userName;

        [ObservableProperty]
        public string type;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public Users selectedUser = null;

        private ObservableCollection<Users> users;

        public ObservableCollection<Users> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }
        public UserInfoWindowVM()
        {
            Addlist();

        }

        public void Addlist()
        {

            using (DataContext db = new DataContext())
            {
                List<Users> userList = db.Dbusers.ToList();

                Users = new ObservableCollection<Users>(userList);
            }

        }

        [RelayCommand]
        public void addUser()
        {
            var vm = new NewuserWindowVM();
            vm.title = "ADD USER";
            var v = new NewUserWindow(vm);
            v.ShowDialog();
            Addlist();


        }

        [RelayCommand]
        public void deleteUser()
        {
            using(DataContext db = new DataContext())
            {
                if (selectedUser != null)
                {
                    Users user = db.Dbusers.Single(x=>x.Id == selectedUser.Id);
                    db.Remove(user);
                    db.SaveChanges();

                    MessageBox.Show($"User {selectedUser.Username} Deleted.");
                    Addlist();
                }
            }
            

        }

        [RelayCommand]
        public void editUser()
        {
            using (DataContext db = new DataContext())
            {
                if (selectedUser != null)
                {
                    var vm = new NewuserWindowVM(selectedUser);
                    vm.title = "EDIT USER";
                    var v = new NewUserWindow(vm);
                    Users user = db.Dbusers.Single(x=>x.Id==selectedUser.Id);
                    db.Remove(user);
                    db.SaveChanges();


                    v.ShowDialog();

                    Addlist();


                }
            }
           

        }


    }
}
