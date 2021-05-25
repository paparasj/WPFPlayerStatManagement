using System;
using System.Collections.Generic;
using System.Windows;


namespace MTParasPatel
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    
    public partial class LoginWindow : Window
    {
        private Dictionary<string, Login> _userData;
        public LoginWindow()
        {

            InitializeComponent();
            _userData = new Dictionary<string, Login>();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _userData.Add("admin", new Login(1, "admin", "system"));
            _userData.Add("gstatla", new Login(2, "gstatla", "gstatla"));
            _userData.Add("paras", new Login(3, "paras", "paras"));
            _userData.Add("paparasj", new Login(4, "paparasj", "paras"));
            _userData.Add("extraordinory", new Login(5, "extraordinory", "extraordinory"));
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            
            string username = txtUserName.Text;
            string password = txtPassWord.Password;

            Login user = null;

            if (_userData.ContainsKey(username))
            {
                user = _userData[username];
                if (user.Password == password)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Password does not Match!!!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Username not Found!!! ", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
