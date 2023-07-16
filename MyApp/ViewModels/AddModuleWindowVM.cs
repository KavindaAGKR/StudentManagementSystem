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
    public partial class AddModuleWindowVM:ObservableObject
    {
        [ObservableProperty]
        public string moduleName;

        [ObservableProperty]
        public string moduleCode;

        [ObservableProperty]
        public int credits;

        [ObservableProperty]
        public string title;

        public AddModuleWindowVM()
        {
            
        }

        public AddModuleWindowVM(Module m)
        {
            moduleName = m.Name;
            moduleCode = m.ModuleId;
            credits = m.Credit;
        }

        [RelayCommand]
        public void save()
        {
            if (moduleName != null && moduleCode !=null && credits !=0)
            {
                using DataContext db = new DataContext();
                db.Dbmodules.Add(new Module() { Name=moduleName , ModuleId=moduleCode, Credit=credits});
                db.SaveChanges();

                MessageBox.Show($"Module {moduleName} added successfully");

                Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                currentWindow?.Close();

            }
        }
    }
}
