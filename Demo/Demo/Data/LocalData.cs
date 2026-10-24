using Demo.Models;
using Demo.Models.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data
{
    internal class LocalData
    {
        public static PlayerData PlayerData { get; set; }
        public static User User { get; set; }
        public static Deck Deck { get; set; }
        public static void CreateData()
        {
            User = new User(1, "storm", "Storm Nijns", DateTime.Now);

            Deck = new Deck([
                Card.ById(1),
                Card.ById(2),
                Card.ById(3),
                Card.ById(4),
                Card.ById(5),
                Card.ById(6),
                Card.ById(7),
                Card.ById(8)
            ]);

            PlayerData = new PlayerData(Deck, 1, 0, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
        }
    }
}
