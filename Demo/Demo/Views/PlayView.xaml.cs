using Demo.Data;
using Demo.Models;
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
        Level? selectedLevel = RoadmapLevel.SelectedLevel;
        if (selectedLevel == null) 
            return;

        Game game = new Game(LocalData.User, BotOpponent.GetRandomOpponent().User);
        await NavigationService.JumpToPage("Game");
    }
    private void DisplayRoadmap(Dictionary<int, RoadmapLevel> levels)
    {
        RoadmapList.ItemsSource = levels.Values.ToList();
    }
}