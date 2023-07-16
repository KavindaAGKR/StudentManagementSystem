using MyApp.Models;
using MyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyApp.Views
{
    /// <summary>
    /// Interaction logic for AddResultWindow.xaml
    /// </summary>
    public partial class AddResultWindow : Window
    {
        public AddResultWindow(Results r)
        {
            InitializeComponent();
            DataContext = new AddResultWindowVM(r);
        }
    }
}
