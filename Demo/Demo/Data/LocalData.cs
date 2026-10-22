using Demo.Models.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data
{
    internal class LocalData
    {
        public static Deck Deck { get; set; }
        public static void CreateData()
        {
            Deck.Cards[0] = Card.ById(1);
            Deck.Cards[1] = Card.ById(2);
            Deck.Cards[2] = Card.ById(3);
            Deck.Cards[3] = Card.ById(4);
            Deck.Cards[4] = Card.ById(5);
            Deck.Cards[5] = Card.ById(6);
            Deck.Cards[6] = Card.ById(7);
            Deck.Cards[7] = Card.ById(8);
        }
    }
}
