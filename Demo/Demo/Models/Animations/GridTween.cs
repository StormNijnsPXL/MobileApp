using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models.Animations
{
    internal class GridTween: Tween
    {
        public Grid Grid { get; set; }
        public List<GridTween> Tweens { get; set; }
        public async Task Play()
        {
            await Task.WhenAll(Tweens.Select(t => t.Play()));
        }
        
        public GridTween(Grid grid, TweenInfo tweenInfo): base()
        {
            Grid = grid;
        }
    }
}
