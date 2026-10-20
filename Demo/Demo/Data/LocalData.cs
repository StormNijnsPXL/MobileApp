using Demo.Models.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data
{
    internal class LocalData
    {
        public static Card[] Deck { get; set; }
        public static void CreateData()
        {
            Deck = new Card[8];
            Deck[0] = Card.ById(1);
            Deck[1] = Card.ById(1);
            Deck[2] = Card.ById(1);
            Deck[3] = Card.ById(1);
            Deck[4] = Card.ById(1);
            Deck[5] = Card.ById(1);
            Deck[6] = Card.ById(1);
            Deck[7] = Card.ById(1);
        }
    }
}
