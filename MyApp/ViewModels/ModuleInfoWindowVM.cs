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
    public partial class ModuleInfoWindowVM:ObservableObject
    {
        [ObservableProperty]
        public string moduleName;

        [ObservableProperty]
        public string moduleCode;

        [ObservableProperty]
        public int credits;

        [ObservableProperty]
        public Module selectedModule = null;

        private ObservableCollection<Module> modules;

        public ObservableCollection<Module> Modules
        {
            get { return modules; }
            set
            {
                modules = value;
                OnPropertyChanged();
            }
        }
        public ModuleInfoWindowVM()
        {
            Addlist();

        }

        public void Addlist()
        {

            using (DataContext db = new DataContext())
            {
                List<Module> moduleList = db.Dbmodules.ToList();

                Modules = new ObservableCollection<Module>(moduleList);
            }

        }

        [RelayCommand]
        public void addModule()
        {
            var vm = new AddModuleWindowVM();
            vm.title = "ADD MODULE";
            var v = new AddModuleWindow(vm);
            v.ShowDialog();
            Addlist();


        }

        [RelayCommand]
        public void deleteModule()
        {



            if (selectedModule != null)
            {
                using DataContext db = new DataContext();

                Module module = db.Dbmodules.Single(x => x.Id == selectedModule.Id);
                db.Remove(module);
                db.SaveChanges();

                MessageBox.Show($"Module {selectedModule.Name} Deleted.");
                Addlist();
            }



        }

        [RelayCommand]
        public void editModule()
        {

            if (selectedModule != null)
            {
                using DataContext db = new DataContext();

                var vm = new AddModuleWindowVM(selectedModule);
                vm.title = "EDIT MODULE";
                var v = new AddModuleWindow(vm);
                Module module = db.Dbmodules.Single(x => x.Id == selectedModule.Id);
                db.Remove(module);
                db.SaveChanges();


                v.ShowDialog();

                Addlist();


            }



        }


    }
}
