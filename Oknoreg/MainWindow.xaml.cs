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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Oknoreg
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (okno1.Text == "")
            {
                MessageBox.Show("Вы забыли ввести логин!");
                return;
            }
            else if (okno2.Password == "")
            {
                MessageBox.Show("Вы забыли ввести пароль!");
                return;
            }
            else {
                List<string> logins = new List<string> { "pq19Yu", "gt56Po", "bv32Lh", "ds78Xw", "az40Cm", "ef94Kr" };
                Dictionary<string, string> passwords = new Dictionary<string, string> 
                { 
                    { "pq19Yu", "1234" }, 
                    { "gt56Po", "2341" },
                    { "bv32Lh", "1342" },
                    { "ds78Xw", "5678" },
                    { "az40Cm", "8765" },
                    { "ef94Kr", "5876" }
                };

                Dictionary<string, string> names = new Dictionary<string, string>
                {
                    { "pq19Yu", "Смирнова Е.В." },
                    { "gt56Po", "Петров Е.С." },
                    { "bv32Lh", "Полякова А.Н." },
                    { "ds78Xw", "Романовская Н.В." },
                    { "az40Cm", "Шагина Е.В." },
                    { "ef94Kr", "Женихова Н.В." }
                };
                
                if (logins.Contains(okno1.Text))
                {
                    if (passwords[okno1.Text] == okno2.Password)
                    {
                        string userName = names[okno1.Text];
                        MessageBox.Show("Вы успешно вошли в систему");
                        Window window = new ResultTableWindow(userName);
                        window.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин");
                }
            }
        }
    }
}
