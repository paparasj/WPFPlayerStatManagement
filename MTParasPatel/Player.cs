using System;
using System.Collections.Generic;
using System.Text;

namespace MTParasPatel
{
    public enum PlayerType
    {
        HockeyPlayer, BaseBallPlayer, BasketBallPlayer
    }
    public abstract class Player
    {

        private int _playerId;

        public int PlayerId
        {
            get { return _playerId; }
            set { _playerId = value; }
        }



        private PlayerType _playerType;

        public PlayerType PlayerType
        {
            get { return _playerType; }
            set { _playerType = value; }
        }

        private string _playerName;

        public string PlayerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }
        private string _teamName;

        public string TeamName
        {
            get { return _teamName; }
            set { _teamName = value; }
        }

        private int _gamesPlayed;

        public int GamesPlayed
        {
            get { return _gamesPlayed; }
            set
            {
                _gamesPlayed = value;
            }
        }

        /*constructor*/
        public Player(int playerId, PlayerType playerType, string playerName, string teamName, int gamesPlayed)
        {

            PlayerId = playerId;
            PlayerType = playerType;
            PlayerName = playerName;
            TeamName = teamName;
            GamesPlayed = gamesPlayed;
        }

        /*abstract method for points*/
        public abstract int Points();

        ///*toString method*/
        //public override string ToString()
        //{
        //    return $"{PlayerType,-20}{PlayerId,+12} {PlayerName,-20} {TeamName,-20} {GamesPlayed,+11}";
        //}


    }
}
