using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models.Cards
{
    internal class Deck
    {
        public Card[] Cards { get; set; } = new Card[8];
        public Deck()
        {
        }
        public Deck(Card[] cards)
        {
            Cards = cards;
        }
    }
}
