﻿using System.Collections.Generic;
using System.Collections.Immutable;

namespace AChildsCourage.Game.Floors.Gen
{

    public readonly struct RoomPlan
    {

        public static RoomPlan EmptyRoomPlan => new RoomPlan(ImmutableList<RoomInstance>.Empty);


        public static RoomPlan AddRoom(RoomPlan roomPlan, RoomInstance instance) =>
            new RoomPlan(roomPlan.rooms.Add(instance));

        public static IEnumerable<RoomInstance> Rooms(RoomPlan roomPlan) =>
            roomPlan.rooms;


        private readonly ImmutableList<RoomInstance> rooms;


        private RoomPlan(ImmutableList<RoomInstance> rooms) =>
            this.rooms = rooms;

    }

}