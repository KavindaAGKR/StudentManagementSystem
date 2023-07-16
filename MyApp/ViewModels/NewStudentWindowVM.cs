using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyApp.ViewModels
{
    public partial class NewStudentWindowVM:ObservableObject
    {
        [ObservableProperty]
        public string firstName;

        [ObservableProperty]
        public string lastName;

        [ObservableProperty]
        public string regNo;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public int teleNo;

        public NewStudentWindowVM()
        {
            
        }

        public NewStudentWindowVM(Students s)
        {
            firstName = s.FirstName;
            lastName = s.LastName;
            regNo = s.RegNo;
            email = s.Email;
            teleNo = s.TelNo;
            
        }

        [RelayCommand]
        public void Save()
        {
            using DataContext db = new DataContext();


            if (firstName != null && lastName!=null && regNo!=null &&  email!=null )
            {
                var s =new Students() { Email = email, FirstName = firstName, LastName = lastName , TelNo = teleNo, RegNo=regNo};
                db.Dbstudnets.Add(s);
                db.SaveChanges();
                MessageBox.Show($"Student {firstName} {lastName}");


                Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                currentWindow?.Close();
            }
        }
    
    }
}
