﻿using System.Linq;
using static AChildsCourage.Game.Floors.Gen.ChunkTransform;
using static AChildsCourage.Game.Floors.Gen.FloorPlan;
using static AChildsCourage.Game.Floors.Gen.RoomCollection;
using static AChildsCourage.Game.Floors.Gen.RoomPlan;
using static AChildsCourage.Game.Floors.RoomPersistence.MRoomContentData;

namespace AChildsCourage.Game.Floors.Gen
{

    public static class FloorPlanGen
    {

        public static FloorPlan CreateFloorPlan(RoomPlan roomPlan, FloorGenParams @params)
        {
            var roomCollection = @params.RoomCollection;

            RoomContentData GetTransformedContent(RoomInstance room)
            {
                var transform = room.Map(CreateTransform);
                return roomCollection.Map(GetContentFor, room.Id)
                                     .Map(TransformContent, transform);
            }

            return roomPlan
                   .Map(Rooms)
                   .Select(GetTransformedContent)
                   .Aggregate(EmptyFloorPlan, AddContent);
        }

    }

}