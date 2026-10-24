using Demo.Models.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    internal class PlayerData
    {
        public Deck Deck { get; set; }
        public uint Level { get; set; }
        public uint Experience { get; set; }
        public List<int> UnlockedCards { get; set; }
        public uint Gold { get; set; }
        public uint Scrap { get; set; }
        public PlayerData()
        {
        }
        public PlayerData(Deck deck, uint level, uint experience, List<int> unlockedCards)
        {
            Deck = deck;
            Level = level;
            Experience = experience;
            UnlockedCards = unlockedCards;
        }
    }
}
