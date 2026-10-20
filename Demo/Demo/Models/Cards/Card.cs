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
        public Card(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            Cards.Add(this.Id, this);
        }
        public static Card? ById(int id)
        {
            Cards.TryGetValue(id, out Card card);
            return card;
        }
        public static void CreateCards()
        {
            new Card(1, "Stickman", "Weak man...");
        }
    }
}
