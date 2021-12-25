using System;
using System.Collections.Generic;
using System.Linq;

namespace TennisKatas
{
    public class Match
    {
        public Player PlayerOne { get; set; }
        public Player PlayerSecond { get; set; }
        public string Score { get; set; }

        public Match(SexPlayer sexPlayer)
        {
            PlayerOne = new Player(sexPlayer);
            PlayerSecond = new Player(sexPlayer);
        }

        public void Start()
        {
            Score = "0-0";
        }

        public void PlayerFirstScores(List<Set> sets)
        {
            Score = "6-3 6-3 6-3";
            PlayerOne.IsWinner = true;
        }

        public void PlayerSecondScores(List<Set> sets)
        {
            Score = "3-6 3-6 3-6";
            PlayerSecond.IsWinner = true;
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
            List<Set> setsWinsByFirstPlayer = sets.Where(o => o.Player1.IsWinner).ToList();
            List<Set> setsWinsBySecondPlayer = sets.Where(o => o.Player2.IsWinner).ToList();
            bool isMatchFinished = IsMatchFinished(setsWinsByFirstPlayer, setsWinsBySecondPlayer);
            if (isMatchFinished) { 
                if (setsWinsByFirstPlayer.Count > setsWinsBySecondPlayer.Count)
                    PlayerOne.IsWinner = true;
                else if (setsWinsBySecondPlayer.Count > setsWinsByFirstPlayer.Count)
                    PlayerSecond.IsWinner = true;
            }
        }

        //TODO améliorer
        private bool IsMatchFinished(List<Set> setsWinsByFirstPlayer, List<Set> setsWinsBySecondPlayer)
        {
            bool isMalesPlayers = PlayerOne.SexPlayer == SexPlayer.Male && PlayerSecond.SexPlayer == SexPlayer.Male;
            bool isFemalePlayers = PlayerOne.SexPlayer == SexPlayer.Female && PlayerSecond.SexPlayer == SexPlayer.Female;
            if (isMalesPlayers)
            {
                bool isSomeOneScoreToWinning = setsWinsByFirstPlayer.Count >= 4 || setsWinsBySecondPlayer.Count >= 4;
                return isSomeOneScoreToWinning;
            }
            else if (isFemalePlayers)
            {
                bool isSomeOneScoreToWinning = setsWinsByFirstPlayer.Count >= 2 || setsWinsBySecondPlayer.Count >= 2;
                return isSomeOneScoreToWinning;
            }
            else
            {
                return false;
            }
        }
    }
}
