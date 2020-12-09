﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AChildsCourage.Game.Floors;
using AChildsCourage.Game.Floors.RoomPersistence;
using static AChildsCourage.Game.MChunkPosition;
using static AChildsCourage.Game.MTilePosition;
using static AChildsCourage.Game.MFloorGenerating.MTileTransforming;

namespace AChildsCourage.Game
{

    public static partial class MFloorGenerating
    {

        public static class MRoomTransforming
        {

            public static IEnumerable<TransformedRoomData> TransformRooms(FloorPlan floorPlan, IEnumerable<RoomData> rooms)
            {
                var roomsArray = rooms.ToArray();

                foreach (var roomPlan in floorPlan.Rooms)
                {
                    var roomData = roomsArray.First(r => r.Id == roomPlan.RoomId);
                    var roomContent = roomData.Content;
                    var transformed = TransformContent(roomContent, roomPlan.Transform, roomData.Type);

                    yield return transformed;
                }
            }

            private static TransformedRoomData TransformContent(RoomContentData content, RoomTransform roomTransform, RoomType roomType)
            {
                var transformer = CreateTransformerFor(roomTransform);

                return new TransformedRoomData(
                    content.GroundData.Select(t => TransformGroundTile(t, transformer)).ToImmutableHashSet(),
                    content.StaticObjects.Select(o => TransformStaticObject(o, transformer)).ToImmutableHashSet(),
                    content.CourageData.Select(c => TransformCouragePickup(c, transformer)).ToImmutableHashSet(),
                    roomType,
                    roomTransform.Position);
            }

            private static TransformTile CreateTransformerFor(RoomTransform roomTransform)
            {
                var transform = ToChunkTransform(roomTransform);
                return position => Transform(position, transform);
            }

            private static GroundTileData TransformGroundTile(GroundTileData groundTile, TransformTile transformer) => With(groundTile, transformer(groundTile.Position));

            private static GroundTileData With(GroundTileData groundTile, TilePosition position) =>
                new GroundTileData(
                    position,
                    groundTile.DistanceToWall,
                    groundTile.AoiIndex);

            private static StaticObjectData TransformStaticObject(StaticObjectData staticObject, TransformTile transformer) => With(staticObject, transformer(staticObject.Position));

            private static StaticObjectData With(StaticObjectData staticObject, TilePosition position) =>
                new StaticObjectData(
                    position);

            private static CouragePickupData TransformCouragePickup(CouragePickupData pickup, TransformTile transformer) => With(pickup, transformer(pickup.Position));

            private static CouragePickupData With(CouragePickupData pickup, TilePosition position) =>
                new CouragePickupData(
                    position,
                    pickup.Variant);


            public class TransformedRoomData
            {

                public ImmutableHashSet<GroundTileData> GroundData { get; }

                public ImmutableHashSet<StaticObjectData> StaticObjectData { get; }

                public ImmutableHashSet<CouragePickupData> CouragePickupData { get; }

                public RoomType RoomType { get; }

                public ChunkPosition ChunkPosition { get; }


                public TransformedRoomData(ImmutableHashSet<GroundTileData> groundTiles, ImmutableHashSet<StaticObjectData> staticObjectData, ImmutableHashSet<CouragePickupData> couragePickupData, RoomType roomType, ChunkPosition chunkPosition)
                {
                    GroundData = groundTiles;
                    StaticObjectData = staticObjectData;
                    CouragePickupData = couragePickupData;
                    RoomType = roomType;
                    ChunkPosition = chunkPosition;
                }

            }

            internal delegate TilePosition TransformTile(TilePosition position);

        }

    }

}