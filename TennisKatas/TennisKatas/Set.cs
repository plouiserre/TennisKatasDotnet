using System;
using System.Collections.Generic;

namespace TennisKatas
{
    public class Set
    {
        public Dictionary<int,int> Scores { get; set; }
        public string Winner { get; set; }

        public void SetStart()
        {
            Scores = new Dictionary<int, int>();
            Scores.Add(1, 0);
            Scores.Add(2, 0);
        }

        public void PlayerOneScoreGames(int games)
        {
            for (int i = 0; i < games; i++)
            {
                //TODO améliorer
                int score = Scores[1] + 1;
                Scores[1] = score;
            }
            if (Scores[1] == 6)
                Winner = "Player 1";
        }

        public void PlayerTwoScoreGames(int games)
        {
            for (int i = 0; i < games; i++)
            {
                //TODO améliorer
                int score = Scores[2] + 1;
                Scores[2] = score;
            }
            if (Scores[2] == 6)
                Winner = "Player 2";
        }
    }
}
