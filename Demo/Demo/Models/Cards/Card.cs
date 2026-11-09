using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Demo.Models.Cards
{
    internal class Card
    {
        public string Type { get; set; }
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
        public int RarityId { get; set; }
        public DateTime DateUnlocked { get; set; }

        public static Dictionary<int, Card> Cards { get; private set; } = [];
        public static async Task LoadCards()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("cards.json");

            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var cards = await JsonSerializer.DeserializeAsync<List<Card>>(stream, options);

            Cards = cards?.ToDictionary(card => card.Id) ?? [];
            foreach (var card in Cards.Values)
            {
                card.Rarity = Rarity.Rarities[card.RarityId];
            }
        }
        public static Card ById(int id)
        {
            Cards.TryGetValue(id, out var card);
            return card;
        }
        public override string ToString()
        {
            return $"[{Id}] {Name} - {Rarity.Name}";
        }
    }
}
