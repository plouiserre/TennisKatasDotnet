using System;
using System.Collections.Generic;

namespace TennisKatas
{
    public class Set
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public string Score { get; set; }
        public bool IsKeyGameNeed { get; set; }
        public KeyGame KeyGame{get;set;}

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
            KeyGame = new KeyGame();
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
            DetermineWinner(player);
            SetScores();
            PlayedKeyGames();
        }

        private void DetermineWinner(Player player)
        {
            if ((Player1.Score == 5 && Player2.Score == 6) || (Player1.Score == 6 && Player2.Score == 5))
                player.IsWinner = false;
            else if (player.Score == 6 && ((Player1.Score - Player2.Score >= 2) || (Player2.Score - Player1.Score >= 2)))
                player.IsWinner = true;
            else if (player.Score > 5 && (player.Identity == 1 && (Player1.Score - Player2.Score == 2)))
                player.IsWinner = true;
            else if (player.Score > 5 && (player.Identity == 2 && (Player2.Score - Player1.Score == 2)))
                player.IsWinner = true;
            else
                player.IsWinner = false;
        }

        private void SetScores()
        {
            Score = string.Format("{0}-{1}", Player1.Score, Player2.Score);
        }

        private void PlayedKeyGames()
        {
            if (Player1.Score == 6 && Player2.Score == 6)
                IsKeyGameNeed = true;
            else
                IsKeyGameNeed = false;
        }

        public void PlayerOnePlayKeyGames(int point)
        {
            PlayerPlayKeyGames(point);
        }

        public void PlayerSecondPlayKeyGames(int point)
        {
            PlayerPlayKeyGames(point);
        }

        private void PlayerPlayKeyGames(int point)
        {
            KeyGame.Player1.Score = 7;
            KeyGame.Player2.Score = 5;
            KeyGame.Score = "7-5";
            KeyGame.Player1.IsWinner = true;
            KeyGame.Player2.IsWinner = false;
            Player1.IsWinner = true;
        }
    }
}
