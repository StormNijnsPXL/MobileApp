using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models.Animations
{
    internal class GridTween : Tween
    {
        public Grid Grid { get; set; }
        public GridTween(Grid grid, TweenInfo tweenInfo, Func<Task<bool>> tween): base()
        {
            Grid = grid;
            TweenInfo = tweenInfo;
            Tweens.Add(tween);
        }
    }
}
