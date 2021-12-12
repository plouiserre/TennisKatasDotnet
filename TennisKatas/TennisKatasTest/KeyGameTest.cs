using System;
using TennisKatas;
using Xunit;

namespace TennisKatasTest
{
    public class KeyGameTest
    {
        [Fact]
        public void KeyGameStart()
        {
            KeyGame keyGame = new KeyGame();

            keyGame.StartKeyGame();

            Assert.Equal(0, keyGame.Player1.Score);
            Assert.Equal(0, keyGame.Player2.Score);
            Assert.Equal("0-0", keyGame.Score);
            Assert.False(keyGame.Player1.IsWinner);
            Assert.False(keyGame.Player2.IsWinner);
        }

        [Fact]
        public void PlayerTwoScoresFourPointsPlayerOneScoresSevenPointsAndWinKeyGames()
        {
            KeyGame keyGame = new KeyGame();

            keyGame.StartKeyGame();
            keyGame.PlayerOneScores(7);
            keyGame.PlayerSecondScores(4);

            Assert.Equal(7, keyGame.Player1.Score);
            Assert.Equal(4, keyGame.Player2.Score);
            Assert.Equal("7-4", keyGame.Score);
            Assert.True(keyGame.Player1.IsWinner);
            Assert.False(keyGame.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneScoreFourPointsPlayerTwoScoresSevenPointsAndWinKeyGames()
        {
            KeyGame keyGame = new KeyGame();

            keyGame.StartKeyGame();
            keyGame.PlayerOneScores(4);
            keyGame.PlayerSecondScores(7);

            Assert.Equal(4, keyGame.Player1.Score);
            Assert.Equal(7, keyGame.Player2.Score);
            Assert.Equal("4-7", keyGame.Score);
            Assert.False(keyGame.Player1.IsWinner);
            Assert.True(keyGame.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneScoreSevenPointsPlayerTwoScoresSixPointsNoWinner()
        {
            KeyGame keyGame = new KeyGame();

            keyGame.StartKeyGame();
            keyGame.PlayerOneScores(6);
            keyGame.PlayerSecondScores(6);
            keyGame.PlayerOneScores(7);

            Assert.Equal(7, keyGame.Player1.Score);
            Assert.Equal(6, keyGame.Player2.Score);
            Assert.Equal("7-6", keyGame.Score);
            Assert.False(keyGame.Player1.IsWinner);
            Assert.False(keyGame.Player2.IsWinner);
        }

        [Fact]
        public void PlayerOneScoreSixPointsPlayerTwoScoresEightPointsAndWinGames()
        {
            KeyGame keyGame = new KeyGame();

            keyGame.StartKeyGame();
            keyGame.PlayerOneScores(6);
            keyGame.PlayerSecondScores(8);

            Assert.Equal(6, keyGame.Player1.Score);
            Assert.Equal(8, keyGame.Player2.Score);
            Assert.Equal("6-8", keyGame.Score);
            Assert.False(keyGame.Player1.IsWinner);
            Assert.True(keyGame.Player2.IsWinner);
        }
    }
}
