using System;
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

            Assert.Equal(2, set.Scores.Count);
            Assert.Equal(0, set.Scores[1]);
            Assert.Equal(0, set.Scores[2]);
        }

        [Fact]
        public void PlayerTwoScoresFourGamesPlayerOneScoresSixGamesAndWinSet()
        {
            Set set = new Set();

            set.SetStart();
            set.PlayerOneScoreGames(6);
            set.PlayerTwoScoreGames(4);

            Assert.Equal(6, set.Scores[1]);
            Assert.Equal(4, set.Scores[2]);
            Assert.Equal("Player 1", set.Winner);
        }

        [Fact]
        public void PlayerOneScoresTwoGamesPlayerSecondScoresSixGamesAndWinSet()
        {
            Set set = new Set();

            set.SetStart();
            set.PlayerOneScoreGames(2);
            set.PlayerTwoScoreGames(6);

            Assert.Equal(2, set.Scores[1]);
            Assert.Equal(6, set.Scores[2]);
            Assert.Equal("Player 2", set.Winner);
        }
    }
}
