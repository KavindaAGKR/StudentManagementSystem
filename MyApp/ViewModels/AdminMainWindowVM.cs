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
using System.Windows.Controls;

namespace MyApp.ViewModels
{
    public partial class AdminMainWindowVM:ObservableObject
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
        public int teleNo;

        [ObservableProperty]
        public Students selectedStudent;

        private ObservableCollection<Students> students;

        public ObservableCollection<Students> Students
        {
            get { return students; }
            set
            {
                students = value;
                OnPropertyChanged();
            }
        }

        public AdminMainWindowVM()
        {
            ReadList();
        }


        public void ReadList()
        {
            using (DataContext db = new DataContext())
            {
                List<Students> studentList = db.Dbstudnets.ToList();

                Students = new ObservableCollection<Students>(studentList);
            }
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new NewStudentWindowVM();
            vm.Title = "ADD STUDENT";
            var v = new NewStudentWindow(vm);
            v.ShowDialog();
            ReadList();

        }

        [RelayCommand]
        public void EditStudent()
        {
            using DataContext db = new DataContext();
            if(selectedStudent != null)
            {
                var vm = new NewStudentWindowVM(selectedStudent);
                vm.Title = "EDIT STUDENT";
                var v = new NewStudentWindow(vm);
                Students student= db.Dbstudnets.Single(x=>x.Id == selectedStudent.Id);
                db.Remove(student);
                db.SaveChanges();

                v.ShowDialog();
                ReadList();

            }
           
        }
        [RelayCommand]
        public void UserInfo()
        {
            var vm = new UserInfoWindow();
           
            vm.Show();

        }

        [RelayCommand]
        public void Delete() 
        {
            using DataContext db = new DataContext();
            if(selectedStudent != null)
            {
                Students student = db.Dbstudnets.Single(x=>x.Id == selectedStudent.Id);
                db.Remove(student);
                db.SaveChanges();

                MessageBox.Show($"Student {selectedStudent.FirstName} {selectedStudent.LastName} is Deleted. ");
                ReadList();

            }

        }

        [RelayCommand]
        public void ModuleInfo()
        {
            var v = new ModuleInfoWindow();
          v.Show();
        }
    }
}
