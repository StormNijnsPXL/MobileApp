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
        public Rarity(int id, string name, string color, string cardArt)
        {
            Id = id;
            Name = name;
            Color = Color.Parse(color);
            CardArt = cardArt;
            Rarities[id] = this;
        }
        public static void CreateRarities()
        {
            new Rarity(0, "Common", "#B4BECD", "UI/cardWhite.png");
            new Rarity(1, "Uncommon", "#41CD7D", "UI/cardGreen.png");
            new Rarity(2, "Rare", "#4191FF", "UI/cardBlue.png");
            new Rarity(3, "Epic", "#AF5AFF", "UI/cardPurple.png");
            new Rarity(4, "Legendary", "#FFAF2D", "UI/cardYellow.png");
        }
    }
}
