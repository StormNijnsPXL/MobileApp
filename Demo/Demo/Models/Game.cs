using Demo.Models.Cards;

namespace Demo.Models
{
    internal class Game
    {
        public static List<Game> Games { get; set; } = [];
        public string GameId { get; set; }
        public bool Active { get; set; }
        public int Score { get; set; }
        public int Round { get; set; }
        public int Turn { get; set; }
        public User User1 { get; set; }
        public User User2 { get; set; }
        public Card[][] PlayField { get; set; }
        public Card[] Hand1 { get; set; }
        public Card[] Hand2 { get; set; }
        public Card[] Pool1 { get; set; }
        public Card[] Pool2 { get; set; }

        public Game(User user1, User user2)
        {
            Active = true;
            GameId = $"{user1.UserId}_{user2.UserId}_{DateTime.Now.ToString("yyyy.MM.dd_H.mm.ss")}";
            user1.LastGameId = GameId;
            user2.LastGameId = GameId;
            User1 = user1;
            User2 = user2;

            Score = 0;
            PlayField = new Card[2][];
            PlayField[0] = new Card[4];
            PlayField[1] = new Card[4];

            Hand1 = new Card[4];
            Hand2 = new Card[4];

            Pool1 = User1.PlayerData.Deck.Cards;
            Pool2 = User1.PlayerData.Deck.Cards;

            Games.Add(this);
        }
        public static Game? GetGameById(string id)
        {
            return Games.Where(x => x.GameId.Equals(id)).FirstOrDefault();
        }
        public void Setup()
        {
            foreach (Card card in User1.PlayerData.Deck.Cards)
            {
                for (int i = 0; i < 4; i++)
                {
                    Hand1[i] = Pool1[i];
                    Hand2[i] = Pool2[i];
                }
            }
        }
    }
}
