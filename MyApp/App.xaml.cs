using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databasename = "MyApp.db";
        static string folderPath = @"F:\Campus\3rd semester\EE5151 Programming project\MyApp\WpfApp1\MyApp";
        public static string databasePath = System.IO.Path.Combine(folderPath, databasename);
    }
}
