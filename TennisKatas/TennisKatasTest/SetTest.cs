﻿using System;
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
    }
}
