using Demo.Models;
using Demo.Models.Cards;
using Demo.Services;

namespace Demo.Pages;

public partial class PlayView : ContentView
{
	public PlayView()
	{
		InitializeComponent();
        DisplayRoadmap(RoadmapLevel.Levels);
	}

    private async void Play_Clicked(object sender, EventArgs e)
    {
		await NavigationService.JumpToPage("Game");
    }
    private void DisplayRoadmap(Dictionary<int, RoadmapLevel> levels)
    {
        RoadmapList.ItemsSource = levels.Values.ToList();
    }
}