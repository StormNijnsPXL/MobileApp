using Demo.Models;

namespace Demo.Pages;

public partial class StoreView : ContentView
{
	public StoreView()
	{
        InitializeComponent();

        ShopCollectionView.ItemsSource = Shop.ShopItems; // vervang met MVVM observable things
    }
}