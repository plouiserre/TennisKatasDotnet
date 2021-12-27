using System;
using System.Collections.Generic;
using System.Linq;

namespace TennisKatas
{
    public class Match
    {
        private List<Set> _setsWinsByFirstPlayer { get; set; }
        private List<Set> _setsWinsBySecondPlayer { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerSecond { get; set; }
        public string Score { get; set; }

        public Match(Player playerOne, Player playerSecond)
        {
            PlayerOne = playerOne;
            PlayerSecond = playerSecond;
        }

        public void Start()
        {
            Score = "0-0";
        }

        public void PlayersScores(List<Set> sets)
        {
            Score = "";
            foreach(var set in sets)
            {
                if (!string.IsNullOrEmpty(Score))
                    Score += " ";
                Score += set.Score;
                set.GetsInfosFromScore();
            }
            DetermineWinner(sets);
        }

        private void DetermineWinner(List<Set> sets)
        {
            _setsWinsByFirstPlayer = sets.Where(o => o.Player1.IsWinner).ToList();
            _setsWinsBySecondPlayer = sets.Where(o => o.Player2.IsWinner).ToList();
            bool isMatchFinished = IsMatchFinished();
            if (isMatchFinished) { 
                if (_setsWinsByFirstPlayer.Count > _setsWinsBySecondPlayer.Count)
                    PlayerOne.IsWinner = true;
                else if (_setsWinsBySecondPlayer.Count > _setsWinsByFirstPlayer.Count)
                    PlayerSecond.IsWinner = true;
            }
        }

        private bool IsMatchFinished()
        {
            bool isMalesPlayers = PlayerOne.SexPlayer == SexPlayer.Male && PlayerSecond.SexPlayer == SexPlayer.Male;
            bool isFemalePlayers = PlayerOne.SexPlayer == SexPlayer.Female && PlayerSecond.SexPlayer == SexPlayer.Female;
            if (!isMalesPlayers && !isFemalePlayers)
                return false;

            int minToSet = isMalesPlayers ? 3 : 2;

            bool isSomeOneScoreToWinning = IsSomeOneWinning(minToSet);
            return isSomeOneScoreToWinning;

        }

        private bool IsSomeOneWinning(int minSet)
        {
            bool isSomeOneScoreToWinning = _setsWinsByFirstPlayer.Count >= minSet || _setsWinsBySecondPlayer.Count >= minSet;
            return isSomeOneScoreToWinning;
        }
    }
}
