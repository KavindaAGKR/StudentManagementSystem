using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;

namespace MyApp.ViewModels
{
    public partial class NewuserWindowVM: ObservableObject
    {
        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string password;
       
        [ObservableProperty]
        public string username;
        
        [ObservableProperty]
        public bool isAdmin;

        [ObservableProperty]
        public bool isGeneral;

        [ObservableProperty]
        public string title;

        
        

        public NewuserWindowVM()
        {
            
        }
        public NewuserWindowVM(Models.Users u)
        {
            username = u.Username;
            email = u.Email;
            password = u.Password;
            if(u.Type == "admin") { isAdmin = true; }
            else {  isGeneral = true; }

        }

        [RelayCommand]
        public void Save()
        {

            using (DataContext db = new DataContext())
            {
                if (email != null && username != null && password != null)
                {
                    if (isAdmin == true)
                    {
                        db.Dbusers.Add(new Models.Users() { Email = email, Username = username, Password = password, Type = "admin" });
                        db.SaveChanges();

                    }
                    else if (isGeneral == true)
                    {
                        db.Dbusers.Add(new Models.Users() { Email = email, Username = username, Password = password, Type = "general" });
                        db.SaveChanges();
                    }

                    MessageBox.Show($"User {Username} added successfully");

                    Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                    currentWindow?.Close();
                }
            }



        }


    }

    
}
