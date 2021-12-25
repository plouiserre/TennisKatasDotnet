using System;
using System.Collections.Generic;

namespace TennisKatas
{
    public class Player
    {
        public SexPlayer SexPlayer { get; set; }

        public int Identity { get; set; }

        public int Score { get; set; }

        public bool IsWinner { get; set; }

        public Player(SexPlayer sexPlayer)
        {
           SexPlayer = sexPlayer;
        }
    }

    public enum SexPlayer
    {
        Male, Female
    }
}
