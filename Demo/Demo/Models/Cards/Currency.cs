using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models.Cards
{
    internal class Currency
    {
        public static Dictionary<string, Currency> Currencies = new() 
        { 
            ["Scrap"] = new Currency("Scrap", "Icons/scrap.png"),
            ["Gold"] = new Currency("Gold", "Icons/gold.png")
        };
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Currency(string name, string imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
        }
    }
}
