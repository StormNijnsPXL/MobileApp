namespace Demo
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //await LoadingScreenFade();
        }
        private async Task LoadingScreenFade()
        {
            LoadingScreenBackground.Opacity = 1;
            await Task.Delay(6000);
            await LoadingScreenBackground.FadeToAsync(0, 400);
            LoadingScreenBackground.IsVisible = false;
        }
        private async Task LoadingScreenAnimationIn()
        {
            uint dur = 1000;
            LoadingScreenRight.TranslationX = 0;
            LoadingScreenRight.TranslationY = 0;
            LoadingScreenLeft.TranslationX = 0;
            LoadingScreenLeft.TranslationY = 0;
            await LoadingScreenRight.TranslateToAsync(200, -100, dur, Easing.Linear);
            await LoadingScreenLeft.TranslateToAsync(-200, 100, dur, Easing.Linear);
        }
        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
