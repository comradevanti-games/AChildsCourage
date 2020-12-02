﻿using System;
using System.Collections.Generic;
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


        internal static IEnumerable<CouragePickup> ChooseCourageOrbs(IEnumerable<TilePosition> positions, int count)
        {
            Func<List<TilePosition>, List<TilePosition>> addNext = list =>
            {
                var next = ChooseNextOrbPosition(positions, list);
                list.Add(next);

                return list;
            };

            return
                Take(new List<TilePosition>())
                    .RepeatFor(addNext, count)
                    .Select(p => new CouragePickup(p, CourageVariant.Orb));
        }

        internal static TilePosition ChooseNextOrbPosition(IEnumerable<TilePosition> positions, IEnumerable<TilePosition> taken)
        {
            Func<TilePosition, bool> isNotTaken = p => !taken.Contains(p);
            Func<TilePosition, float> weight = p => CalculateCourageOrbWeight(p, taken);

            return
                Take(positions)
                    .Where(isNotTaken)
                    .OrderByDescending(weight)
                    .First();
        }

        internal static float CalculateCourageOrbWeight(TilePosition position, IEnumerable<TilePosition> taken)
        {
            var distanceOrigin = GetDistanceFromOrigin(position);

            var positions = taken as TilePosition[] ?? taken.ToArray();
            var distanceToClosest = positions.Any()
                ? positions.Select(p => GetDistanceBetween(position, p))
                           .Min()
                : 0;

            return (float) Math.Pow(distanceOrigin + distanceToClosest, 2);
        }


        internal static IEnumerable<CouragePickup> ChooseCourageSparks(IEnumerable<TilePosition> positions, int count)
        {
            Func<List<TilePosition>, List<TilePosition>> addNext = list =>
            {
                var next = ChooseNextSparkPosition(positions, list);
                list.Add(next);

                return list;
            };

            return
                Take(new List<TilePosition>())
                    .RepeatFor(addNext, count)
                    .Select(p => new CouragePickup(p, CourageVariant.Spark));
        }

        internal static TilePosition ChooseNextSparkPosition(IEnumerable<TilePosition> positions, IEnumerable<TilePosition> taken)
        {
            Func<TilePosition, bool> isNotTaken = p => !taken.Contains(p);
            Func<TilePosition, float> weight = p => CalculateCourageSparkWeight(p, taken);

            return
                Take(positions)
                    .Where(isNotTaken)
                    .OrderByDescending(weight)
                    .First();
        }

        internal static float CalculateCourageSparkWeight(TilePosition position, IEnumerable<TilePosition> taken)
        {
            var distanceOrigin = GetDistanceFromOrigin(position);
            var positions = taken as TilePosition[] ?? taken.ToArray();
            var distanceToClosest = positions.Any()
                ? positions.Select(p => GetDistanceBetween(position, p))
                           .Min()
                : 0;

            var distanceOriginWeight = Math.Pow(distanceOrigin, 2);
            var distanceToClosestWeight = distanceToClosest > 0 ? 1f / distanceToClosest : 0;

            return (float) (distanceOriginWeight + distanceToClosestWeight);
        }

    }

}