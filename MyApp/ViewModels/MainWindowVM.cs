using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyApp.ViewModels
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string userName;

        [ObservableProperty]
        public string password ;


        public Action CloseAction { get; set; }

        [RelayCommand]
        public void Exit()
        {
            CloseAction();
        }

        [RelayCommand]
        public void Login()
        {

            if (userName != null)
            {


                using (var db = new DataContext())
                {

                    bool isfound = db.Dbusers.Any(usr => usr.Username == userName && usr.Password == password);

                    if (isfound)
                    {
                        
                        bool isUserAdmin = db.Dbusers.Any(usr => usr.Username == userName && usr.Password == password && usr.Type == "admin");
                        if (isUserAdmin) {
                            var window = new AdminMainWindow();
                            window.ShowDialog();
                         
                        }
                        else {
                            var w = new GeneralMainWindow();
                            w.ShowDialog();
                            

                        }
                        
                        



                    }
                    else
                    {
                        MessageBox.Show("User name or password was incorrect", "Warning");
                    }


                }



            }
        }
    }
}
