using Demo.Models.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    internal class Game
    {
        public string GameId { get; set; }
        public bool Active { get; set; }
        public int Score { get; set; }
        public int Round { get; set; }
        public int Turn { get; set; }
        public User User1 { get; set; }
        public User User2 { get; set; }
        public Card[][] PlayField { get; set; }

        public Game(User user1, User user2)
        {
            Active = true;
            GameId = $"{user1.UserId}_{user2.UserId}_{DateTime.Now.ToString("yyyy.MM.dd_H.mm.ss")}";
            user1.LastGameId = GameId;
            user2.LastGameId = GameId;
            User1 = user1;
            User2 = user2;

            Score = 0;
            PlayField = new Card[2][];
            PlayField[0] = new Card[4];
            PlayField[1] = new Card[4];
        }
    }
}
