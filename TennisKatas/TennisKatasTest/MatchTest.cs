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
            var match = new Match(SexPlayer.Female);

            match.Start();

            Assert.False(match.PlayerOne.IsWinner);
            Assert.False(match.PlayerSecond.IsWinner);
            Assert.Equal("0-0", match.Score);
        }

        [Fact]
        public void PlayerOneWinsThreeSetsAndMatch()
        {
            var match = new Match(SexPlayer.Female);
            var sets = new List<Set>();
            sets.Add(new Set(SexPlayer.Female) { Score = "6-3" });
            sets.Add(new Set(SexPlayer.Female) { Score = "6-3" });
            sets.Add(new Set(SexPlayer.Female) { Score = "6-3" });

            match.Start();
            match.PlayerFirstScores(sets);

            Assert.True(match.PlayerOne.IsWinner);
            Assert.False(match.PlayerSecond.IsWinner);
            Assert.Equal("6-3 6-3 6-3", match.Score);
        }

        [Fact]
        public void PlayerSecondWinsThreeSetsAndMatch()
        {
            var match = new Match(SexPlayer.Female);
            var sets = new List<Set>();
            sets.Add(new Set(SexPlayer.Female) { Score = "3-6" });
            sets.Add(new Set(SexPlayer.Female) { Score = "3-6" });
            sets.Add(new Set(SexPlayer.Female) { Score = "3-6" });

            match.Start();
            match.PlayerSecondScores(sets);

            Assert.False(match.PlayerOne.IsWinner);
            Assert.True(match.PlayerSecond.IsWinner);
            Assert.Equal("3-6 3-6 3-6", match.Score);
        }

        [Fact]
        public void PlayerFirstWinsOneSetPlayerSecondWinsTwoSetsAndMatch()
        {
            var match = new Match(SexPlayer.Female);
            var sets = new List<Set>();
            sets.Add(new Set(SexPlayer.Female) { Score = "6-2" });
            sets.Add(new Set(SexPlayer.Female) { Score = "3-6" });
            sets.Add(new Set(SexPlayer.Female) { Score = "1-6" });

            match.Start();
            match.PlayersScores(sets);

            Assert.False(match.PlayerOne.IsWinner);
            Assert.True(match.PlayerSecond.IsWinner);
            Assert.Equal("6-2 3-6 1-6", match.Score);
        }

        [Fact]
        public void PlayerFirstWinsTwoSetsAndMatchsPlayerSecondWinsOneSet()
        {
            var match = new Match(SexPlayer.Female);
            var sets = new List<Set>();
            sets.Add(new Set(SexPlayer.Female) { Score = "6-2" });
            sets.Add(new Set(SexPlayer.Female) { Score = "7-6" });
            sets.Add(new Set(SexPlayer.Female) { Score = "1-6" });

            match.Start();
            match.PlayersScores(sets);

            Assert.True(match.PlayerOne.IsWinner);
            Assert.False(match.PlayerSecond.IsWinner);
            Assert.Equal("6-2 7-6 1-6", match.Score);
        }

        [Fact]
        public void MalesPlayerFirstWinsOneSetPlayerSecondWinsTwoSetsNoWinner()
        {
            var match = new Match(SexPlayer.Male);
            match.PlayerOne.SexPlayer = SexPlayer.Male;
            match.PlayerSecond.SexPlayer = SexPlayer.Male;
            var sets = new List<Set>();
            sets.Add(new Set(SexPlayer.Male) { Score = "6-2" });
            sets.Add(new Set(SexPlayer.Male) { Score = "3-6" });
            sets.Add(new Set(SexPlayer.Male) { Score = "1-6" });

            match.Start();
            match.PlayersScores(sets);

            Assert.False(match.PlayerOne.IsWinner);
            Assert.False(match.PlayerSecond.IsWinner);
            Assert.Equal("6-2 3-6 1-6", match.Score);
        }

        [Fact]
        public void FemalesPlayersPlayerFirstWinsTwoSetsAndMatchsPlayerSecondWinsOneSet()
        {
            var sexPlayer = SexPlayer.Female;
            var match = new Match(sexPlayer);
            var sets = new List<Set>();
            sets.Add(new Set(sexPlayer) { Score = "6-2" });
            sets.Add(new Set(sexPlayer) { Score = "7-6" });
            sets.Add(new Set(sexPlayer) { Score = "1-6" });

            match.Start();
            match.PlayersScores(sets);

            Assert.True(match.PlayerOne.IsWinner);
            Assert.False(match.PlayerSecond.IsWinner);
            Assert.Equal("6-2 7-6 1-6", match.Score);
        }

        [Fact]
        public void FemalesPlayersPlayerFirstWinsOneSetPlayerSecondWinsTwoSetsAndMatchs()
        {
            var sexPlayer = SexPlayer.Female;
            var match = new Match(sexPlayer);
            var sets = new List<Set>();
            sets.Add(new Set(sexPlayer) { Score = "6-2" });
            sets.Add(new Set(sexPlayer) { Score = "6-7" });
            sets.Add(new Set(sexPlayer) { Score = "6-7" });

            match.Start();
            match.PlayersScores(sets);

            Assert.False(match.PlayerOne.IsWinner);
            Assert.True(match.PlayerSecond.IsWinner);
            Assert.Equal("6-2 6-7 6-7", match.Score);
        }

        [Fact]
        public void MalesPlayersPlayerFirstWinsThreeSetsAndMatchsPlayerSecondWinsTwoSet()
        {
            var sexPlayer = SexPlayer.Female;
            var match = new Match(sexPlayer);
            var sets = new List<Set>();
            sets.Add(new Set(sexPlayer) { Score = "6-2" });
            sets.Add(new Set(sexPlayer) { Score = "7-6" });
            sets.Add(new Set(sexPlayer) { Score = "1-6" });
            sets.Add(new Set(sexPlayer) { Score = "6-2" });
            sets.Add(new Set(sexPlayer) { Score = "4-6" });

            match.Start();
            match.PlayersScores(sets);

            Assert.True(match.PlayerOne.IsWinner);
            Assert.False(match.PlayerSecond.IsWinner);
            Assert.Equal("6-2 7-6 1-6 6-2 4-6", match.Score);
        }

        [Fact]
        public void MalesPlayersPlayerFirstWinsOneSetPlayerSecondWinsThreeSetsAndMatchs()
        {
            var sexPlayer = SexPlayer.Female;
            var match = new Match(sexPlayer);
            var sets = new List<Set>();
            sets.Add(new Set(sexPlayer) { Score = "6-2" });
            sets.Add(new Set(sexPlayer) { Score = "6-7" });
            sets.Add(new Set(sexPlayer) { Score = "6-7" });
            sets.Add(new Set(sexPlayer) { Score = "4-6" });

            match.Start();
            match.PlayersScores(sets);

            Assert.False(match.PlayerOne.IsWinner);
            Assert.True(match.PlayerSecond.IsWinner);
            Assert.Equal("6-2 6-7 6-7 4-6", match.Score);
        }
    }
}
