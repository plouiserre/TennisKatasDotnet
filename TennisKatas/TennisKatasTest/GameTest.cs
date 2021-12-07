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
        public void PlayerOneScoresFoursPlayerSecondScoresOnce()
        {
            Game game = new Game();

            game.StartGame();
            game.PlayerOneScores();
            game.PlayerOneScores();
            game.PlayerSecondScores();

            Assert.Equal("30-15", game.Score);
        }
    }
}
