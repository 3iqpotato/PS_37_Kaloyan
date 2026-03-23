using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Welcome.ViewModel;

namespace Welcome.View
{
    public partial class MainWindow : Window
    {
        private UserViewModel _viewModel;

        public MainWindow(UserViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        public void DisplayUser()
        {
            // Основен контейнер
            StackPanel panel = new StackPanel();
            panel.Margin = new Thickness(20);

            // Заглавие
            TextBlock title = new TextBlock();
            title.Text = "🎓 Студентска информационна система";
            title.FontSize = 20;
            title.FontWeight = FontWeights.Bold;
            title.Foreground = new SolidColorBrush(Colors.DarkBlue);
            title.Margin = new Thickness(0, 0, 0, 20);

            // Инфо за потребителя
            TextBlock info = new TextBlock();
            info.Text =
                $"👤 Име: {_viewModel.Names}\n" +
                $"📧 Имейл: {_viewModel.Email}\n" +
                $"🎓 Факултетен номер: {_viewModel.FacultyNumber}\n" +
                $"📅 Възраст: {_viewModel.Age}\n";
            info.FontSize = 14;
            info.Margin = new Thickness(0, 0, 0, 10);

            // Статус блок
            Border statusBorder = new Border();
            statusBorder.CornerRadius = new CornerRadius(8);
            statusBorder.Padding = new Thickness(10);
            statusBorder.Margin = new Thickness(0, 10, 0, 0);
            statusBorder.Background = new SolidColorBrush(Colors.LightBlue);

            TextBlock status = new TextBlock();
            status.Text =
                $"🔑 Роля: {_viewModel.IsAdmin}\n" +
                $"📊 Статус: {_viewModel.IsBlocked}";
            status.FontSize = 14;

            statusBorder.Child = status;

            // Слагаме всичко в панела
            panel.Children.Add(title);
            panel.Children.Add(info);
            panel.Children.Add(statusBorder);

            this.Content = panel;
        }

        public void DisplayError()
        {
            throw new Exception("Грешка в MainWindow!");
        }
    }


}
