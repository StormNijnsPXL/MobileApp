using Demo.Models;
using System.Diagnostics;

namespace Demo.Components;

public partial class RoadMapTileComponent : ContentView
{
	public RoadMapTileComponent()
	{
		InitializeComponent();
	}
    private static Border? oldBorder { get; set; }
    private static Border? newBorder { get; set; }
    private void SelectLevel(Level level)
    {
        oldBorder?.Shadow.Opacity = 0;
        newBorder?.Shadow.Opacity = 1;

        oldBorder = newBorder;
        newBorder = null;

        RoadmapLevel.SelectedLevel = level;

        Debug.WriteLine(level);
    }
    private void RoadMapTile_Clicked(object sender, TappedEventArgs e)
    {
        if (sender is Border border && border.BindingContext is Level level)
        {
            if (level.IsLocked)
                return;
            newBorder = border;
            SelectLevel(level);
        }
    }
}