using Demo.Data;
using System.Diagnostics;

namespace Demo.Pages;

public partial class DeckView : ContentView
{
	public DeckView()
	{
		InitializeComponent();

        MenuDeckCollection.ItemsSource = LocalData.Deck;
    }
}