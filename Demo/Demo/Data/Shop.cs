using Demo.Models.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data
{
    internal class Shop
    {
        public static List<Card> ShopItems = [];

        public static void CreateShopItems()
        {
            ShopItems.Add(Card.ById(1));
            ShopItems.Add(Card.ById(2));
            ShopItems.Add(Card.ById(3));
        }
    }
}
