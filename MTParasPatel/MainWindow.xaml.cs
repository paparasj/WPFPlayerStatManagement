using System.Windows;


namespace MTParasPatel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHockey_Click(object sender, RoutedEventArgs e)
        {
            HockeyWindow hockeyWindow = new HockeyWindow();
            hockeyWindow.ShowDialog();

        }

        private void btnBasketBall_Click(object sender, RoutedEventArgs e)
        {
            BasketBallWindow basketBallWindow = new BasketBallWindow();
            basketBallWindow.ShowDialog();
        }

        private void btnBaseBall_Click(object sender, RoutedEventArgs e)
        {
            BaseBallWindow baseBallWindow = new BaseBallWindow();
            baseBallWindow.ShowDialog();
        }
        private void menuAboutMe_Click(object sender, RoutedEventArgs e)
        {
            AboutMe aboutMe = new AboutMe();
            aboutMe.ShowDialog();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs cancel)
        {
            var result = MessageBox.Show("Do you really want to quit?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
            {
                cancel.Cancel = true;
            }
        }
        private void menuQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }

}
