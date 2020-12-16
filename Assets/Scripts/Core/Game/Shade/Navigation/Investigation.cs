﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using static AChildsCourage.Game.MEntityPosition;
using static AChildsCourage.MRng;
using static AChildsCourage.Game.MTilePosition;

namespace AChildsCourage.Game.Shade.Navigation
{

    public static class MInvestigation
    {

        #region Functions

        public static StartInvestigation StartNew =>
            (floorState, monsterState, rng) =>
                new Investigation(
                                  ChooseAoi(floorState, monsterState, rng),
                                  ImmutableHashSet<TilePosition>.Empty);


        public static InvestigationIsComplete IsComplete =>
            investigation =>
                ExplorationRatio(investigation) >= CompletionExplorationRation;

        private static Func<Investigation, float> ExplorationRatio =>
            investigation =>
                InvestigatedPoiCount(investigation) / (float) PoiToInvestigateCount(investigation);

        private static Func<Investigation, int> InvestigatedPoiCount =>
            investigation =>
                investigation.InvestigatedPositions.Count;

        private static Func<Investigation, int> PoiToInvestigateCount =>
            investigation =>
                investigation.Aoi.Pois.Length;


        public static ProgressInvestigation Progress =>
            (investigation, positions) =>
                new Investigation(
                                  investigation.Aoi,
                                  investigation.InvestigatedPositions.Union(
                                                                            positions.Where(p => IsPartOfInvestigation(investigation, p))));

        private static Func<Investigation, TilePosition, bool> IsPartOfInvestigation =>
            (investigation, position) =>
                investigation.Aoi.Pois.Any(poi => poi.Position.Equals(position));


        public static ChooseNextTarget NextTarget =>
            (investigation, monsterPosition) =>
                UninvestigatedPois(investigation)
                    .OrderBy(poi => GetDistanceBetween(poi.Position, GetEntityTile(monsterPosition)))
                    .First().Position;

        private static Func<Investigation, IEnumerable<Poi>> UninvestigatedPois =>
            investigation =>
                investigation.Aoi.Pois
                             .Where(poi => !investigation.InvestigatedPositions.Contains(poi.Position));


        public static CompleteInvestigation Complete =>
            investigation =>
                new CompletedInvestigation(investigation.Aoi.Index, DateTime.Now);


        private static ChooseInvestigationAoi ChooseAoi =>
            (floorState, monsterState, rng) =>
                floorState.AOIs.GetWeightedRandom(aoi => CalcTotalWeight(aoi, monsterState), rng);


        // [0 .. 15]
        internal static CalculateAoiWeight CalcTotalWeight =>
            (aoi, monsterState) =>
                new[] {CalcDistanceWeight, CalcTimeWeight}.Sum(x => x(aoi, monsterState));

        // [0 .. 5]
        private static CalculateAoiWeight CalcDistanceWeight =>
            (aoi, monsterState) =>
                DistanceBetweenAoiAndMonster(aoi, monsterState)
                    .Clamp(MinDistance, MaxDistance)
                    .RemapSquared(MaxDistance, MinDistance, 0, 10);

        private static Func<Aoi, ShadeState, float> DistanceBetweenAoiAndMonster =>
            (aoi, monsterState) =>
                GetDistanceBetween(aoi.Center, GetEntityTile(monsterState.Position));

        // [0 .. 10]
        private static CalculateAoiWeight CalcTimeWeight =>
            (aoi, monsterState) =>
                SecondsSinceLastVisit(aoi, monsterState)
                    .IfNull(MaxTime)
                    .Clamp(MinTime, MaxTime)
                    .Remap(MinTime, MaxTime, 0, 10);

        private static Func<Aoi, ShadeState, float?> SecondsSinceLastVisit =>
            (aoi, monsterState) =>
                monsterState.InvestigationHistory.FindLastIn(aoi.Index)
                            .Bind(i => monsterState.CurrentTime - i.CompletionTime)
                            .Bind(time => (float) time.TotalSeconds);

        #endregion

        #region Values

        private const float MinDistance = 30;
        private const float MaxDistance = 60;
        private const float MinTime = 1;
        private const float MaxTime = 300;
        private const float CompletionExplorationRation = 0.75f;

        #endregion

        #region Types

        public delegate Investigation StartInvestigation(FloorState floorState, ShadeState shadeState, CreateRng rng);

        public delegate Investigation ProgressInvestigation(Investigation investigation, IEnumerable<TilePosition> investigatedPositions);

        public delegate bool InvestigationIsComplete(Investigation investigation);

        public delegate CompletedInvestigation CompleteInvestigation(Investigation investigation);

        public delegate TilePosition ChooseNextTarget(Investigation investigation, EntityPosition monsterPosition);

        private delegate Aoi ChooseInvestigationAoi(FloorState floorState, ShadeState shadeState, CreateRng rng);

        internal delegate float CalculateAoiWeight(Aoi aoi, ShadeState shadeState);


        public readonly struct Investigation
        {

            internal Aoi Aoi { get; }

            internal ImmutableHashSet<TilePosition> InvestigatedPositions { get; }


            internal Investigation(Aoi aoi, ImmutableHashSet<TilePosition> investigatedPositions)
            {
                Aoi = aoi;
                InvestigatedPositions = investigatedPositions;
            }

        }

        #endregion

    }

}