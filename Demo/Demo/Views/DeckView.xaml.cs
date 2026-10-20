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

        DisplayDeck(LocalData.Deck);
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
}