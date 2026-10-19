using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models.Animations
{
    internal class TweenInfo
    {
        public uint Duration { get; set; }
        public Easing EasingStyle { get; set; }
        public TweenInfo(uint duration, Easing easingStyle)
        {
            Duration = duration;
            EasingStyle = easingStyle;
        }
    }
}
