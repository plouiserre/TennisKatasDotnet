using System;
using Xunit;
using TennisKatas;
using System.Collections.Generic;

namespace TennisKatasTest
{
    public class MatchTest
    {
        [Fact]
        public void MatchStart()
        {
            var match = new Match();

            match.Start();

            Assert.False(match.PlayerOne.IsWinner);
            Assert.False(match.PlayerSecond.IsWinner);
            Assert.Equal("0-0", match.Score);
        }

        [Fact]
        public void PlayerOneWinsThreeSetsAndMatch()
        {
            var match = new Match();
            var sets = new List<Set>();
            sets.Add(new Set() { Score = "6-3" });
            sets.Add(new Set() { Score = "6-3" });
            sets.Add(new Set() { Score = "6-3" });

            match.Start();
            match.PlayerFirstScores(sets);

            Assert.True(match.PlayerOne.IsWinner);
            Assert.False(match.PlayerSecond.IsWinner);
            Assert.Equal("6-3 6-3 6-3", match.Score);
        }

        [Fact]
        public void PlayerSecondWinsThreeSetsAndMatch()
        {
            var match = new Match();
            var sets = new List<Set>();
            sets.Add(new Set() { Score = "3-6" });
            sets.Add(new Set() { Score = "3-6" });
            sets.Add(new Set() { Score = "3-6" });

            match.Start();
            match.PlayerSecondScores(sets);

            Assert.False(match.PlayerOne.IsWinner);
            Assert.True(match.PlayerSecond.IsWinner);
            Assert.Equal("3-6 3-6 3-6", match.Score);
        }

        [Fact]
        public void PlayerFirstWinsOneSetPlayerSecondWinsTwoSetsAndMatch()
        {
            var match = new Match();
            var sets = new List<Set>();
            sets.Add(new Set() { Score = "6-2" });
            sets.Add(new Set() { Score = "3-6" });
            sets.Add(new Set() { Score = "1-6" });

            match.Start();
            match.PlayersScores(sets);

            Assert.False(match.PlayerOne.IsWinner);
            Assert.True(match.PlayerSecond.IsWinner);
            Assert.Equal("6-2 3-6 1-6", match.Score);
        }

        [Fact]
        public void PlayerFirstWinsTwoSetsAndMatchsPlayerSecondWinsOneSet()
        {
            var match = new Match();
            var sets = new List<Set>();
            sets.Add(new Set() { Score = "6-2" });
            sets.Add(new Set() { Score = "7-6" });
            sets.Add(new Set() { Score = "1-6" });

            match.Start();
            match.PlayersScores(sets);

            Assert.True(match.PlayerOne.IsWinner);
            Assert.False(match.PlayerSecond.IsWinner);
            Assert.Equal("6-2 7-6 1-6", match.Score);
        }
    }
}
