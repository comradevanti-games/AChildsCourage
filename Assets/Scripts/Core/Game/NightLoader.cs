﻿using AChildsCourage.Game.Floors;
using AChildsCourage.Game.Floors.Building;
using AChildsCourage.Game.Floors.Generation;
using AChildsCourage.Game.Persistance;

namespace AChildsCourage.Game
{

    [Singleton]
    internal class NightLoader : INightLoader
    {

        #region Fields

        private readonly IFloorGenerator floorGenerator;
        private readonly IFloorBuilder floorBuilder;

        #endregion

        #region Constructors

        public NightLoader(IFloorGenerator floorGenerator, IFloorBuilder floorBuilder)
        {
            this.floorGenerator = floorGenerator;
            this.floorBuilder = floorBuilder;
        }

        #endregion

        #region Methods

        public void Load(NightData nightData)
        {
            var floor = floorGenerator.GenerateNew(nightData.Seed);

            floorBuilder.Build(floor);
        }

        #endregion

    }

}