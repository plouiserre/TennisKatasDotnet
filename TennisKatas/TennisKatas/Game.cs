using System;
using System.Collections.Generic;
using System.Linq;

namespace TennisKatas
{
    //TODO factoriser dans une classe mère surtout la partie joueur
    //TODO revoir pour l'init des Players
    public class Game
    {

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }
                
        public string Score { get; set; }

        public Game(SexPlayer sexPlayer)
        {
            Player1 = new Player(sexPlayer)
            {
                Identity = 1,
                Score = 0
            };
            Player2 = new Player(sexPlayer)
            {
                Identity = 2,
                Score = 0
            };
        }

        public void StartGame()
        {
           Score = "0-0";
        }

        public void PlayerOneScores()
        {
            DetermineScore(Player1,1);
            Player1.IsWinner = Player1.Score == 40 ? true : false;
            GetScore();
        }

        public void PlayerSecondScores()
        {
            DetermineScore(Player2, 2) ;
            Player2.IsWinner = Player2.Score == 40 ? true : false;
            GetScore();
        }

        //TODO modifier cette méthode car elle est nulle
        private void DetermineScore(Player player, int keyPlayer)
        {
            if (player.Score == 0)
            {
                player.Score = 15;
            }
            else if (player.Score == 15)
            {
                player.Score = 30;
            }
            else if (Player1.Score == 40 && Player2.Score == 40)
            {
                player.Score = 50;
            }
            else if((Player1.Score == 50 && keyPlayer == 2) || (Player2.Score == 50 && keyPlayer == 1))
            {
                //on baisse le score de l'autre adversaire
                if(keyPlayer == 1)
                {
                    Player2.Score = 40;
                }
                else
                {
                    Player1.Score = 40;
                }
            }
            else
            {
                player.Score = 40;
            }
        }

        private void GetScore()
        {
            if (Player1.Score == 50)
            {
                Score = string.Concat("A-", Player2.Score.ToString());
            }
            else if (Player2.Score == 50)
            {
                Score = string.Concat(Player1.Score.ToString(), "-A");
            }
            else
            {
                Score = string.Concat(Player1.Score.ToString(), "-", Player2.Score.ToString());
            }
        }
    }
}
