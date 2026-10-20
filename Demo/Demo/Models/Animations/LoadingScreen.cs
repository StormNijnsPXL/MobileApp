using Demo.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Demo.Models.Animations
{
    class LoadingScreen
    {
        private readonly static TweenInfo _tweenInfo = new(1000, Easing.Linear);
        private static Tween _tweenIn;
        private static Tween _tweenOut;
        public static Grid RightGrid { get; set; }
        public static Grid LeftGrid { get; set; }
        public static void Reset()
        {
            RightGrid.TranslationX = 600;
            LeftGrid.TranslationX = -600;
        }
        public static async Task TweenIn()
        {
            await _tweenIn.Play();
        }
        public static async Task TweenOut()
        {
            RightGrid.TranslationX = 230;
            LeftGrid.TranslationX = -230;
            await _tweenOut.Play();
        }
        public static void CreateTweens()
        {
            {
                GridTween rightTween = TweenService.Create(RightGrid, _tweenInfo, (230, -100));
                GridTween leftTween = TweenService.Create(LeftGrid, _tweenInfo, (-230, 100));
                _tweenIn = new([.. rightTween.Tweens, .. leftTween.Tweens], _tweenInfo);
            }
            {
                GridTween rightTween = TweenService.Create(RightGrid, _tweenInfo, (600, -100));
                GridTween leftTween = TweenService.Create(LeftGrid, _tweenInfo, (-600, 100));
                _tweenOut = new([.. rightTween.Tweens, .. leftTween.Tweens], _tweenInfo);
            }
        }
    }
}
