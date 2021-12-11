using System;
using System.Collections.Generic;

namespace TennisKatas
{
    public class Game
    {

        private Dictionary<int, int> scores;
                
        public string Score { get; set; }

        public string Winner { get; set; }

        public Game()
        {
            scores = new Dictionary<int, int>();
            scores.Add(1, 0);
            scores.Add(2, 0);
        }

        public void StartGame()
        {
            Score = "0-0";
        }

        public void PlayerOneScores()
        {
            int score = DetermineScore(scores[1],1);
            scores[1] = score;
            if (scores[1] == 40)
            {
                Winner = "Player 1";
            }
            GetScore();
        }

        public void PlayerSecondScores()
        {
            int score = DetermineScore(scores[2],2) ;
            scores[2] = score;
            if (scores[2] == 40)
            {
                Winner = "Player 2";
            }
            GetScore();
        }

        //TODO modifier cette méthode car elle est nulle
        private int DetermineScore(int score, int keyPlayer)
        {
            if (score == 0)
            {
                score = 15;
            }
            else if (score == 15)
            {
                score = 30;
            }
            else if (scores[1] == 40 && scores[2] == 40)
            {
                score = 50;
            }
            else if((scores[1] == 50 && keyPlayer == 2) || (scores[2] == 50 && keyPlayer == 1))
            {
                //on baisse le score de l'autre adversaire
                int k = keyPlayer == 1 ? 2 : 1;
                scores[k] = 40;
            }
            else
            {
                score = 40;
            }
            return score;
        }

        private void GetScore()
        {
            if (scores[1] == 50)
            {
                Score = string.Concat("A-", scores[2].ToString());
            }
            else if (scores[2] == 50)
            {
                Score = string.Concat(scores[1].ToString(), "-A");
            }
            else
            {
                Score = string.Concat(scores[1].ToString(), "-", scores[2].ToString());
            }
        }
    }
}
