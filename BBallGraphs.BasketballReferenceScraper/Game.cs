﻿using BBallGraphs.BasketballReferenceScraper.Helpers;
using System;

namespace BBallGraphs.BasketballReferenceScraper
{
    public class Game : IGame
    {
        public string ID { get; set; }
        public string PlayerID { get; set; }
        public string PlayerName { get; set; }
        public int Season { get; set; }
        public DateTime Date { get; set; }
        public string Team { get; set; }
        public string OpponentTeam { get; set; }
        public bool IsHomeGame { get; set; }
        public bool IsPlayoffGame { get; set; }
        public string BoxScoreUrl { get; set; }
        public int AgeInDays { get; set; }
        public bool Won { get; set; }
        public bool? Started { get; set; }
        public int? SecondsPlayed { get; set; }
        public int? FieldGoalsMade { get; set; }
        public int? FieldGoalsAttempted { get; set; }
        public int? ThreePointersMade { get; set; }
        public int? ThreePointersAttempted { get; set; }
        public int? FreeThrowsMade { get; set; }
        public int? FreeThrowsAttempted { get; set; }
        public int? OffensiveRebounds { get; set; }
        public int? DefensiveRebounds { get; set; }
        public int? TotalRebounds { get; set; }
        public int? Assists { get; set; }
        public int? Steals { get; set; }
        public int? Blocks { get; set; }
        public int? Turnovers { get; set; }
        public int? PersonalFouls { get; set; }
        public int Points { get; set; }
        public double? GameScore { get; set; }
        public int? PlusMinus { get; set; }

        public override string ToString()
            => $"On {Date:d}, {PlayerName} had {Points}/{TotalRebounds}/{Assists}";

        public static Game MergeSplitGameData(Game firstGameData, Game secondGameData)
        {
            if (firstGameData.PlayerID != secondGameData.PlayerID
                || firstGameData.Season != secondGameData.Season
                || firstGameData.Date != secondGameData.Date
                || firstGameData.Team == secondGameData.Team
                || firstGameData.BoxScoreUrl != secondGameData.BoxScoreUrl)
                throw new InvalidOperationException("Game datas aren't split, which is when a player plays for both teams in the same game.");

            return new Game
            {
                ID = firstGameData.ID,
                PlayerID = firstGameData.PlayerID,
                PlayerName = firstGameData.PlayerName,
                Season = firstGameData.Season,
                Date = firstGameData.Date,
                Team = secondGameData.Team,
                OpponentTeam = secondGameData.OpponentTeam,
                IsHomeGame = secondGameData.IsHomeGame,
                IsPlayoffGame = firstGameData.IsPlayoffGame,
                BoxScoreUrl = firstGameData.BoxScoreUrl,
                AgeInDays = firstGameData.AgeInDays,
                Won = secondGameData.Won,
                Started = firstGameData.Started,
                SecondsPlayed = new[] { firstGameData.SecondsPlayed, secondGameData.SecondsPlayed }.NullableSum(),
                FieldGoalsMade = new[] { firstGameData.FieldGoalsMade, secondGameData.FieldGoalsMade }.NullableSum(),
                FieldGoalsAttempted = new[] { firstGameData.FieldGoalsAttempted, secondGameData.FieldGoalsAttempted }.NullableSum(),
                ThreePointersMade = new[] { firstGameData.ThreePointersMade, secondGameData.ThreePointersMade }.NullableSum(),
                ThreePointersAttempted = new[] { firstGameData.ThreePointersAttempted, secondGameData.ThreePointersAttempted }.NullableSum(),
                FreeThrowsMade = new[] { firstGameData.FreeThrowsMade, secondGameData.FreeThrowsMade }.NullableSum(),
                FreeThrowsAttempted = new[] { firstGameData.FreeThrowsAttempted, secondGameData.FreeThrowsAttempted }.NullableSum(),
                OffensiveRebounds = new[] { firstGameData.OffensiveRebounds, secondGameData.OffensiveRebounds }.NullableSum(),
                DefensiveRebounds = new[] { firstGameData.DefensiveRebounds, secondGameData.DefensiveRebounds }.NullableSum(),
                TotalRebounds = new[] { firstGameData.TotalRebounds, secondGameData.TotalRebounds }.NullableSum(),
                Assists = new[] { firstGameData.Assists, secondGameData.Assists }.NullableSum(),
                Steals = new[] { firstGameData.Steals, secondGameData.Steals }.NullableSum(),
                Blocks = new[] { firstGameData.Blocks, secondGameData.Blocks }.NullableSum(),
                Turnovers = new[] { firstGameData.Turnovers, secondGameData.Turnovers }.NullableSum(),
                PersonalFouls = new[] { firstGameData.PersonalFouls, secondGameData.PersonalFouls }.NullableSum(),
                Points = firstGameData.Points + secondGameData.Points,
                GameScore = new[] { firstGameData.GameScore, secondGameData.GameScore }.NullableSum(),
                PlusMinus = new[] { firstGameData.PlusMinus, secondGameData.PlusMinus }.NullableSum()
            };
        }
    }
}
