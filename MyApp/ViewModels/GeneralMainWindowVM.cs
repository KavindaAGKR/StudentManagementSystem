using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;
using MyApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace MyApp.ViewModels
{
    public partial class GeneralMainWindowVM : ObservableObject
    {
        public Students Student { get; set; }

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

        public GeneralMainWindowVM()
        {
            readList();

        }

        public void readList()
        {
            using DataContext db = new DataContext();
            List<Students> studentList = db.Dbstudnets.ToList();
            Students = new ObservableCollection<Students>(studentList);

        }
        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddStudentWindowVM(selectedStudent);
            vm.Title = "ADD RESULT";
            var v = new AddStudentWindow(vm);
            v.ShowDialog();
            readList();


        }


        [RelayCommand]
        public void Delete()
        {
            using DataContext db = new DataContext();
            {
                var student = db.Dbstudnets.Include(s => s.Results).ThenInclude(r => r.Module).FirstOrDefault(s => s.Id == selectedStudent.Id);

                if (student != null)
                {

                    var resultsToDelete = new List<Results>(student.Results);
                    var modulesToDelete = new List<Module>();
                    foreach (var result in resultsToDelete)
                    {
                        db.Dbresults.Remove(result);
                        var moduleToDelete = db.Dbmodules.Include(m => m.Students)
                                     .FirstOrDefault(m => m.Id == result.ModuleID);
                        if (moduleToDelete != null)
                        {
                            modulesToDelete.Add(moduleToDelete);
                        }
                    }

                    foreach (var module in modulesToDelete)
                    {
                        student.Modules.Remove(module);
                     
                    }

                    student.GPA = 0.0;
                    db.SaveChanges();
                }
                MessageBox.Show("Result Deleted");
                readList();
            }

        }

    }
}

