using Demo.Data;
using Demo.Models;
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

            Rarity.CreateRarities();
            Card.CreateCards();
            LocalData.CreateData();
            RoadmapLevel.CreateLevels();
            Shop.CreateShopItems();

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
            await LoadingScreen.TweenIn();

            // Loading
            await NavigationService.JumpToPage("Play");
            SelectViewButton(MenuPlayBtn);
            UsernameLabel.Text = LocalData.User.DisplayName;
            LevelLabel.Text = $"Lv.{LocalData.PlayerData.Level}";
            ExperienceProgressBar.Progress = LocalData.PlayerData.Experience / 100;
            //

            await LoadingScreen.TweenOut();
            await LoadingScreenFade();

            while (true)
            {
                await BackgroundImage.TranslateToAsync(-24, -8, 7000, Easing.SinInOut);
                await BackgroundImage.TranslateToAsync(24, 8, 9000, Easing.SinInOut);
                await BackgroundImage.TranslateToAsync(16, -10, 8000, Easing.SinInOut);
                await BackgroundImage.TranslateToAsync(-24, -8, 7000, Easing.SinInOut);
            }
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
        private async void AppViewSwiped(object sender, SwipedEventArgs e)
        {
            if (NavigationService.IsNavigating)
                return;

            int count = NavigationService.ViewIndexToName.Count;

            int direction = e.Direction switch
            {
                SwipeDirection.Left => 1,
                SwipeDirection.Right => -1,
                _ => 0
            };

            if (direction == 0)
                return;

            int nextIndex = (
                NavigationService.CurrentViewIndex + direction + count
            ) % count;

            string viewName = NavigationService.ViewIndexToName[nextIndex];

            await NavigationService.SlideToPage(viewName, direction);

            SelectViewButton(viewName switch
            {
                "Store" => MenuStoreBtn,
                "Deck" => MenuDeckBtn,
                "Play" => MenuPlayBtn,
                "Quests" => MenuQuestsBtn,
                "Leaderboard" => MenuLeadboardBtn,
                _ => MenuPlayBtn
            });
        }


    }
}
