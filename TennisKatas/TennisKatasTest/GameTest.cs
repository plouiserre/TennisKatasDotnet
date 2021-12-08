using System;
using TennisKatas;
using Xunit;

namespace TennisKatasTest
{
    public class GameTest
    {
        [Fact]
        public void GameStart()
        {
            Game game = new Game();

            game.StartGame();

            Assert.Equal("0-0", game.Score);
        }

        [Fact]
        public void PlayerOneScoresOneTime()
        {
            Game game = new Game();

            game.StartGame();
            game.PlayerOneScores();

            Assert.Equal("15-0", game.Score);
        }

        [Fact]
        public void PlayerOneScoresTwoTimes()
        {
            Game game = new Game();

            game.StartGame();
            game.PlayerOneScores();
            game.PlayerOneScores();

            Assert.Equal("30-0", game.Score);
        }

        [Fact]
        public void PlayerOneScoresThreeTimes()
        {
            Game game = new Game();

            game.StartGame();
            game.PlayerOneScores();
            game.PlayerOneScores();
            game.PlayerOneScores();

            Assert.Equal("40-0", game.Score);
        }

        [Fact]
        public void PlayerOneScoresFourTimesWinGame()
        {
            Game game = new Game();

            game.StartGame();
            game.PlayerOneScores();
            game.PlayerOneScores();
            game.PlayerOneScores();

            Assert.Equal("40-0", game.Score);
            Assert.Equal("Player 1", game.Winner);
        }

        [Fact]
        public void PlayerOneScoresTwoTimesPlayerSecondScoresOnce()
        {
            Game game = new Game();

            game.StartGame();
            game.PlayerOneScores();
            game.PlayerOneScores();
            game.PlayerSecondScores();

            Assert.Equal("30-15", game.Score);
        }
        [Fact]
        public void PlayerOneScoresFourTimesPlayerSecondScoresOnce()
        {
            Game game = new Game();

            game.StartGame();
            game.PlayerOneScores();
            game.PlayerOneScores();
            game.PlayerSecondScores();

            Assert.Equal("30-15", game.Score);
        }

        [Fact]
        public void PlayerOneScoreTwoTimesPlayerSecondWinGame()
        {
            Game game = new Game();

            game.StartGame();
            game.PlayerOneScores();
            game.PlayerOneScores();

            game.PlayerSecondScores();
            game.PlayerSecondScores();
            game.PlayerSecondScores();
            game.PlayerSecondScores();

            Assert.Equal("30-40", game.Score);
            Assert.Equal("Player 2", game.Winner);
        }

        [Fact]
        public void PlayerOneScoreAvantagePlayerSecondScoreThreeTime()
        {
            Game game = new Game();

            game.StartGame();
            game.PlayerOneScores();
            game.PlayerOneScores();
            game.PlayerOneScores();

            game.PlayerSecondScores();
            game.PlayerSecondScores();
            game.PlayerSecondScores();

            game.PlayerOneScores();

            Assert.Equal("A-40", game.Score);
        }

        [Fact]
        public void PlayerOnePlayerSecondEqualityAfterEachHaveAvantage()
        {
            Game game = new Game();

            game.StartGame();
            game.PlayerOneScores();
            game.PlayerOneScores();
            game.PlayerOneScores();

            game.PlayerSecondScores();
            game.PlayerSecondScores();
            game.PlayerSecondScores();

            game.PlayerOneScores();

            game.PlayerSecondScores();

            Assert.Equal("40-40", game.Score);
        }

        //TODO faire des boucles de jeu pour éviter d'avoir à duppliquer du code
    }
}
