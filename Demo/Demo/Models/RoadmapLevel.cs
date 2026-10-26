using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    class RoadmapLevel
    {
        public static Level? SelectedLevel { get; set; }
        public static Dictionary<int, RoadmapLevel> Levels { get; } = [];

        public Level? TopLevel { get; set; }
        public Level? BottomLevel { get; set; }

        public RoadmapLevel(int level, Level? bottomLevel, Level? topLevel)
        {
            BottomLevel = bottomLevel;
            TopLevel = topLevel;

            Levels[level] = this;
        }

        public static void CreateLevels()
        {
            Levels.Clear();

            new RoadmapLevel(
                3,
                null,
                null
            );

            new RoadmapLevel(
                2,
                new Level(2, "BOSS", "Icons/scrap.png"),
                null
            );

            RoadmapLevel startLevel = new RoadmapLevel(
                1,
                new Level(0, "START", "Icons/scrap.png"),
                new Level(1, "CAVE", "Icons/scrap.png")
            );
            startLevel?.BottomLevel?.IsLocked = false;

            new RoadmapLevel(
                0,
                null,
                null
            );
        }
    }
}
