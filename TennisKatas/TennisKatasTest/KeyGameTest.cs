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
    }
}
