using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models.Cards
{
    internal class Rarity
    {
        public static Dictionary<int, Rarity> Rarities { get; set; } = new();
        public int Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public string CardArt { get; set; }
        public int Value { get; set; }
        public Currency Currency { get; set; }
        public bool Glow { get; set; }
        public Rarity(int id, string name, string color, string cardArt, int value, Currency currency, bool glow)
        {
            Id = id;
            Name = name;
            Color = Color.Parse(color);
            CardArt = cardArt;
            Value = value;
            Currency = currency;
            Glow = glow;
            Rarities[id] = this;
        }
        public static void CreateRarities()
        {
            new Rarity(0, "Common", "#B4BECD", "UI/cardWhite.png", 10, Currency.Currencies["Scrap"], false);
            new Rarity(1, "Uncommon", "#41CD7D", "UI/cardGreen.png", 50, Currency.Currencies["Scrap"], false);
            new Rarity(2, "Rare", "#4191FF", "UI/cardBlue.png", 200, Currency.Currencies["Scrap"], true);
            new Rarity(3, "Epic", "#AF5AFF", "UI/cardPurple.png", 15000, Currency.Currencies["Scrap"], true);
            new Rarity(4, "Legendary", "#FFAF2D", "UI/cardYellow.png", 100000, Currency.Currencies["Scrap"], true);
        }
    }
}
