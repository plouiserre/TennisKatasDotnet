using System;
using System.Collections.Generic;
using TennisKatas;
using Xunit;

namespace TennisKatasTest
{
    public class SetTest
    {
        public SetTest()
        {
        }

        [Fact]
        public void SetStart()
        {
            Set set = new Set();

            set.SetStart();

            Assert.Equal("0-0", set.Score);
        }

        [Fact]
        public void PlayerTwoScoresFourGamesPlayerOneScoresSixGamesAndWinSet()
        {
            Set set = new Set();

            set.SetStart();
            set.PlayerOneScoreGames(6);
            set.PlayerTwoScoreGames(4);

            Assert.Equal(6, set.Player1.Score);
            Assert.Equal(4, set.Player2.Score);
            Assert.Equal("6-4", set.Score);
            Assert.True(set.Player1.IsWinner);            
        }

        [Fact]
        public void PlayerOneScoresTwoGamesPlayerSecondScoresSixGamesAndWinSet()
        {
            Set set = new Set();

            set.SetStart();
            set.PlayerOneScoreGames(2);
            set.PlayerTwoScoreGames(6);

            Assert.Equal(2, set.Player1.Score);
            Assert.Equal(6, set.Player2.Score);
            Assert.Equal("2-6", set.Score);
            Assert.True(set.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneScoreSixGamesPlayerSecondScoreFiveGameNoWinner()
        {
            Set set = new Set();

            set.SetStart();
            set.PlayerOneScoreGames(5);
            set.PlayerTwoScoreGames(5);
            set.PlayerOneScoreGames(1);

            Assert.Equal(6, set.Player1.Score);
            Assert.Equal(5, set.Player2.Score);
            Assert.Equal("6-5", set.Score);
            Assert.False(set.Player1.IsWinner);
            Assert.False(set.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneScoreFivesGamesPlayerSecondScoreSevenGamesAndWinSet()
        {
            Set set = new Set();

            set.SetStart();
            set.PlayerOneScoreGames(5);
            set.PlayerTwoScoreGames(7);

            Assert.Equal(5, set.Player1.Score);
            Assert.Equal(7, set.Player2.Score);
            Assert.Equal("5-7", set.Score);
            Assert.False(set.Player1.IsWinner);
            Assert.True(set.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneScoreSixGamesPlayerSecondScoreSixGamesAndKeyGamesNeeded()
        {

            Set set = new Set();

            set.SetStart();
            set.PlayerOneScoreGames(5);
            set.PlayerTwoScoreGames(6);
            set.PlayerOneScoreGames(1);

            Assert.Equal(6, set.Player1.Score);
            Assert.Equal(6, set.Player2.Score);
            Assert.Equal("6-6", set.Score);
            Assert.False(set.Player1.IsWinner);
            Assert.False(set.Player2.IsWinner);
            Assert.True(set.IsKeyGameNeed);
        }

        [Fact]
        public void PlayerSecondScoreSixGamesPlayerOneScoreSixGamesWinKeyGamesAndSet()
        {
            Set set = new Set();

            set.SetStart();
            set.PlayerOneScoreGames(5);
            set.PlayerTwoScoreGames(6);
            set.PlayerOneScoreGames(1);
            set.PlayerOnePlayKeyGames(7);
            set.PlayerSecondPlayKeyGames(5);

            Assert.Equal(6, set.Player1.Score);
            Assert.Equal(6, set.Player2.Score);
            Assert.Equal("6-6", set.Score);
            Assert.True(set.IsKeyGameNeed);
            Assert.Equal(7, set.KeyGame.Player1.Score);
            Assert.Equal(5, set.KeyGame.Player2.Score);
            Assert.Equal("7-5", set.KeyGame.Score);
            Assert.True(set.KeyGame.Player1.IsWinner);
            Assert.False(set.KeyGame.Player2.IsWinner);
            Assert.True(set.Player1.IsWinner);
            Assert.False(set.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneScoreSixGamesPlayerSecondScoreSixGamesWinKeyGamesAndSet()
        {
            Set set = new Set();

            set.SetStart();
            set.PlayerOneScoreGames(5);
            set.PlayerTwoScoreGames(6);
            set.PlayerOneScoreGames(1);
            set.PlayerOnePlayKeyGames(5);
            set.PlayerSecondPlayKeyGames(7);

            Assert.Equal(6, set.Player1.Score);
            Assert.Equal(6, set.Player2.Score);
            Assert.Equal("6-6", set.Score);
            Assert.True(set.IsKeyGameNeed);
            Assert.Equal(5, set.KeyGame.Player1.Score);
            Assert.Equal(7, set.KeyGame.Player2.Score);
            Assert.Equal("5-7", set.KeyGame.Score);
            Assert.False(set.KeyGame.Player1.IsWinner);
            Assert.True(set.KeyGame.Player2.IsWinner);
            Assert.False(set.Player1.IsWinner);
            Assert.True(set.Player2.IsWinner);
        }

        [Fact]
        public void PlayersPlaysNineGameOneWinsSixGamesSecondWinsThreeGamesOneWinsSet()
        {
            Set set = new Set();
            var gamesPlayerOne = PlayerWinsGames(6);
            var gamesPlayerSecond = PlayerWinsGames(3);

            set.SetStart();
            set.PlayerOneScoreGames(gamesPlayerOne);
            set.PlayerTwoScoreGames(gamesPlayerSecond);

            Assert.Equal(6, set.Player1.Score);
            Assert.Equal(3, set.Player2.Score);
            Assert.Equal("6-3", set.Score);
            Assert.True(set.Player1.IsWinner);
            Assert.False(set.Player2.IsWinner);
        }

        [Fact]
        public void PlayersPlaysEightGameOneWinsTwoGamesSecondWinsSixGamesSecondWinsSet()
        {
            Set set = new Set();
            var gamesPlayerOne = PlayerWinsGames(2);
            var gamesPlayerSecond = PlayerWinsGames(6);

            set.SetStart();
            set.PlayerOneScoreGames(gamesPlayerOne);
            set.PlayerTwoScoreGames(gamesPlayerSecond);

            Assert.Equal(2, set.Player1.Score);
            Assert.Equal(6, set.Player2.Score);
            Assert.Equal("2-6", set.Score);
            Assert.False(set.Player1.IsWinner);
            Assert.True(set.Player2.IsWinner);
        }

        [Fact]
        public void PlayersPlaysElevenGamesWithKeyGamesFirstWinsKeyGamesSet()
        {
            Set set = new Set();
            var gamesPlayerOne = PlayerWinsGames(6);
            var gamesPlayerSecond = PlayerWinsGames(6);

            set.SetStart();
            set.PlayerOneScoreGames(gamesPlayerOne);
            set.PlayerTwoScoreGames(gamesPlayerSecond);
            set.PlayerOnePlayKeyGames(7);
            set.PlayerSecondPlayKeyGames(5);

            Assert.Equal(6, set.Player1.Score);
            Assert.Equal(6, set.Player2.Score);
            Assert.Equal("6-6", set.Score);
            Assert.True(set.IsKeyGameNeed);
            Assert.True(set.Player1.IsWinner);
            Assert.False(set.Player2.IsWinner);
        }

        [Fact]
        public void PlayersPlaysElevenGamesWithKeyGamesSecondWinsKeyGamesSet()
        {
            Set set = new Set();
            var gamesPlayerOne = PlayerWinsGames(6);
            var gamesPlayerSecond = PlayerWinsGames(6);

            set.SetStart();
            set.PlayerOneScoreGames(gamesPlayerOne);
            set.PlayerTwoScoreGames(gamesPlayerSecond);
            set.PlayerOnePlayKeyGames(5);
            set.PlayerSecondPlayKeyGames(7);

            Assert.Equal(6, set.Player1.Score);
            Assert.Equal(6, set.Player2.Score);
            Assert.Equal("6-6", set.Score);
            Assert.True(set.IsKeyGameNeed);
            Assert.False(set.Player1.IsWinner);
            Assert.True(set.Player2.IsWinner);
        }

        private List<Game> PlayerWinsGames(int gamesPoint)
        {
            List<Game> games = new List<Game>();
            for (int i = 0; i < gamesPoint; i++)
            {
                var game = new Game() { Player1 = new Player() { IsWinner = true } };
                games.Add(game);
            }
            return games;
        }
    }
}
