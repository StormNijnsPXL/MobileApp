namespace Demo.Services
{
    internal class NavigationService
    {
        public static int CurrentViewIndex { get; set; }

        public static Grid AppView { get; set; } = null!;

        public static Dictionary<string, ContentView> Views { get; set; } = new();

        public static bool IsNavigating { get; private set; }

        public static Dictionary<int, string> ViewIndexToName = new()
        {
            { 0, "Store" },
            { 1, "Deck" },
            { 2, "Play" },
            { 3, "Quests" },
            { 4, "Leaderboard" },
        };

        private static bool _viewsAdded;

        private static void EnsureViewsAdded()
        {
            if (_viewsAdded)
                return;

            AppView.Children.Clear();

            foreach (var view in Views.Values)
            {
                view.TranslationX = 0;
                view.TranslationY = 0;
                view.IsVisible = false;

                AppView.Children.Add(view);
            }

            _viewsAdded = true;
        }

        public static Task JumpToPage(string key)
        {
            if (IsNavigating || !Views.ContainsKey(key))
                return Task.CompletedTask;

            EnsureViewsAdded();

            foreach (var view in Views.Values)
            {
                view.IsVisible = false;
                view.TranslationX = 0;
                view.TranslationY = 0;
            }

            ContentView selectedView = Views[key];
            selectedView.IsVisible = true;

            foreach (var kvp in ViewIndexToName)
            {
                if (kvp.Value == key)
                {
                    CurrentViewIndex = kvp.Key;
                    break;
                }
            }

            return Task.CompletedTask;
        }

        public static async Task SlideToPage(string key, int direction)
        {
            if (IsNavigating || !Views.ContainsKey(key))
                return;

            EnsureViewsAdded();

            ContentView nextView = Views[key];

            ContentView? currentView = Views.Values
                .FirstOrDefault(view => view.IsVisible);

            if (currentView == nextView)
                return;

            double width = AppView.Width;

            if (width <= 0)
            {
                await JumpToPage(key);
                return;
            }

            IsNavigating = true;

            try
            {
                // Place the incoming view just outside the screen.
                nextView.TranslationX = direction * width;
                nextView.TranslationY = 0;
                nextView.IsVisible = true;

                await Task.Yield();

                // Slide both views at the same time.
                Task incoming = nextView.TranslateToAsync(
                    0, 0, 280, Easing.CubicOut);

                Task outgoing = currentView != null
                    ? currentView.TranslateToAsync(
                        -direction * width, 0, 280, Easing.CubicOut)
                    : Task.CompletedTask;

                await Task.WhenAll(incoming, outgoing);

                // Hide the old page, but keep it alive.
                if (currentView != null)
                {
                    currentView.IsVisible = false;
                    currentView.TranslationX = 0;
                    currentView.TranslationY = 0;
                }

                nextView.TranslationX = 0;
                nextView.TranslationY = 0;

                foreach (var kvp in ViewIndexToName)
                {
                    if (kvp.Value == key)
                    {
                        CurrentViewIndex = kvp.Key;
                        break;
                    }
                }
            }
            finally
            {
                IsNavigating = false;
            }
        }
    }
}
