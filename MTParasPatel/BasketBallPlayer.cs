using System;
using System.Collections.Generic;
using System.Text;

namespace MTParasPatel
{
    class BasketBallPlayer : Player
    {
        private int _fieldGoals;

        public int FieldGoals
        {
            get { return _fieldGoals; }
            set { _fieldGoals = value; }
        }

        private int _threePointers;

        public int ThreePointers
        {
            get { return _threePointers; }
            set { _threePointers = value; }
        }
        public BasketBallPlayer(int playerId, PlayerType playerType, string playerName, string teamName,
          int gamesPlayed, int fieldGoals, int threePointers) : base(playerId, playerType, playerName, teamName, gamesPlayed)
        {
            FieldGoals = fieldGoals;
            ThreePointers = threePointers;
        }
        /*overriding the base class abstract method*/
        public override int Points()
        {
            return ((FieldGoals - ThreePointers) + (2 * ThreePointers));
        }
       
    }
}
