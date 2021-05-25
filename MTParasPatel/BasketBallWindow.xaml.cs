using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MTParasPatel
{
    /// <summary>
    /// Interaction logic for BasketBallWindow.xaml
    /// </summary>
    public partial class BasketBallWindow : Window
    {
        /*defining static list*/
        static List<BasketBallPlayer> basketBallPlayer = new List<BasketBallPlayer>();
        /*defining static unique index*/
        static int uniqueIndex = 1;
        public BasketBallWindow()
        {
            InitializeComponent();
            /*Adding some data if list is empty*/

            if (basketBallPlayer.Count == 0)
            {
                BasketBallPlayer pb1 = new BasketBallPlayer(uniqueIndex++, PlayerType.BasketBallPlayer, "Kyle Lowry", "Raptors", 15, 18, 4);
                basketBallPlayer.Add(pb1);
                BasketBallPlayer pb2 = new BasketBallPlayer(uniqueIndex++, PlayerType.BasketBallPlayer, "Avery Bradley", "Heat", 8, 16, 2);
                basketBallPlayer.Add(pb2);
                BasketBallPlayer pb3 = new BasketBallPlayer(uniqueIndex++, PlayerType.BasketBallPlayer, "Paras Patel", "Swami Eleven", 2, 16, 2);
                basketBallPlayer.Add(pb3);
                BasketBallPlayer pb4 = new BasketBallPlayer(uniqueIndex++, PlayerType.BasketBallPlayer, "Nikolai Ivanov", "Absolute Guys", 1, 16, 22);
                basketBallPlayer.Add(pb4);
                BasketBallPlayer pb5 = new BasketBallPlayer(uniqueIndex++, PlayerType.BasketBallPlayer, "Wasim Singh", "Desi Raptors", 2, 10, 12);
                basketBallPlayer.Add(pb5);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }
        public void LoadList()
        {
            var basketballplayers = from player in basketBallPlayer
                                    select player.PlayerName;

            listBasketBall.ItemsSource = basketballplayers;
        }


        private void listBasketBall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listBasketBall.SelectedIndex;
            menuDelete.IsEnabled = true;
            menuUpdate.IsEnabled = true;
            lblID.Visibility = Visibility.Visible;
            lblPoints.Visibility = Visibility.Visible;
            textId.Visibility = Visibility.Visible;
            textPoints.Visibility = Visibility.Visible;
            btnInsert.Visibility = Visibility.Hidden;
            btnInsert.IsEnabled = false;
            btnClear.Visibility = Visibility.Visible;
            btnClear.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;

            if (index != -1)
            {
                var hp = (from player in basketBallPlayer
                          where player.PlayerName == basketBallPlayer[index].PlayerName
                          select player).FirstOrDefault();
                if (hp != null)
                {
                    textId.Text = hp.PlayerId.ToString();
                    textName.Text = hp.PlayerName;
                    textTeam.Text = hp.TeamName;
                    textGames.Text = hp.GamesPlayed.ToString();
                    textFieldGoals.Text = hp.FieldGoals.ToString();
                    textThreePointers.Text = hp.ThreePointers.ToString();
                    textPoints.Text = hp.Points().ToString();
                }
            }

        }


        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            int game, fieldgoals, threepointers;
            if (Int32.TryParse(textGames.Text, out game) && Int32.TryParse(textFieldGoals.Text, out fieldgoals) && Int32.TryParse(textThreePointers.Text, out threepointers))
            {
                BasketBallPlayer p1 = new BasketBallPlayer(uniqueIndex++, PlayerType.HockeyPlayer, textName.Text,
                                textTeam.Text, game, fieldgoals, threepointers);
                basketBallPlayer.Add(p1);
                textBoxClear();
            }
            else
            {
                MessageBox.Show("Invalid Input!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LoadList();
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int index = listBasketBall.SelectedIndex;
            if (index != -1)
            {
                BasketBallPlayer hp = basketBallPlayer[index];
                int game, fieldgoals, threepointers;
                if (Int32.TryParse(textGames.Text, out game) && Int32.TryParse(textFieldGoals.Text, out fieldgoals) && Int32.TryParse(textThreePointers.Text, out threepointers))
                {
                    var result = MessageBox.Show("Do you really want to update this players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        hp.PlayerName = textName.Text;
                        hp.TeamName = textTeam.Text;
                        hp.GamesPlayed = game;
                        hp.FieldGoals = fieldgoals;
                        hp.ThreePointers = threepointers;
                        textBoxClear();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Input!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
          LoadList();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = listBasketBall.SelectedIndex;
            var result = MessageBox.Show("Do you really want to delete this players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
             if (index != -1 && result == MessageBoxResult.Yes)
            {
                basketBallPlayer.RemoveAt(index);
                textBoxClear();
            }
            LoadList();
        }
        private void textBoxClear()
        {
            textId.Text = String.Empty;
            textName.Text = String.Empty;
            textTeam.Text = String.Empty;
            textGames.Text = String.Empty;
            textFieldGoals.Text = String.Empty;
            textThreePointers.Text = String.Empty;
            textPoints.Text = String.Empty;

            listBasketBall.UnselectAll();
            menuDelete.IsEnabled = false;
            menuUpdate.IsEnabled = false;
            lblID.Visibility = Visibility.Hidden;
            lblPoints.Visibility = Visibility.Hidden;
            textId.Visibility = Visibility.Hidden;
            textPoints.Visibility = Visibility.Hidden;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnClear.Visibility = Visibility.Hidden;
            btnClear.IsEnabled = false;
            btnInsert.Visibility = Visibility.Visible;
            btnInsert.IsEnabled = true;
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxClear();
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

        private void menuAboutMe_Click(object sender, RoutedEventArgs e)
        {
            AboutMe aboutMe = new AboutMe();
            aboutMe.ShowDialog();
        }



    }
}
