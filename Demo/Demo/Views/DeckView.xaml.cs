using Demo.Components;
using Demo.Data;
using Demo.Models.Cards;
using System.Diagnostics;

namespace Demo.Pages;

public partial class DeckView : ContentView
{
	public DeckView()
	{
		InitializeComponent();

        Deck deck = LocalData.PlayerData.Deck;
        DisplayDeck(deck.Cards);

        var filteredCards = GetFilteredCardsList(deck);
        DisplayCardList(filteredCards);
    }
    private Dictionary<int, Card> GetFilteredCardsList(Deck deck)
    {
        Dictionary<int, Card> filteredCards = new Dictionary<int, Card>();
        foreach (var card in Card.Cards.Values)
        {
            if (!deck.Cards.Contains(card))
            {
                filteredCards.Add(card.Id, card);
            }
        }
        return filteredCards;
    }
    private void DisplayDeck(IEnumerable<Card> playerDeck)
    {
        MenuDeckGrid.Children.Clear();

        for (int i = 0; i < 8; i++)
        {
            var card = playerDeck.ElementAt(i);

            var component = new CardComponent
            {
                BindingContext = card
            };

            Grid.SetColumn(component, i % 4);
            Grid.SetRow(component, i / 4);

            MenuDeckGrid.Children.Add(component);
        }
    }
    private void DisplayCardList(Dictionary<int, Card> cards)
    {
        MenuCardList.ItemsSource = cards.Values.ToList();
    }
}