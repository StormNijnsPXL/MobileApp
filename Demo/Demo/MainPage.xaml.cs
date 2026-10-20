using Demo.Data;
using Demo.Models.Animations;
using Demo.Models.Cards;
using Demo.Pages;
using Demo.Services;

namespace Demo
{
    public partial class MainPage : ContentPage
    {
        bool loaded = false;
        public MainPage()
        {
            InitializeComponent();

            LoadingScreen.RightGrid = LoadingScreenRight;
            LoadingScreen.LeftGrid = LoadingScreenLeft;
            LoadingScreen.CreateTweens();
            LoadingScreen.Reset();

            Card.CreateCards();
            LocalData.CreateData();

            NavigationService.AppView = AppGrid;
            NavigationService.Views = new Dictionary<string, ContentView>()
            {
                { "Deck", new DeckView() },
                { "Store", new StoreView() },
                { "Leaderboard", new LeaderboardView() },
                { "Quests", new QuestsView() },
                { "Play", new PlayView() },
                { "Game", new GameView() },
            };

            loaded = true;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            do 
            {
                await Task.Delay(100);
            } while (!loaded);

            await NavigationService.JumpToPage("Play");
            SelectViewButton(MenuPlayBtn);

            await LoadingScreen.TweenIn();
            await Task.Delay(2000);
            await LoadingScreen.TweenOut();
            await LoadingScreenFade();
        }
        private async Task LoadingScreenFade()
        {
            LoadingScreenBackground.Opacity = 1;
            await LoadingScreenBackground.FadeToAsync(0, 400);
            LoadingScreenBackground.IsVisible = false;
        }
        private static Border? currentViewButton;
        private void SelectViewButton(Border btn)
        {
            if (currentViewButton == btn)
                return;

            currentViewButton?.Background = Brush.Transparent;
            currentViewButton?.ScaleToAsync(1, 200, Easing.Linear);
            btn.Background = Brush.CornflowerBlue;
            btn.ScaleToAsync(1.1, 200, Easing.Linear);
            currentViewButton = btn;
        }
        private async void Menu_Button_Clicked(object sender, EventArgs e)
        {
            SelectViewButton((Border)sender);
            if (sender == MenuDeckBtn)
            {
                await NavigationService.JumpToPage("Deck");
            } 
            else if (sender == MenuLeadboardBtn)
            {
                await NavigationService.JumpToPage("Leaderboard");
            }
            else if (sender == MenuPlayBtn)
            {
                await NavigationService.JumpToPage("Play");
            }
            else if (sender == MenuStoreBtn)
            {
                await NavigationService.JumpToPage("Store");
            }
            else if (sender == MenuQuestsBtn)
            {
                await NavigationService.JumpToPage("Quests");
            }

        }
    }
}
