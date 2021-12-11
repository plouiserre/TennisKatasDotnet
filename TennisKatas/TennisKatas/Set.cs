using System;
using System.Collections.Generic;

namespace TennisKatas
{
    public class Set
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public string Score { get; set; }

        public Set()
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

        public void SetStart()
        {
            Score = "0-0";
        }

        public void PlayerOneScoreGames(int games)
        {
            PlayerScore(games, Player1);
        }

        public void PlayerTwoScoreGames(int games)
        {
            PlayerScore(games, Player2);
        }

        private void PlayerScore(int games, Player player)
        {
            for (int i = 0; i < games; i++)
            {
                //TODO améliorer
                int score = player.Score + 1;
                player.Score = score;
            }
            if (player.Score == 6)
                player.IsWinner = true;
            SetScores();
        }

        private void SetScores()
        {
            Score = string.Format("{0}-{1}", Player1.Score, Player2.Score);
        }
    }
}
