using System;
namespace TennisKatas
{
    public class Game
    {
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
            if (Score == "0-0")
            {
                Score = "15-0";
            }
            else if (Score == "15-0")
            {
                Score = "30-0";
            }
            else
            {
                Score = "40-0";
                Winner = "Player 1";
            }
        }

        public void PlayerSecondScores()
        {
            Score = "30-15";
        }
    }
}
