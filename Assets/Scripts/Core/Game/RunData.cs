﻿using System;
using static AChildsCourage.Game.MNightData;

namespace AChildsCourage.Game.Persistance
{

    public static class MRunData
    {

        public const int BaseCourage = 0;


        public static RunData NewRun => new RunData(0, BaseCourage);


        public static Func<RunData, Rng.CreateRng, NightData> StartNight =>
            (runData, rng) =>
                CreateNightWithRandomSeed(rng);


        public readonly struct RunData
        {

            public int CompletedNightCount { get; }

            public int TotalCollectedCourage { get; }


            public RunData(int completedNightCount, int totalCollectedCourage)
            {
                CompletedNightCount = completedNightCount;
                TotalCollectedCourage = totalCollectedCourage;
            }

        }

    }

}