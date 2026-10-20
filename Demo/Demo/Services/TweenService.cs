using Demo.Models.Animations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Services
{
    internal class TweenService
    {
        public static GridTween Create(
            Grid grid,
            TweenInfo tweenInfo,
            (double, double) position)
        {
            return new GridTween(
                grid,
                tweenInfo,
                () => grid.TranslateToAsync(
                    position.Item1,
                    position.Item2,
                    (uint)tweenInfo.Duration,
                    tweenInfo.EasingStyle
                )
            );
        }
    }
}
