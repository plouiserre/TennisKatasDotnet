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

        public Match()
        {
            PlayerOne = new Player();
            PlayerSecond = new Player();
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
            List<Set> setsWinsByFirstPlayer = sets.Where(o => o.Player1.IsWinner).ToList();
            List<Set> setsWinsBySecondPlayer = sets.Where(o => o.Player2.IsWinner).ToList();
            if (setsWinsByFirstPlayer.Count > setsWinsBySecondPlayer.Count)
                PlayerOne.IsWinner = true;
            else if (setsWinsBySecondPlayer.Count > setsWinsByFirstPlayer.Count)
                PlayerSecond.IsWinner = true;
        }
    }
}
