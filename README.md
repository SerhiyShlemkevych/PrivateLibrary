# PrivateLibrary

Please check wiki page for more details about this project!  
**About BaseEntity and New**, - it was just a temporary solution with WPF binding, i simply forgot about it later.

For debug purposes you skip can LoginForm by putting this in **LoginForm()**  
{  
            InitializeComponent();   
            var main = new MainWindow(new UserEntity {ID = 1001});  
            Application.Current.MainWindow = main;  
            Close();  
            main.Show();  
}  
 
