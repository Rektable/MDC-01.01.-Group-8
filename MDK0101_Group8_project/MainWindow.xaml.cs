using System.Windows;

namespace MDK0101_Group8_project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SummaryButton_Click(object sender, RoutedEventArgs e)
        {
            SummaryWindow summaryWindow = new SummaryWindow();
            mainFrame.Navigate(summaryWindow);
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            ScheduleWindow scheduleWindow = new ScheduleWindow();
            mainFrame.Navigate(scheduleWindow);
        }

        private void RatingButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement rating window
        }
    }
}