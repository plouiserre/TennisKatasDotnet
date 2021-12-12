using System;
using System.Collections.Generic;

namespace TennisKatas
{
    public class KeyGame
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public string Score { get; set; }

        public KeyGame()
        {
            Player1 = new Player()
            {
                Identity = 1,
                Score = 0
            };
            Player2 = new Player()
            {
                Identity = 2,
                Score = 0
            };
        }

        public void StartKeyGame()
        {
            Score = "0-0";
        }
    }
}
