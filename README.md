# PrivateLibrary

Please check wiki page for more details about this project!

For debug purposes you skip can LoginForm by putting this in **LoginForm()**  
{  
            InitializeComponent();   
            var main = new MainWindow(new UserEntity {ID = 1001});  
            Application.Current.MainWindow = main;  
            Close();  
            main.Show();  
}  
 
