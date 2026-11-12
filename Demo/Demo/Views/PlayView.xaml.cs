using Demo.Data;
using Demo.Models;
using Demo.Services;
using System.Diagnostics;

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

        User user = LocalData.User;

        if (!string.IsNullOrWhiteSpace(user.LastGameId))
        {
            Game? foundGame = Game.GetGameById(user.LastGameId);
            if (foundGame != null && foundGame.Active)
            {
                await NavigationService.JumpToPage("Game");
                return;
            }
        }
        
        Game game = new Game(user, BotOpponent.GetRandomOpponent().User);
        await NavigationService.JumpToPage("Game");
    }
    private void DisplayRoadmap(Dictionary<int, RoadmapLevel> levels)
    {
        RoadmapList.ItemsSource = levels.Values.ToList();
    }
}