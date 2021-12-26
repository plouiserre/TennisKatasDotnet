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
        public KeyGame KeyGame{ get; set;}

        private SexPlayer _sexPlayer { get; set; }

        public Set(SexPlayer sexPlayer)
        {
            Player1 = new Player(sexPlayer) { Identity = 1 };
            Player2 = new Player(sexPlayer) { Identity = 2 }; 
        }

        public void SetStart()
        {
            Score = "0-0";
            KeyGame = new KeyGame(_sexPlayer);
        }

        public void PlayerOneScoreGames(List<Game> games)
        {
            PlayerScore(games.Count, Player1);
        }

        public void PlayerTwoScoreGames(List<Game> games)
        {
            PlayerScore(games.Count, Player2);
        }

        public void GetsInfosFromScore()
        {
            var scores = Score.Split("-");
            Player1.Score = int.Parse(scores[0]);
            Player2.Score = int.Parse(scores[1]);
            Player1.IsWinner = Player1.Score >= 6 && Player1.Score > Player2.Score? true : false;
            Player2.IsWinner = Player2.Score >= 6 && Player2.Score > Player1.Score ? true : false;
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
            KeyGame.PlayerOneScores(point);
            LinkResultKeyGamesSet();
        }

        public void PlayerSecondPlayKeyGames(int point)
        {
            KeyGame.PlayerSecondScores(point);
            LinkResultKeyGamesSet();
        }

        private void LinkResultKeyGamesSet()
        {
            Player1.IsWinner = KeyGame.Player1.IsWinner;
            Player2.IsWinner = KeyGame.Player2.IsWinner;
        }
    }
}
