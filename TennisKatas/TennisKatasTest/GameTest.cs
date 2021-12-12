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
            PlayerOnePlays(game, 2);

            Assert.Equal("30-0", game.Score);
        }

        [Fact]
        public void PlayerOneScoresThreeTimes()
        {
            Game game = new Game();

            game.StartGame();
            PlayerOnePlays(game, 3);

            Assert.Equal("40-0", game.Score);
        }

        [Fact]
        public void PlayerOneScoresFourTimesWinGame()
        {
            Game game = new Game();

            game.StartGame();
            PlayerOnePlays(game, 3);

            Assert.Equal("40-0", game.Score);
            Assert.True(game.Player1.IsWinner) ;
        }

        [Fact]
        public void PlayerOneScoresTwoTimesPlayerSecondScoresOnce()
        {
            Game game = new Game();

            game.StartGame();
            PlayerOnePlays(game, 2);
            game.PlayerSecondScores();

            Assert.Equal("30-15", game.Score);
        }
        [Fact]
        public void PlayerOneScoresFourTimesPlayerSecondScoresOnce()
        {
            Game game = new Game();

            game.StartGame();
            PlayerOnePlays(game, 2);
            game.PlayerSecondScores();

            Assert.Equal("30-15", game.Score);
        }

        [Fact]
        public void PlayerOneScoreTwoTimesPlayerSecondWinGame()
        {
            Game game = new Game();

            game.StartGame();
            PlayerOnePlays(game, 2);
            PlayerSecondPlays(game, 4);

            Assert.Equal("30-40", game.Score);
            Assert.True(game.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneScoreAvantagePlayerSecondScoreThreeTime()
        {
            Game game = new Game();

            game.StartGame();
            PlayerOnePlays(game, 3);
            PlayerSecondPlays(game, 3);
            game.PlayerOneScores();

            Assert.Equal("A-40", game.Score);
        }

        [Fact]
        public void PlayerOnePlayerSecondEqualityAfterEachHaveAvantage()
        {
            Game game = new Game();

            game.StartGame();
            PlayerOnePlays(game, 3);
            PlayerSecondPlays(game, 3);
            game.PlayerOneScores();
            game.PlayerSecondScores();
            Assert.Equal("40-40", game.Score);
        }

        [Fact]
        public void PlayerOneScoresThreeTimePlayerSecondWinGame()
        {
            Game game = new Game();

            game.StartGame();
            PlayerSecondPlays(game, 3);
            PlayerOnePlays(game, 3);
            PlayerSecondPlays(game, 2);

            Assert.True(game.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneBeatPlayerSecondInLongGame()
        {
            Game game = new Game();

            game.StartGame();
            PlayerOnePlays(game, 3);
            PlayerSecondPlays(game, 3);
            game.PlayerOneScores();
            game.PlayerSecondScores();
            PlayerOnePlays(game, 2);

            Assert.True(game.Player1.IsWinner);
        }

        private void PlayerOnePlays(Game game, int time)
        {
            for(int i = 0; i<time; i++)
            {
                game.PlayerOneScores();
            }
        }

        private void PlayerSecondPlays(Game game, int time)
        {
            for (int i = 0; i < time; i++)
            {
                game.PlayerSecondScores();
            }
        }
    }
}
