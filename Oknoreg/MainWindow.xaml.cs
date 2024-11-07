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
            if (okno2.Password == "")
            {
                MessageBox.Show("Вы забыли ввести пароль!");
                return;
            }
            //Получить данные логина и пароля
            //Первый преподаватель
            if (okno1.Text == "pq19Yu")
            {
                if (okno2.Password == "1234")
                {
                    Window window = new Window1();
                    window.Show();
                }
            }
            
            //Второй преподаватель
            if (okno1.Text == "gt56Po")
            {
                if (okno2.Password == "2341")
                {
                    MessageBox.Show("Вы успешно вошли в систему");
                    Window window = new Window2();
                    window.Show();
                }  
            }
           
            //Третий преподаватель
            if (okno1.Text == "bv32Lh")
            {
                if (okno2.Password == "1342")
                {
                    MessageBox.Show("Вы успешно вошли в систему");
                    Window window = new Window3();
                    window.Show();
                } 
            }
            
            //Четвертый преподаватель
            if (okno1.Text == "ds78Xw")
            {
                if (okno2.Password == "5678")
                {
                    MessageBox.Show("Вы успешно вошли в систему");
                    Window window = new Window4();
                    window.Show();
                }  
            }
            
            //Пятый преподаватель
            if (okno1.Text == "az40Cm")
            {
                if (okno2.Password == "8765")
                {
                    MessageBox.Show("Вы успешно вошли в систему");
                    Window window = new Window5();
                    window.Show();
                } 
            }
           
            //Шестой преподаватель
            if (okno1.Text == "ef94Kr")
            {
                if (okno2.Password == "5876")
                {
                    MessageBox.Show("Вы успешно вошли в систему");
                    Window window = new Window6();
                    window.Show();
                } 
            }
        }
    }
}
