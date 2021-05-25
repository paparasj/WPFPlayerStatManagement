using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MTParasPatel
{
    /// <summary>
    /// Interaction logic for HockeyWindow.xaml
    /// </summary>
    public partial class HockeyWindow : Window
    {
        /*defining static list*/
        static List<HockeyPlayer> hockeyPlayer = new List<HockeyPlayer>();
        /*defining static unique index*/
        static int uniqueIndex= 1;
        public HockeyWindow()
        {
            InitializeComponent();

            /*Adding some data if list is empty*/
            if (hockeyPlayer.Count == 0)
            {
                HockeyPlayer ph1 = new HockeyPlayer(uniqueIndex++, PlayerType.HockeyPlayer, "Paras Patel", "Swami Eleven", 1, 12, 13);
                hockeyPlayer.Add(ph1);
                HockeyPlayer ph2 = new HockeyPlayer(uniqueIndex++, PlayerType.HockeyPlayer, "Mitchell Marner", "Maple Leafs", 9, 5, 8);
                hockeyPlayer.Add(ph2);
                HockeyPlayer ph3 = new HockeyPlayer(uniqueIndex++, PlayerType.HockeyPlayer, "Connor McDavid", "Edmonton Oilers", 9, 5, 9);
                hockeyPlayer.Add(ph3);
                HockeyPlayer ph4 = new HockeyPlayer(uniqueIndex++, PlayerType.HockeyPlayer, "G Tatla", "Brampton Sher", 1, 10, 12);
                hockeyPlayer.Add(ph4);
                HockeyPlayer ph5 = new HockeyPlayer(uniqueIndex++, PlayerType.HockeyPlayer, "Jayesh Patel", "Apna Gujarat", 9, 85, 69);
                hockeyPlayer.Add(ph5);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }

        public void LoadList()
        {
            var hockeyplayers = from player in hockeyPlayer
                         select player.PlayerName;

            listHockey.ItemsSource = hockeyplayers;
        }

      
        private void listHockey_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listHockey.SelectedIndex;
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
                var hp = (from player in hockeyPlayer
                          where player.PlayerName == hockeyPlayer[index].PlayerName
                          select player).FirstOrDefault();

                //player.PlayerId == index
                //player.PlayerName == hockeyPlayer[index].PlayerName//
                if (hp != null)
                {
                    textId.Text = hp.PlayerId.ToString();
                    textName.Text = hp.PlayerName;
                    textTeam.Text = hp.TeamName;
                    textGames.Text = hp.GamesPlayed.ToString();
                    textAssists.Text = hp.Assists.ToString();
                    textGoals.Text = hp.Goals.ToString();
                    textPoints.Text = hp.Points().ToString();
                }
            }

        }

        
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            int game, assist, goal;
            if (Int32.TryParse(textGames.Text, out game) && Int32.TryParse(textAssists.Text, out assist) && Int32.TryParse(textGoals.Text, out goal))
            {
                HockeyPlayer p1 = new HockeyPlayer(uniqueIndex++, PlayerType.HockeyPlayer, textName.Text,
                                textTeam.Text, game, assist, goal);
                hockeyPlayer.Add(p1);
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
            int index = listHockey.SelectedIndex;
            if (index != -1)
            {
                HockeyPlayer hp = hockeyPlayer[index];
                int game, assist, goal;
                if (Int32.TryParse(textGames.Text, out game) && Int32.TryParse(textAssists.Text, out assist) && Int32.TryParse(textGoals.Text, out goal))
                {
                    var result = MessageBox.Show("Do you really want to update this players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        hp.PlayerName = textName.Text;
                        hp.TeamName = textTeam.Text;
                        hp.GamesPlayed = game;
                        hp.Assists = assist;
                        hp.Goals = goal;
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
            int index = listHockey.SelectedIndex;
            var result = MessageBox.Show("Do you really want to delete this players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);


            if (index != -1 && result == MessageBoxResult.Yes)
            {
                hockeyPlayer.RemoveAt(index);
                textBoxClear();
            }

            LoadList();
        }
        private void textBoxClear() {
            textId.Text = String.Empty;
            textName.Text = String.Empty;
            textTeam.Text = String.Empty;
            textGames.Text = String.Empty;
            textAssists.Text = String.Empty;
            textGoals.Text = String.Empty;
            textPoints.Text = String.Empty;
            
            listHockey.UnselectAll();
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
