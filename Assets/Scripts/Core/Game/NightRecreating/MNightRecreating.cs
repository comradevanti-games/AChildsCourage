﻿using static AChildsCourage.Game.Floors.MFloor;

namespace AChildsCourage.Game
{

    internal static class MNightRecreating
    {
        
        internal delegate void RecreateNight(Floor floor);
        
        internal static RecreateNight Make(IFloorRecreator floorRecreator)
        {
            return floorRecreator.Recreate;
        }

    }

}