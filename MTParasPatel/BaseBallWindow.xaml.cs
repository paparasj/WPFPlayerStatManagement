using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MTParasPatel
{
    /// <summary>
    /// Interaction logic for BaseBallWindow.xaml
    /// </summary>
    public partial class BaseBallWindow : Window
    {

        /*defining static list*/
        static List<BaseBallPlayer> baseBallPlayer = new List<BaseBallPlayer>();
        /*defining static unique index*/
        static int uniqueIndex = 1;
        public BaseBallWindow()
        {
           
            InitializeComponent();
            /*Adding some data if list is empty*/

            if (baseBallPlayer.Count == 0) {
                BaseBallPlayer pbb1 = new BaseBallPlayer(uniqueIndex++, PlayerType.BaseBallPlayer, "Alejandro Kirk", "Blue Jays", 9, 4, 1);
                baseBallPlayer.Add(pbb1);
                BaseBallPlayer pbb2 = new BaseBallPlayer(uniqueIndex++, PlayerType.BaseBallPlayer, "Kyle Higashioka", "Yankees", 16, 7, 4);
                baseBallPlayer.Add(pbb2);
                BaseBallPlayer pbb3 = new BaseBallPlayer(uniqueIndex++, PlayerType.BaseBallPlayer, "Gs Tatla", "Brampton Sher", 1, 15, 11);
                baseBallPlayer.Add(pbb3);
                BaseBallPlayer pbb4 = new BaseBallPlayer(uniqueIndex++, PlayerType.BaseBallPlayer, "Amandeep Patti", "Brampton Sher", 1, 1, 1);
                baseBallPlayer.Add(pbb4);
                BaseBallPlayer pbb5 = new BaseBallPlayer(uniqueIndex++, PlayerType.BaseBallPlayer, "Andrew Johnson", "GTA", 16, 15, 11);
                baseBallPlayer.Add(pbb5);
            }
         }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }

        public void LoadList()
        {
            var baseballplayers = from player in baseBallPlayer
                                select player.PlayerName;

            listBaseBall.ItemsSource = baseballplayers;
        }


        private void listBaseBall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listBaseBall.SelectedIndex;
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
                var hp = (from player in baseBallPlayer
                          where player.PlayerName == baseBallPlayer[index].PlayerName
                          select player).FirstOrDefault();

               if (hp != null)
                {
                    textId.Text = hp.PlayerId.ToString();
                    textName.Text = hp.PlayerName;
                    textTeam.Text = hp.TeamName;
                    textGames.Text = hp.GamesPlayed.ToString();
                    textRuns.Text = hp.Runs.ToString();
                    textHomeRuns.Text = hp.HomeRuns.ToString();
                    textPoints.Text = hp.Points().ToString();
                }
            }

        }


        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            int game, runs, homeruns;
            if (Int32.TryParse(textGames.Text, out game) && Int32.TryParse(textRuns.Text, out runs) && Int32.TryParse(textHomeRuns.Text, out homeruns))
            {
                BaseBallPlayer p1 = new BaseBallPlayer(uniqueIndex++, PlayerType.HockeyPlayer, textName.Text,
                                textTeam.Text, game, runs, homeruns);
                baseBallPlayer.Add(p1);
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
            int index = listBaseBall.SelectedIndex;
            if (index != -1)
            {
                BaseBallPlayer hp = baseBallPlayer[index];
                int game, runs, homeruns;
                if (Int32.TryParse(textGames.Text, out game) && Int32.TryParse(textRuns.Text, out runs) && Int32.TryParse(textHomeRuns.Text, out homeruns))
                {
                    var result = MessageBox.Show("Do you really want to update this players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        hp.PlayerName = textName.Text;
                        hp.TeamName = textTeam.Text;
                        hp.GamesPlayed = game;
                        hp.Runs = runs;
                        hp.HomeRuns = homeruns;
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
            int index = listBaseBall.SelectedIndex;
            var result = MessageBox.Show("Do you really want to delete this players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);


            if (index != -1 && result == MessageBoxResult.Yes)
            {
                baseBallPlayer.RemoveAt(index);
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
            textRuns.Text = String.Empty;
            textHomeRuns.Text = String.Empty;
            textPoints.Text = String.Empty;

            listBaseBall.UnselectAll();
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
