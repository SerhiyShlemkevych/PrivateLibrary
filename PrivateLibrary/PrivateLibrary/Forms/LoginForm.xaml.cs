
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using EpamTask.PrivateLibrary.Entity.User;
using EpamTask.PrivateLibrary.Global;

namespace EpamTask.PrivateLibrary.Forms
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var password = Encryptor.HashToMD5(passwordBox.Password);
            var user = Container.UnitOfWork.UserRepository.GetUserByLogin(txtBox.Text, password);
            if (user != null && user.ID > 0)
            {
                var main = new MainWindow(user);
                Application.Current.MainWindow = main;
                Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Failed to login!\nPlease check your username/password.", "Invalid login/password", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void gridLogin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    btnLogin.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.Escape:
                    btnClose.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
            }
        }
    }
}
