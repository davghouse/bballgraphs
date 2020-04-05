﻿using System;

namespace BBallGraphs.Scrapers.BasketballReference
{
    public class Player : IPlayer
    {
        public string FeedUrl { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public int FirstSeason { get; set; }
        public int LastSeason { get; set; }
        public string Position { get; set; }
        public double HeightInInches { get; set; }
        public double? WeightInPounds { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
            => $"{Name} ({FirstSeason} - {LastSeason})";
    }
}
