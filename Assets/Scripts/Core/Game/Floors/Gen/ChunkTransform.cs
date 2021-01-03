﻿using System.Linq;
using AChildsCourage.Game.Floors.RoomPersistence;
using static AChildsCourage.Game.MChunkPosition;
using static AChildsCourage.Game.Floors.RoomPersistence.MRoomContentData;
using static AChildsCourage.Game.MTilePosition;

namespace AChildsCourage.Game.Floors.Gen
{

    public readonly struct ChunkTransform
    {

        public static ChunkTransform CreateTransform(RoomInstance room)
        {
            var chunkCenter = GetCenter(room.Position);
            var chunkCorner = GetCorner(room.Position);

            return new ChunkTransform(room.RotationCount, room.IsMirrored, chunkCorner, chunkCenter);
        }

        public static RoomContentData Transform(RoomContentData content, ChunkTransform transform)
        {
            GroundTileData TransformGroundTile(GroundTileData groundTile) =>
                new GroundTileData(transform.Map(TransformPosition, groundTile.Position));

            StaticObjectData TransformStaticObject(StaticObjectData staticObject) =>
                new StaticObjectData(transform.Map(TransformPosition, staticObject.Position));

            RuneData TransformRune(RuneData rune) =>
                new RuneData(transform.Map(TransformPosition, rune.Position));

            CouragePickupData TransformCouragePickup(CouragePickupData pickup) =>
                new CouragePickupData(transform.Map(TransformPosition, pickup.Position), pickup.Variant);

            return new RoomContentData(content.GroundData.Select(TransformGroundTile).ToArray(),
                                       content.CourageData.Select(TransformCouragePickup).ToArray(),
                                       content.StaticObjects.Select(TransformStaticObject).ToArray(),
                                       content.Runes.Select(TransformRune).ToArray());
        }

        private static TilePosition TransformPosition(TilePosition position, ChunkTransform transform)
        {
            TilePosition Translate(TilePosition p) =>
                new TilePosition(transform.chunkCorner.X + p.X,
                                 transform.chunkCorner.Y + p.Y);

            TilePosition Rotate(TilePosition p)
            {
                var translated = new TilePosition(p.X - transform.chunkCenter.X, p.Y - transform.chunkCenter.Y);
                var rotated = new TilePosition(translated.Y, -translated.X);

                return new TilePosition(rotated.X + transform.chunkCenter.X, rotated.Y + transform.chunkCenter.Y);
            }

            TilePosition Mirror(TilePosition p)
            {
                var yDiff = transform.chunkCenter.Y - p.Y;

                return new TilePosition(p.X, transform.chunkCenter.Y + yDiff);
            }


            return position
                   .Map(Translate)
                   .For(transform.rotationCount, Rotate)
                   .DoIf(Mirror, transform.isMirrored);
        }


        private readonly int rotationCount;

        private readonly bool isMirrored;

        private readonly TilePosition chunkCorner;

        private readonly TilePosition chunkCenter;


        private ChunkTransform(int rotationCount, bool isMirrored, TilePosition chunkCorner, TilePosition chunkCenter)
        {
            this.rotationCount = rotationCount;
            this.isMirrored = isMirrored;
            this.chunkCorner = chunkCorner;
            this.chunkCenter = chunkCenter;
        }

    }

}