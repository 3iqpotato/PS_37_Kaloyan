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

using Welcome.ViewModel;

namespace Welcome.View
{
    public partial class LoginWindow : Window
    {
        private LoginViewModel _viewModel;

        public LoginWindow(LoginViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UserNameText = textBoxUserName.Text;
            _viewModel.PasswordText = textBoxPassword.Text;
            _viewModel.LoginExecute();

            // Показваме грешка ако има
            textBlockError.Text = _viewModel.ErrorMessage;
        }
    }
}