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
    public partial class AddResultWindowVM :ObservableObject
    {
        [ObservableProperty]
        public string moduleId;

        [ObservableProperty]
        public string moduleName;

        [ObservableProperty]
        public string grade;

        [ObservableProperty]
        public int credits;

        public Results Result { get; set; }
        public AddResultWindowVM()
        {
            
        }

        public AddResultWindowVM(Results r)
        {
            moduleId = r.Module.ModuleId;
            moduleName = r.Module.Name;
            credits = r.Module.Credit;
            grade = r.Grade;
            Result = r;

        }

        [RelayCommand]
        public void Save()
        {

            if( grade != "")
            {
                AddStudentWindowVM.Results.Remove(AddStudentWindowVM.Results.FirstOrDefault(r => r.Module.ModuleId == moduleId));
                Results r = new Results(Result.Module);
                r.Grade = Grade;
                AddStudentWindowVM.Results.Add(r);

                Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                currentWindow?.Close();

            }

        }

    }
}
