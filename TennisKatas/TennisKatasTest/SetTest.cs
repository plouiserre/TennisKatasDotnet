using System;
using System.Collections.Generic;
using TennisKatas;
using Xunit;

namespace TennisKatasTest
{
    public class SetTest
    {
        private Player _playerOne { get;set; }
        private Player _playerSecond { get; set; }
        private Set _set { get; set; }

        public SetTest()
        {
        }

        [Fact]
        public void SetStart()
        {
            _set = new Set();

            _set.SetStart();

            Assert.Equal("0-0", _set.Score);
        }

        [Fact]
        public void PlayersPlaysNineGameOneWinsSixGamesSecondWinsThreeGamesOneWinsSet()
        {
            _set = new Set();
            var gamesPlayerOne = PlayerWinsGames(6);
            var gamesPlayerSecond = PlayerWinsGames(3);

            _set.SetStart();
            _set.PlayerOneScoreGames(gamesPlayerOne);
            _set.PlayerTwoScoreGames(gamesPlayerSecond);

            Assert.Equal(6, _set.Player1.Score);
            Assert.Equal(3, _set.Player2.Score);
            Assert.Equal("6-3", _set.Score);
            Assert.True(_set.Player1.IsWinner);
            Assert.False(_set.Player2.IsWinner);
        }

