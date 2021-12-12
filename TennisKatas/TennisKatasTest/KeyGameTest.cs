using System;
using TennisKatas;
using Xunit;

namespace TennisKatasTest
{
    public class KeyGameTest
    {
        public KeyGameTest()
        {
        }

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
    }
}
