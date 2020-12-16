﻿using System.Collections.Immutable;
using static AChildsCourage.Game.MChunkPosition;

namespace AChildsCourage.Game
{

    public static partial class MFloorGenerating
    {

        public readonly struct GenerationParameters
        {

            public int RoomCount { get; }


            public GenerationParameters(int goalRoomCount) => RoomCount = goalRoomCount;

        }

        public readonly struct FloorPlan
        {

            public ImmutableArray<RoomPlan> Rooms { get; }


            public FloorPlan(ImmutableArray<RoomPlan> rooms) => Rooms = rooms;

        }

        public readonly struct RoomPlan
        {

            public int RoomId { get; }

            public RoomTransform Transform { get; }


            public RoomPlan(int roomId, RoomTransform transform)
            {
                RoomId = roomId;
                Transform = transform;
            }

        }

        public readonly struct RoomTransform
        {

            public ChunkPosition Position { get; }

            public bool IsMirrored { get; }

            public int RotationCount { get; }


            public RoomTransform(ChunkPosition position, bool isMirrored, int rotationCount)
            {
                Position = position;
                IsMirrored = isMirrored;
                RotationCount = rotationCount;
            }

        }

        public enum LayoutGenerationPhase
        {

            StartRoom,
            NormalRooms,
            EndRoom

        }

    }

}