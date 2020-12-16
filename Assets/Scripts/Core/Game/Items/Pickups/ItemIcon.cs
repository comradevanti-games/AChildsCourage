﻿using UnityEngine;

namespace AChildsCourage.Game.Items.Pickups
{

    [CreateAssetMenu(fileName = "Item icon", menuName = "A Child's Courage/Item icon")]
    public class ItemIcon : ScriptableObject
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private int _itemId;
        [SerializeField] private Sprite _inactiveIcon;
        [SerializeField] private Sprite _activeIcon;
        [SerializeField] private Vector3 _scale;
        [SerializeField] [Range(0, 360)] private float _rotationAngles;

#pragma warning restore 649

        #endregion

        #region Properties

        public ItemId ItemId => (ItemId) _itemId;

        public Sprite InactiveIcon => _inactiveIcon;

        public Sprite ActiveIcon => _activeIcon;

        public Vector3 Scale => _scale;

        public float RotationAngles => _rotationAngles;

        #endregion

    }

}