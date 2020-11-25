﻿using AChildsCourage.Game.Floors;
using System.Collections.Generic;
using System.Linq;

namespace AChildsCourage.Game.NightLoading
{

    internal static partial class FloorPlanGenerating
    {

        internal static FilteredRoomPassages FilterPassagesMatching(this RoomPassageFilter filter, IEnumerable<RoomPassages> allPassages)
        {
            var filteredPassages =
                allPassages
                .Where(p => RoomMatchesFilter(p, filter));

            return new FilteredRoomPassages(filteredPassages);
        }

        internal static bool RoomMatchesFilter(RoomPassages roomPassages, RoomPassageFilter filter)
        {
            return
                RoomTypesMatch(roomPassages, filter) &&
                LooseEndsMatch(roomPassages, filter) &&
                PassagesMatch(roomPassages, filter);
        }

        internal static bool RoomTypesMatch(RoomPassages passages, RoomPassageFilter filter)
        {
            return passages.Type == filter.RoomType;
        }

        internal static bool LooseEndsMatch(RoomPassages roomPassages, RoomPassageFilter filter)
        {
            var looseEnds = filter.PassageFilter.FindLooseEnds(roomPassages.Passages);

            return looseEnds <= filter.MaxLooseEnds && (filter.MaxLooseEnds > 0 ? looseEnds > 0 : true);
        }

        internal static bool PassagesMatch(RoomPassages passages, RoomPassageFilter filter)
        {
            return filter.PassageFilter.Matches(passages.Passages);
        }

    }

}