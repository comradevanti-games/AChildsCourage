﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using static AChildsCourage.Game.Floors.Gen.ChunkLayout;
using static AChildsCourage.Game.Floors.MChunkPassages;
using static AChildsCourage.Game.MChunkPosition;

namespace AChildsCourage.Game.Floors.Gen
{

    public readonly struct PassagePlan
    {

        private static PassagePlan Empty => new PassagePlan(ImmutableDictionary<ChunkPosition, ChunkPassages>.Empty);

        public static (int Width, int Height) GetDimensions(PassagePlan plan) =>
            plan.passages.Keys
                .Map(MChunkPosition.GetDimensions);

        public static PassagePlan CreatePassagePlan(ChunkLayout layout)
        {
            bool HasAdjacentChunkIn(ChunkPosition position, PassageDirection direction) =>
                layout.Map(IsOccupiedIn, position.Map(GetAdjacentChunk, direction));

            ChunkPassages GetPassagesFor(ChunkPosition position) =>
                new ChunkPassages(position.Map(HasAdjacentChunkIn, PassageDirection.North),
                                  position.Map(HasAdjacentChunkIn, PassageDirection.East),
                                  position.Map(HasAdjacentChunkIn, PassageDirection.South),
                                  position.Map(HasAdjacentChunkIn, PassageDirection.West));

            PassagePlan AddPassagesFor(PassagePlan plan, ChunkPosition position) =>
                new PassagePlan(plan.passages.Add(position, GetPassagesFor(position)));

            return layout.Map(GetPositions)
                         .Aggregate(Empty, AddPassagesFor);
        }


        public static IEnumerable<(ChunkPosition Chunk, ChunkPassages Passages)> GetChunkPassages(PassagePlan plan) =>
            plan.passages.Select(kvp => (kvp.Key, kvp.Value));

        public static IEnumerable<ChunkPosition> GetChunks(PassagePlan plan) =>
            plan.passages.Keys;

        public static RoomFilter CreateFilterFor(PassagePlan plan, ChunkPosition position)
        {
            ChunkPosition GetFurthestChunkFromOrigin() =>
                plan.Map(GetChunks)
                    .FirstByDescending(GetDistanceToOrigin);

            var passages = plan.passages[position];

            var roomType = 
                position.Equals(OriginChunk) ? RoomType.Start
                : position.Equals(GetFurthestChunkFromOrigin()) ? RoomType.End
                : RoomType.Normal;

            return new RoomFilter(roomType, passages);
        }


        private readonly ImmutableDictionary<ChunkPosition, ChunkPassages> passages;


        private PassagePlan(ImmutableDictionary<ChunkPosition, ChunkPassages> passages)
            => this.passages = passages;

    }

}