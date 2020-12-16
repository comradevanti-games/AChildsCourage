﻿using System.Collections.Generic;
using AChildsCourage.Game.Items;
using UnityEngine;

public static class ItemDataRepository
{

    public delegate IEnumerable<ItemId> LoadItemIds();

    private const string ResourcePath = "Items/";


    private static readonly Dictionary<ItemId, ItemData> cachedItemData = new Dictionary<ItemId, ItemData>();


    private static bool HasCache => cachedItemData.Count > 0;


    public static LoadItemIds GetItemIdLoader() => GetItemIds;

    private static IEnumerable<ItemId> GetItemIds()
    {
        if (!HasCache) FillCache();

        return cachedItemData.Keys;
    }


    public static FindItemData GetItemDataFinder() => GetItemDataBy;

    private static ItemData GetItemDataBy(ItemId id)
    {
        if (!HasCache) FillCache();

        return cachedItemData[id];
    }


    private static void FillCache()
    {
        foreach (var asset in Resources.LoadAll<ItemDataAsset>(ResourcePath))
        {
            var data = asset.Data;

            cachedItemData.Add(data.Id, data);
        }
    }

}