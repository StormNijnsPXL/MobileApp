using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Services
{
    internal class NavigationService
    {
        public static Grid AppView { get; set; }
        public static Dictionary<string, ContentView> Views { get; set; }
        public static async Task JumpToPage(string key)
        {
            ContentView view = Views[key];
            AppView.Children.Clear();
            AppView.Children.Add(view);
        }
    }
}
