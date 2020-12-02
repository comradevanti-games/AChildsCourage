﻿namespace AChildsCourage.Game
{

    internal static class NightRecreating
    {

        internal static RecreateNight Make(IFloorRecreator floorRecreator)
        {
            return floor => { floorRecreator.Recreate(floor); };
        }

    }

}