using Demo.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models.Animations
{
    class LoadingScreen
    {
        public static Grid RightGrid { get; set; }
        public static Grid LeftGrid { get; set; }
        private static void Reset()
        {
            RightGrid.TranslationX = 600;
            RightGrid.TranslationY = -100;
            LeftGrid.TranslationX = -600;
            LeftGrid.TranslationY = 100;
        }
        public static async Task TweenIn()
        {
            TweenInfo tweenInfo = new TweenInfo(1000, Easing.Linear);
            GridTween rightTween = TweenService.Create(RightGrid, tweenInfo, (-230, 100));

            uint dur = 1000;
            Reset();
            
            //Task rightTween = RightGrid.TranslateToAsync(230, -100, dur, Easing.Linear);
            Task leftTween = LeftGrid.TranslateToAsync(-230, 100, dur, Easing.Linear);
            await Task.WhenAll(rightTween.Tween, leftTween);
        }
        public static async Task TweenOut()
        {
            uint dur = 1000;
            RightGrid.TranslationX = 230;
            RightGrid.TranslationY = -100;
            LeftGrid.TranslationX = -230;
            LeftGrid.TranslationY = 100;
            Task rightTween = RightGrid.TranslateToAsync(600, -100, dur, Easing.Linear);
            Task leftTween = LeftGrid.TranslateToAsync(-600, 100, dur, Easing.Linear);
            await Task.WhenAll(rightTween, leftTween);
        }
    }
}
