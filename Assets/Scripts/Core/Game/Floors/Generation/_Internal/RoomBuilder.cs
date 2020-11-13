﻿using System;

namespace AChildsCourage.Game.Floors.Generation
{

    [Singleton]
    internal class RoomBuilder : IRoomBuilder
    {

        #region Events

        public event EventHandler<RoomBuiltEventArgs> OnRoomBuilt;

        #endregion

        #region Fields

        private readonly ITileBuilder tileBuilder;

        #endregion

        #region Constructors

        public RoomBuilder(ITileBuilder tileBuilder)
        {
            this.tileBuilder = tileBuilder;
        }

        #endregion

        #region Methods

        public void Build(Room room, ChunkPosition chunkPosition)
        {
            var offset = chunkPosition.GetTileOffset();

            Build(room, offset);
            OnRoomBuilt?.Invoke(this, new RoomBuiltEventArgs());
        }


        private void Build(Room room, TileOffset offset)
        {
            BuildTiles(room.Tiles, offset);
        }

        private void BuildTiles(RoomTiles roomTiles, TileOffset offset)
        {
            BuildGround(roomTiles.GroundTiles, offset);
        }

        private void BuildGround(Tiles<GroundTile> groundPositions, TileOffset offset)
        {
            foreach (var groundPosition in groundPositions)
            {
                var offsetPosition = groundPosition.Position + offset;

                tileBuilder.PlaceGround(offsetPosition);
            }
        }

        #endregion

    }

}