
using System.Data.SqlClient;
using System.Windows;

namespace EpamTask.PrivateLibrary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var errorMessage = "An unexpected error just occurred!\nPlease check data and try later.";
            var errorWindowName = "Unexpected Error";
            e.Handled = true;

            switch (e.Exception.GetType().Name)
            {
                case "SqlException":
                    var sqlEx = e.Exception as SqlException;
                    errorWindowName = "Database error";
                    switch (sqlEx.Number)
                    {
                        case -1:
                            var main = Current.MainWindow as MainWindow;
                            if (main != null)
                            {
                                main.gridTableSelect.IsEnabled = false;
                                main.gridTableForm.IsEnabled = false;
                                main.btnSignup.IsEnabled = false;
                            }
                            errorMessage = "Connection failed.\nPlease retry later.";
                            break;
                        case 2812:
                        case 512:
                            errorMessage = "Database table was corrupted!\nPlease contact administrator.";
                            break;
                        case 547:
                            errorMessage = "Invalid Data!\nPlease check your data.";
                            break;
                        case 201:
                            errorMessage = "Missing value!\nPlease check your data.";
                            break;
                        default:
                            errorMessage = "Unexpected database error just occured!";
                            break;
                    }
                    break;
                case "ArgumentException":
                case "ArgumentNullException":
                case "NullReferenceException":
                    errorMessage = "Invalid data\nPlease revisit your actions.";
                    break;
                case "StackOverflowException":
                case "OutOfMemoryException":
                    errorMessage = "Fatal error has occurred!Application is shutting down!";
                    e.Handled = false;
                    break;
            }
            MessageBox.Show(errorMessage, errorWindowName, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
