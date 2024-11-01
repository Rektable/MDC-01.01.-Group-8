using MDK0101_Group8_project;
using System.Windows;

namespace MDK0101_Group8_project
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate login and password
            if (loginTextBox.Text == "admin" && passwordTextBox.Text == "password")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid login or password");
            }
        }
    }
}