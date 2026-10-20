using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Demo.Models.Animations
{
    internal class Tween
    {
        public TweenInfo TweenInfo { get; set; }
        public List<Func<Task<bool>>> Tweens { get; set; } = [];
        public Tween()
        {
        }
        public Tween(List<Func<Task<bool>>> tweens, TweenInfo tweenInfo)
        {
            Tweens = tweens;
            TweenInfo = tweenInfo;
        }

        public async Task Play()
        {
            var tasks = Tweens.Select(tween => tween());
            await Task.WhenAll(tasks);
        }
    }
}
