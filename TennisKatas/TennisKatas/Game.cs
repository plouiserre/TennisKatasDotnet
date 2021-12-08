using System;
namespace TennisKatas
{
    public class Game
    {
        private int scorePlayerOne;
        private int scorePlayerTwo;

        public string Score { get; set; }

        public string Winner { get; set; }

        public Game()
        {
        }

        public void StartGame()
        {
            Score = "0-0";
        }

        public void PlayerOneScores()
        {
            scorePlayerOne = DetermineScore(scorePlayerOne);
            if (scorePlayerOne == 40)
            {
                Winner = "Player 1";
            }
            GetScore();
        }

        public void PlayerSecondScores()
        {
            scorePlayerTwo = DetermineScore(scorePlayerTwo);
            if (scorePlayerTwo == 40)
            {
                Winner = "Player 2";
            }
            GetScore();
        }

        private int DetermineScore(int score)
        {
            if (score == 0)
            {
                score = 15;
            }
            else if (score == 15)
            {
                score = 30;
            }
            else if (scorePlayerOne == 40 && scorePlayerTwo == 40)
            {
                score = 50;
            }
            else
            {
                score = 40;
            }
            return score;
        }

        private void GetScore()
        {
            if (scorePlayerOne == 50)
            {
                Score = string.Concat("A-", scorePlayerTwo.ToString());
            }
            else if (scorePlayerTwo == 50)
            {
                Score = string.Concat(scorePlayerOne.ToString(), "-A");
            }
            else
            {
                Score = string.Concat(scorePlayerOne.ToString(), "-", scorePlayerTwo.ToString());
            }
        }
    }
}
