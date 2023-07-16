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
    /// Interaction logic for AddUserWindowView.xaml
    /// </summary>
    public partial class UserInfoWindow : Window
    {
        public UserInfoWindow()
        {
            InitializeComponent();
           var vm = new UserInfoWindowVM();
            DataContext = vm;
        }

        private void userListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
