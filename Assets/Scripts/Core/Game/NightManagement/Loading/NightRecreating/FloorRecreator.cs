﻿using AChildsCourage.Game.Floors;
using System;

namespace AChildsCourage.Game.NightManagement.Loading
{

    [Singleton]
    internal class FloorRecreator : IFloorRecreator
    {

        #region Events

        public event EventHandler<GroundPlacedEventArgs> OnGroundPlaced;
        public event EventHandler<WallPlacedEventArgs> OnWallPlaced;
        public event EventHandler<CouragePlacedEventArgs> OnCouragePlaced;

        #endregion

        #region Methods

        public void Recreate(Floor floor)
        {
            floor.GroundTilePositions.ForEach(PlaceGround);
            floor.Walls.ForEach(PlaceWall);
            floor.CourageOrbPositions.ForEach(PlaceCourageOrb);
        }

        internal void PlaceGround(TilePosition position)
        {
            OnGroundPlaced?.Invoke(this, new GroundPlacedEventArgs(position));
        }

        internal void PlaceWall(Wall wall)
        {
            OnWallPlaced?.Invoke(this, new WallPlacedEventArgs(wall));
        }

        internal void PlaceCourageOrb(TilePosition position)
        {
            OnCouragePlaced.Invoke(this, new CouragePlacedEventArgs(position, CourageVariant.Orb));
        }

        #endregion

    }

}