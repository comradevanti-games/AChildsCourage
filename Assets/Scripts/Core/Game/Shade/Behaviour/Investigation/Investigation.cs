﻿using System;
using System.Collections.Immutable;
using static AChildsCourage.Rng;

namespace AChildsCourage.Game.Shade
{

    public readonly struct Investigation
    {

        public static Investigation CompleteInvestigation => new Investigation(null, ImmutableHashSet<Poi>.Empty);


        public static Investigation StartInvestigation(Aoi aoi) =>
            aoi.Pois
               .Map(pois => new Investigation(null, pois.ToImmutableHashSet()))
               .Map(Progress);

        public static Investigation Progress(Investigation investigation)
        {
            var nextTarget = investigation.Map(IsOutOfPois)
                ? (Poi?) null
                : investigation.remainingPois.TryGetRandom(RandomRng(), () => throw new Exception("No Pois remaining!"));
            var remainingPositions = nextTarget != null
                ? investigation.remainingPois.Remove(nextTarget.Value)
                : investigation.remainingPois;

            return new Investigation(nextTarget, remainingPositions);
        }

        public static bool IsComplete(Investigation investigation) =>
            investigation.Map(IsOutOfPois) && investigation.Map(HasNoTarget);

        private static bool IsOutOfPois(Investigation investigation) =>
            investigation.remainingPois.IsEmpty;

        private static bool HasNoTarget(Investigation investigation) =>
            investigation.currentTarget == null;

        public static Poi GetCurrentTarget(Investigation investigation) =>
            investigation.currentTarget ?? throw new Exception("This investigation has no target!");


        private readonly Poi? currentTarget;
        private readonly ImmutableHashSet<Poi> remainingPois;


        private Investigation(Poi? currentTarget, ImmutableHashSet<Poi> remainingPois)
        {
            this.currentTarget = currentTarget;
            this.remainingPois = remainingPois;
        }

    }

}