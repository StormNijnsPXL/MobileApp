using Demo.Models;

namespace Demo.Components;

public partial class RoadMapComponent : ContentView
{
    public RoadMapComponent()
    {
        InitializeComponent();

        BindingContextChanged += (_, _) => UpdateTiles();
    }
    private void UpdateTiles()
    {
        if (BindingContext is not RoadmapLevel item)
            return;

        TopTile.BindingContext = item.TopLevel;
        TopTile.IsVisible = item.TopLevel is not null;
        if (item.TopLevel is not null)
            Grid.SetColumn(TopTile, item.TopLevel.Slot);

        BottomTile.BindingContext = item.BottomLevel;
        BottomTile.IsVisible = item.BottomLevel is not null;
        if (item.BottomLevel is not null)
            Grid.SetColumn(BottomTile, item.BottomLevel.Slot);

    }
}