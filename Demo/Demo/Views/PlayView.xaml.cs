using Demo.Services;

namespace Demo.Pages;

public partial class PlayView : ContentView
{
	public PlayView()
	{
		InitializeComponent();
	}

    private async void Play_Clicked(object sender, EventArgs e)
    {
		await NavigationService.JumpToPage("Game");
    }
}