        [Fact]
        public void PlayersPlaysEightGameOneWinsTwoGamesSecondWinsSixGamesSecondWinsSet()
        {
            _set = new Set();
            var gamesPlayerOne = PlayerWinsGames(2);
            var gamesPlayerSecond = PlayerWinsGames(6);

            _set.SetStart();
            _set.PlayerOneScoreGames(gamesPlayerOne);
            _set.PlayerTwoScoreGames(gamesPlayerSecond);

            Assert.Equal(2, _set.Player1.Score);
            Assert.Equal(6, _set.Player2.Score);
            Assert.Equal("2-6", _set.Score);
            Assert.False(_set.Player1.IsWinner);
            Assert.True(_set.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneScoreSixGamesPlayerSecondScoreFiveGameNoWinner()
        {
            _set = new Set();
            var gamesPlayerOne = PlayerWinsGames(5);
            var gamesPlayerSecond = PlayerWinsGames(5);
            var nextGamesPlayerOne = PlayerWinsGames(1);

            _set.SetStart();
            _set.PlayerOneScoreGames(gamesPlayerOne);
            _set.PlayerTwoScoreGames(gamesPlayerSecond);
            _set.PlayerOneScoreGames(nextGamesPlayerOne);

            Assert.Equal(6, _set.Player1.Score);
            Assert.Equal(5, _set.Player2.Score);
            Assert.Equal("6-5", _set.Score);
            Assert.False(_set.Player1.IsWinner);
            Assert.False(_set.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneScoreSixGamesPlayerSecondScoreSixGamesAndKeyGamesNeeded()
        {
            _set = new Set();
            var gamesPlayerOne = PlayerWinsGames(5);
            var gamesPlayerSecond = PlayerWinsGames(6);
            var nextGamesPlayerOne = PlayerWinsGames(1);

            _set.SetStart();
            _set.PlayerOneScoreGames(gamesPlayerOne);
            _set.PlayerTwoScoreGames(gamesPlayerSecond);
            _set.PlayerOneScoreGames(nextGamesPlayerOne);

            Assert.Equal(6, _set.Player1.Score);
            Assert.Equal(6, _set.Player2.Score);
            Assert.Equal("6-6", _set.Score);
            Assert.False(_set.Player1.IsWinner);
            Assert.False(_set.Player2.IsWinner);
            Assert.True(_set.IsKeyGameNeed);
        }
        
        [Fact]
        public void PlayersPlaysElevenGamesWithKeyGamesFirstWinsKeyGamesSet()
        {
            _set = new Set();
            var gamesPlayerOne = PlayerWinsGames(6);
            var gamesPlayerSecond = PlayerWinsGames(6);

            _set.SetStart();
            _set.PlayerOneScoreGames(gamesPlayerOne);
            _set.PlayerTwoScoreGames(gamesPlayerSecond);
            _set.PlayerOnePlayKeyGames(7);
            _set.PlayerSecondPlayKeyGames(5);

            Assert.Equal(6, _set.Player1.Score);
            Assert.Equal(6, _set.Player2.Score);
            Assert.Equal("6-6", _set.Score);
            Assert.True(_set.IsKeyGameNeed);
            Assert.Equal(7, _set.KeyGame.Player1.Score);
            Assert.Equal(5, _set.KeyGame.Player2.Score);
            Assert.Equal("7-5", _set.KeyGame.Score);
            Assert.True(_set.Player1.IsWinner);
            Assert.False(_set.Player2.IsWinner);
        }

        [Fact]
        public void PlayersPlaysElevenGamesWithKeyGamesSecondWinsKeyGamesSet()
        {
            _set = new Set();
            var gamesPlayerOne = PlayerWinsGames(6);
            var gamesPlayerSecond = PlayerWinsGames(6);

            _set.SetStart();
            _set.PlayerOneScoreGames(gamesPlayerOne);
            _set.PlayerTwoScoreGames(gamesPlayerSecond);
            _set.PlayerOnePlayKeyGames(5);
            _set.PlayerSecondPlayKeyGames(7);

            Assert.Equal(6, _set.Player1.Score);
            Assert.Equal(6, _set.Player2.Score);
            Assert.Equal("6-6", _set.Score);
            Assert.True(_set.IsKeyGameNeed);
            Assert.Equal(5, _set.KeyGame.Player1.Score);
            Assert.Equal(7, _set.KeyGame.Player2.Score);
            Assert.Equal("5-7", _set.KeyGame.Score);
            Assert.False(_set.Player1.IsWinner);
            Assert.True(_set.Player2.IsWinner);
        }

        private List<Game> PlayerWinsGames(int gamesPoint)
        {
            List<Game> games = new List<Game>();
            for (int i = 0; i < gamesPoint; i++)
            {
                var game = new Game(SexPlayer.Female) { Player1 = new Player(SexPlayer.Female) { IsWinner = true } };
                games.Add(game);
            }
            return games;
        }

        [Fact]
        public void PlayerOneScoreFiveSetPlayerTwoScoreTwoSetsNoWinner()
        {
            _set = new Set();
            _set.Score = "5-2";

            _set.GetsInfosFromScore();

            Assert.Equal(5, _set.Player1.Score);
            Assert.Equal(2, _set.Player2.Score);
            Assert.False(_set.Player1.IsWinner);
            Assert.False(_set.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneScoreFourSetPlayerTwoScoreFiveSetsNoWinner()
        {
            _set = new Set();
            _set.Score = "4-5";

            _set.GetsInfosFromScore();

            Assert.Equal(4, _set.Player1.Score);
            Assert.Equal(5, _set.Player2.Score);
            Assert.False(_set.Player1.IsWinner);
            Assert.False(_set.Player2.IsWinner);
        }


        [Fact]
        public void PlayerOneWinsSixSetPlayerTwoScoresTwoSets()
        {
            _set = new Set();
            _set.Score = "6-2";

            _set.GetsInfosFromScore();

            Assert.Equal(6, _set.Player1.Score);
            Assert.Equal(2, _set.Player2.Score);
            Assert.True(_set.Player1.IsWinner);
            Assert.False(_set.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneScoreThreeSetsPlayerTwoWinsSixSets()
        {
            _set = new Set();
            _set.Score = "3-6";

            _set.GetsInfosFromScore();

            Assert.Equal(3, _set.Player1.Score);
            Assert.Equal(6, _set.Player2.Score);
            Assert.False(_set.Player1.IsWinner);
            Assert.True(_set.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneWinsSevenSetsPlayerTwoScoresSixSets()
        {
            _set = new Set();
            _set.Score = "7-6";

            _set.GetsInfosFromScore();

            Assert.Equal(7, _set.Player1.Score);
            Assert.Equal(6, _set.Player2.Score);
            Assert.True(_set.Player1.IsWinner);
            Assert.False(_set.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneScoreSixSetsPlayerTwoWinsSevenSets()
        {
            _set = new Set();
            _set.Score = "6-7";

            _set.GetsInfosFromScore();

            Assert.Equal(6, _set.Player1.Score);
            Assert.Equal(7, _set.Player2.Score);
            Assert.False(_set.Player1.IsWinner);
            Assert.True(_set.Player2.IsWinner);
        }
    }
}
