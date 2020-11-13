﻿using System.Collections.Generic;

namespace AChildsCourage.Game.Floors.Generation
{

    public class RoomsInChunks : List<RoomInChunk>
    {

        #region Constructors

        public RoomsInChunks()
           : base() { }

        public RoomsInChunks(IEnumerable<RoomInChunk> roomsInChunks)
            : base()
        {
            foreach (var roomInChunk in roomsInChunks)
                Add(roomInChunk);
        }

        #endregion

    }

}