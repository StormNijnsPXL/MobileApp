using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    class Level
    {
        public int Id { get; set; }
        public int Slot { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public Level(int slot, string title, string imageUrl)
        {
            Id = slot;
            Slot = slot;
            Title = title;
            ImageUrl = imageUrl;
        }
    }
}
