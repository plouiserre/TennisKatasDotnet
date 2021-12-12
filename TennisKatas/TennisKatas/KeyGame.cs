using System;
using System.Collections.Generic;

namespace TennisKatas
{
    public class KeyGame
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public string Score { get; set; }

        public KeyGame()
        {
            Player1 = new Player()
            {
                Identity = 1,
                Score = 0
            };
            Player2 = new Player()
            {
                Identity = 2,
                Score = 0
            };
        }

        public void StartKeyGame()
        {
            Score = "0-0";
        }

        public void PlayerOneScores(int score)
        {
            PlayerScore(Player1, score);
        }

        public void PlayerSecondScores(int score)
        {
            PlayerScore(Player2, score);
        }

        private void PlayerScore(Player player, int score)
        {
            player.Score = score;
            Score = string.Format("{0}-{1}", Player1.Score, Player2.Score);
            DetermineWinner();
        }

        private void DetermineWinner()
        {
            if (Player1.Score >= 7 && (Player1.Score - Player2.Score >= 2))
                Player1.IsWinner = true;
            else if (Player2.Score >= 7 && (Player2.Score - Player1.Score >= 2))
                Player2.IsWinner = true;
        }
    }
}
