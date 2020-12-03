﻿using static AChildsCourage.Game.MTilePosition;

namespace AChildsCourage.Game.Floors.RoomPersistance
{

    public readonly struct AoiMarkerData
    {

        public TilePosition Position { get; }

        public int Index { get; }


        public AoiMarkerData(TilePosition position, int index)
        {
            Position = position;
            Index = index;
        }

    }

}