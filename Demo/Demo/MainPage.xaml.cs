using Demo.Models.Animations;
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
            // repeat wait until loaded == true
            await Task.Delay(1000);
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
        private async void Menu_Button_Clicked(object sender, EventArgs e)
        {
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
