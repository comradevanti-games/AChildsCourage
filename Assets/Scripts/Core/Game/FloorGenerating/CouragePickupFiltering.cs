﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AChildsCourage.Game.Floors;
using static AChildsCourage.Game.MTilePosition;
using static AChildsCourage.F;

namespace AChildsCourage.Game
{

    internal static partial class FloorGenerating
    {

        internal const int CourageOrbCount = 10;
        internal const int CourageSparkCount = 25;


        internal static IEnumerable<CouragePickup> ChooseCouragePickups(FloorBuilder floorBuilder)
        {
            var sparks = ChoosePickupsOfVariant(floorBuilder, CourageVariant.Spark, CourageSparkCount, CalculateCourageSparkWeight);
            var orbs = ChoosePickupsOfVariant(floorBuilder, CourageVariant.Orb, CourageOrbCount, CalculateCourageOrbWeight);

            return sparks.Concat(orbs);
        }


        private static IEnumerable<CouragePickup> ChoosePickupsOfVariant(FloorBuilder floorBuilder, CourageVariant variant, int count, CouragePickupWeightFunction weightFunction)
        {
            var positions = GetCouragePositionsOfVariant(floorBuilder, variant).ToImmutableHashSet();

            Func<ImmutableHashSet<TilePosition>, ImmutableHashSet<TilePosition>> addNext =
                taken =>
                    taken.Add(ChooseNextPickupPosition(positions, taken, weightFunction));

            return Take(ImmutableHashSet<TilePosition>.Empty)
                   .RepeatFor(addNext, count)
                   .Select(p => new CouragePickup(p, variant));
        }

        private static IEnumerable<TilePosition> GetCouragePositionsOfVariant(FloorBuilder floorBuilder, CourageVariant variant) =>
            floorBuilder.Rooms
                        .SelectMany(r => r.CouragePickups)
                        .Where(p => p.Variant == variant)
                        .Select(p => p.Position);


        internal static TilePosition ChooseNextPickupPosition(IEnumerable<TilePosition> positions, ImmutableHashSet<TilePosition> taken, CouragePickupWeightFunction weightFunction)
        {
            Func<TilePosition, bool> isNotTaken = p => !taken.Contains(p);
            Func<TilePosition, float> weight = p => weightFunction(p, taken);

            return Take(positions)
                   .Where(isNotTaken)
                   .OrderByDescending(weight)
                   .First();
        }

        internal static float CalculateCourageOrbWeight(TilePosition position, ImmutableHashSet<TilePosition> taken)
        {
            var distanceOrigin = GetDistanceFromOrigin(position);

            var distanceToClosest = taken.Any()
                ? taken.Select(p => GetDistanceBetween(position, p)).Min()
                : 0;

            return (float) Math.Pow(distanceOrigin + distanceToClosest, 2);
        }

        internal static float CalculateCourageSparkWeight(TilePosition position, ImmutableHashSet<TilePosition> taken)
        {
            var distanceOrigin = GetDistanceFromOrigin(position);
            var distanceToClosest = taken.Any()
                ? taken.Select(p => GetDistanceBetween(position, p)).Min()
                : 0;

            var distanceOriginWeight = Math.Pow(distanceOrigin, 2);
            var distanceToClosestWeight = distanceToClosest > 0 ? 1f / distanceToClosest : 0;

            return (float) (distanceOriginWeight + distanceToClosestWeight);
        }

    }

}