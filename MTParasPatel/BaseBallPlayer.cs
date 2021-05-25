using System;
using System.Collections.Generic;
using System.Text;

namespace MTParasPatel
{
    class BaseBallPlayer : Player
    {
        private int _runs;

        public int Runs
        {
            get { return _runs; }
            set { _runs = value; }
        }

        private int _homeRuns;

        public int HomeRuns
        {
            get { return _homeRuns; }
            set { _homeRuns = value; }
        }
        public BaseBallPlayer(int playerId, PlayerType playerType, string playerName, string teamName,
         int gamesPlayed, int runs, int homeRuns) : base(playerId, playerType, playerName, teamName, gamesPlayed)
        {
            Runs = runs;
            HomeRuns = homeRuns;
        }

        /*overriding the base class abstract method*/
        public override int Points()
        {
            return ((Runs - HomeRuns) + (2 * HomeRuns));
        }
       
    }
}
