using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Others;

namespace WelcomeExtended
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                var user = new User
                {
                    Names = "John Smith",
                    Password = "password123",
                    Role = UserRolesEnum.STUDENT
                };

                var viewModel = new UserViewModel(user);

                MainWindow w = new MainWindow(viewModel);

                w.DisplayUser();
                w.ShowDialog();

                // Предизвикваме грешка
                w.DisplayError();
            }
            catch (Exception e)
            {
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}