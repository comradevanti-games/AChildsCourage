﻿using Ninject.Extensions.Unity;
using System.Linq;
using UnityEngine;

namespace AChildsCourage.Game.Items.Pickups
{
    [UseDI]
    public class ItemPickupSpawner : MonoBehaviour
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private GameObject pickupPrefab;
        [SerializeField] private Transform pickupContainer;
        [SerializeField] private ItemIcon[] itemIcons;

#pragma warning restore 649

        #endregion

        #region Properties

        [AutoInject] internal ItemDataFinder FindItemData { private get; set; }

        #endregion

        #region Methods

        public void SpawnPickupFor(ItemId itemId, Vector3 position)
        {
            var pickupEntity = SpawnItemPickup(position);
            var itemData = FindItemData(itemId);
            var icon = itemIcons.First(i => i.ItemId == itemData.Id);

            pickupEntity.SetItemData(itemData, icon);
        }

        private ItemPickupEntity SpawnItemPickup(Vector3 position)
        {
            var itemGameObject = Instantiate(pickupPrefab, position, Quaternion.identity, pickupContainer);
            return itemGameObject.GetComponent<ItemPickupEntity>();
        }

        #endregion

    }

}