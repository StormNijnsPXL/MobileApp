using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models.Cards
{
    internal class Card
    {
        public static Dictionary<int, Card> Cards = [];
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int Cost { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public string? ImageUrl { get; set; }
        public string? CardConceptBy { get; set; }
        public Rarity Rarity { get; set; }
        public DateTime DateUnlocked { get; set; }
        public Card()
        {
        }
        public Card(int id, string name, string description, int cost, int health, int damage, string? imageUrl, Rarity rarity, string? cardConceptBy)
        {
            Id = id;
            Name = name;
            Description = description;
            Cost = cost;
            Health = health;
            Damage = damage;
            ImageUrl = imageUrl;
            Cards[this.Id] = this;
            Rarity = rarity;
            CardConceptBy = cardConceptBy;
        }
        public static Card ById(int id)
        {
            Cards.TryGetValue(id, out Card card);
            return card;
        }
        public static void CreateCards()
        {
            new Card(1, "Stickman", "N/A", 1, 10, 10, "Cards/stickman.png", Rarity.Rarities[0], "@Storm");
            new Card(2, "Cloud", "N/A", 2, 30, 15, "Cards/cloud.png", Rarity.Rarities[2], "@Storm");
            new Card(3, "Generator", "N/A", 3, 75, 0, "Cards/generator.png", Rarity.Rarities[2], "@storm28");
            new Card(4, "Dragon", "N/A", 4, 80, 20, "Cards/dragon.png", Rarity.Rarities[2], "@vinor_1");
            new Card(5, "Ghost", "N/A", 5, 7, 5, "Cards/ghost.png", Rarity.Rarities[3], "@Storm");
            new Card(6, "Turtle", "N/A", 6, 8, 6, "Cards/turtle.png", Rarity.Rarities[1], "@Storm");
            new Card(7, "Golem", "N/A", 7, 9, 7, "Cards/golem.png", Rarity.Rarities[4], "@vinor_1");
            new Card(8, "Knight", "N/A", 8, 10, 8, "Cards/knight.png", Rarity.Rarities[0], "@vinor_1");
            new Card(9, "Mount", "N/A", 8, 10, 8, "Cards/mount.png", Rarity.Rarities[1], "@vinor_1");
            new Card(10, "Sheep", "N/A", 8, 10, 8, "Cards/sheep.png", Rarity.Rarities[1], "@Storm");
            new Card(11, "Toad", "N/A", 8, 10, 8, "Cards/toad.png", Rarity.Rarities[2], "@vinor_1");
            new Card(12, "Grub", "N/A", 8, 10, 8, "Cards/grub.png", Rarity.Rarities[1], "@vinor_1");
            new Card(13, "SandCastle", "N/A", 8, 10, 8, "Cards/sandcastle.png", Rarity.Rarities[1], "@vinor_1");
            new Card(14, "Skeleton", "N/A", 8, 10, 8, "Cards/skeleton.png", Rarity.Rarities[3], "@vinor_1");
            new Card(15, "Rabbit", "Rimmy the rabbit", 8, 10, 8, "Cards/rabbit.png", Rarity.Rarities[2], "@YearnKing");

        }
    }
}
