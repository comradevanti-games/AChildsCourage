﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AChildsCourage.Game.Floors.RoomPersistence;
using static AChildsCourage.Game.Floors.Gen.RoomConfiguration;
using static AChildsCourage.Game.Floors.RoomPersistence.MRoomContentData;

namespace AChildsCourage.Game.Floors.Gen
{

    public readonly struct RoomCollection
    {

        public static RoomCollection EmptyRoomCollection => new RoomCollection(ImmutableList<RoomConfiguration>.Empty,
                                                                               ImmutableDictionary<RoomId, RoomContentData>.Empty);


        public static RoomCollection CreateRoomCollection(IEnumerable<RoomData> roomDataCollection)
        {
            RoomCollection AddRoom(RoomCollection collection, RoomData roomData)
            {
                var configurations = roomData.Map(GetConfigurations);

                return new RoomCollection(collection.configurations.AddRange(configurations),
                                          collection.contents.Add(roomData.Id, roomData.Content));
            }

            return roomDataCollection
                .Aggregate(EmptyRoomCollection, AddRoom);
        }

        public static IEnumerable<RoomConfiguration> FindConfigurationsMatching(RoomCollection collection, RoomFilter filter) =>
            collection.configurations
                      .Where(MatchesFilter, filter)
                      .IfEmpty(() => throw new Exception($"Could not find rooms matching filter {filter}!"));

        public static bool IsEmpty(RoomCollection collection) =>
            collection.configurations.IsEmpty;

        public static RoomContentData GetContentFor(RoomCollection collection, RoomId roomId) =>
            collection.contents[roomId];


        private readonly ImmutableList<RoomConfiguration> configurations;
        private readonly ImmutableDictionary<RoomId, RoomContentData> contents;


        private RoomCollection(ImmutableList<RoomConfiguration> configurations, ImmutableDictionary<RoomId, RoomContentData> contents)
        {
            this.configurations = configurations;
            this.contents = contents;
        }

    }

}