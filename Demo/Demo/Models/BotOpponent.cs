using Demo.Models.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    internal class BotOpponent
    {
        public User User { get; set; }

        private static List<BotOpponent> _bots = new List<BotOpponent>();
        private static Random _random = new Random();

        public static BotOpponent GetRandomOpponent()
        {
            if (_bots.Count == 0)
                throw new InvalidOperationException("No bots have been created!");

            int index = _random.Next(_bots.Count);
            return _bots[index];
        }

        public BotOpponent()
        {
            User = new User(-(_bots.Count + 1), "bot", "Bot", DateTime.Now);
            _bots.Add(this);
        }

        public static void CreateBots()
        {
            for (int i = 0; i < 10; i++)
            {
                new BotOpponent();
            }
        }
    }
}
