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
using System.Windows;
using Welcome.ViewModel;

namespace Welcome.View
{
    public partial class AdminWindow : Window
    {
        private AdminViewModel _viewModel;

        public AdminWindow(AdminViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            usersListBox.ItemsSource = _viewModel.AllUserName;
        }
    }
}
