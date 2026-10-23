namespace Demo.Pages;

public partial class StoreView : ContentView
{
	public StoreView()
	{
		InitializeComponent();

        ShopCollectionView.ItemsSource = Data.Shop.ShopItems;
    }
}