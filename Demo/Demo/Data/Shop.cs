using Demo.Models.Cards;
using System.Diagnostics;

namespace Demo.Data
{
    internal class Shop
    {
        public static List<Card> ShopItems = [];
        private static Card GetRandomCardOfRarity(Rarity rarity, List<Card> Exclude)
        {
            List<Card> listOfCardsWithRarity = [];
            foreach (KeyValuePair<int, Card> card in Card.Cards)
            {
                if (rarity.Equals(card.Value.Rarity)) 
                    listOfCardsWithRarity.Add(card.Value);
            }
            listOfCardsWithRarity = listOfCardsWithRarity.Except(Exclude).ToList();
            return listOfCardsWithRarity[Random.Shared.Next(0, listOfCardsWithRarity.Count)];
        }
        private static List<Card> GetRandomCards()
        {
            List<Card> list = [];
            for (int i = 0; i < 3; i++)
            {
                int bonus = Random.Shared.Next(0, 3);
                list.Add(GetRandomCardOfRarity(Rarity.Rarities[i + bonus], list));
            }
            return list;
        }
        public static void CreateShopItems()
        {
            var randomCards = GetRandomCards();
            ShopItems = randomCards;
        }
    }
}
