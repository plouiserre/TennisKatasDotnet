using System;
using Xunit;
using TennisKatas;
using System.Collections.Generic;

namespace TennisKatasTest
{
    public class MatchTest
    {
        private Match _match { get; set; }
        private Player _playerOne { get; set; }
        private Player _playerSecond { get; set; }

        [Fact]
        public void MatchStart()
        {
            InitMatchAndPlayers(SexPlayer.Female);

            _match.Start();

            Assert.False(_match.PlayerOne.IsWinner);
            Assert.False(_match.PlayerSecond.IsWinner);
            Assert.Equal("0-0", _match.Score);
        }

        [Fact]
        public void PlayerOneWinsThreeSetsAndMatch()
        {
            SexPlayer sexPlayer = SexPlayer.Female;
            InitMatchAndPlayers(sexPlayer);
            var sets = new List<Set>();
            sets.Add(new Set() { Score = "6-3" });
            sets.Add(new Set() { Score = "6-3" });

            _match.Start();
            _match.PlayersScores(sets);

            AssertTest(_match, true, false, "6-3 6-3");
        }

        [Fact]
        public void PlayerSecondWinsTwoSetsAndMatch()
        {
            SexPlayer sexPlayer = SexPlayer.Female;
            InitMatchAndPlayers(sexPlayer);
            var sets = new List<Set>();
            sets.Add(new Set() { Score = "3-6" });
            sets.Add(new Set() { Score = "3-6" });

            _match.Start();
            _match.PlayersScores(sets);

            AssertTest(_match, false, true, "3-6 3-6");
        }

        [Fact]
        public void PlayerFirstWinsOneSetPlayerSecondWinsTwoSetsAndMatch()
        {
            SexPlayer sexPlayer = SexPlayer.Female;
            InitMatchAndPlayers(sexPlayer);
            var sets = new List<Set>();
            sets.Add(new Set() { Score = "6-2" });
            sets.Add(new Set() { Score = "3-6" });
            sets.Add(new Set() { Score = "1-6" });

            _match.Start();
            _match.PlayersScores(sets);

            AssertTest(_match, false, true, "6-2 3-6 1-6");
        }

        [Fact]
        public void PlayerFirstWinsTwoSetsAndMatchsPlayerSecondWinsOneSet()
        {
            SexPlayer sexPlayer = SexPlayer.Female;
            InitMatchAndPlayers(sexPlayer);
            var sets = new List<Set>();
            sets.Add(new Set() { Score = "6-2" });
            sets.Add(new Set() { Score = "7-6" });
            sets.Add(new Set() { Score = "1-6" });

            _match.Start();
            _match.PlayersScores(sets);

            AssertTest(_match, true, false, "6-2 7-6 1-6");
        }

        [Fact]
        public void MalesPlayerFirstWinsOneSetPlayerSecondWinsTwoSetsNoWinner()
        {
            SexPlayer sexPlayer = SexPlayer.Male;
            InitMatchAndPlayers(sexPlayer);
            _match.PlayerOne.SexPlayer = sexPlayer;
            _match.PlayerSecond.SexPlayer = sexPlayer;
            var sets = new List<Set>();
            sets.Add(new Set() { Score = "6-2" });
            sets.Add(new Set() { Score = "3-6" });
            sets.Add(new Set() { Score = "1-6" });

            _match.Start();
            _match.PlayersScores(sets);

            AssertTest(_match, false, false, "6-2 3-6 1-6");
        }

        [Fact]
        public void FemalesPlayersFirstWinsTwoSetsAndMatchsPlayerSecondWinsOneSet()
        {
            SexPlayer sexPlayer = SexPlayer.Female;
            InitMatchAndPlayers(sexPlayer);
            var sets = new List<Set>();
            sets.Add(new Set() { Score = "6-2" });
            sets.Add(new Set() { Score = "7-6" });
            sets.Add(new Set() { Score = "1-6" });

            _match.Start();
            _match.PlayersScores(sets);

            AssertTest(_match, true, false, "6-2 7-6 1-6");
        }

        [Fact]
        public void FemalesPlayersPlayerFirstWinsOneSetPlayerSecondWinsTwoSetsAndMatchs()
        {
            SexPlayer sexPlayer = SexPlayer.Female;
            InitMatchAndPlayers(sexPlayer);
            var sets = new List<Set>();
            sets.Add(new Set() { Score = "6-2" });
            sets.Add(new Set() { Score = "6-7" });
            sets.Add(new Set() { Score = "6-7" });

            _match.Start();
            _match.PlayersScores(sets);
            
            AssertTest(_match, false, true, "6-2 6-7 6-7");
        }

        [Fact]
        public void MalesPlayersPlayerFirstWinsThreeSetsAndMatchsPlayerSecondWinsTwoSet()
        {
            SexPlayer sexPlayer = SexPlayer.Male;
            InitMatchAndPlayers(sexPlayer);
            var sets = new List<Set>();
            sets.Add(new Set() { Score = "6-2" });
            sets.Add(new Set() { Score = "7-6" });
            sets.Add(new Set() { Score = "1-6" });
            sets.Add(new Set() { Score = "6-2" });
            sets.Add(new Set() { Score = "4-6" });

            _match.Start();
            _match.PlayersScores(sets);

            AssertTest(_match, true, false, "6-2 7-6 1-6 6-2 4-6");
        }

        [Fact]
        public void MalesPlayersFirstWinsOneSetPlayerSecondWinsThreeSetsAndMatchs()
        {
            SexPlayer sexPlayer = SexPlayer.Male;
            InitMatchAndPlayers(sexPlayer);
            var sets = new List<Set>();
            sets.Add(new Set() { Score = "6-2" });
            sets.Add(new Set() { Score = "6-7" });
            sets.Add(new Set() { Score = "6-7" });
            sets.Add(new Set() { Score = "4-6" });

            _match.Start();
            _match.PlayersScores(sets);

            AssertTest(_match, false, true, "6-2 6-7 6-7 4-6");
        }

        private void AssertTest(Match match, bool isPlayerOneWinner, bool isPlayerSecondWinner, string finalScore)
        {
            if (isPlayerOneWinner)
                Assert.True(match.PlayerOne.IsWinner);
            else
                Assert.False(match.PlayerOne.IsWinner);

            if (isPlayerSecondWinner)
                Assert.True(match.PlayerSecond.IsWinner);
            else
                Assert.False(match.PlayerSecond.IsWinner);
            Assert.Equal(finalScore, match.Score);
        }

        private void InitMatchAndPlayers(SexPlayer sexPlayer)
        {
            _playerOne = new Player(sexPlayer);
            _playerSecond = new Player(sexPlayer);
            _match = new Match(_playerOne, _playerSecond);
        }
    }
}
