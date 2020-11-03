﻿namespace AChildsCourage.Game.Floors.Generation
{
    public interface IChunkGrid
    {

        #region Properties

        int RoomCount { get; }

        #endregion

        #region Methods

        FloorPlan BuildPlan();

        ChunkPosition FindNextBuildChunk(IRNG rng);

        ChunkPassages GetPassagesTo(ChunkPosition position);

        ChunkPosition FindDeadEndChunks();

        bool IsEmpty(ChunkPosition position);

        void Place(RoomInfo room, ChunkPosition position);

        #endregion

    }
}