﻿using UnityEngine;

namespace AChildsCourage.Game.Floors
{

    [CreateAssetMenu(fileName = "New static object", menuName = "A Child's Courage/Static Object")]
    public class StaticObjectAppearance : ScriptableObject
    {

#pragma warning disable 649

        [SerializeField] private Sprite sprite;

#pragma warning  restore 649

        public Sprite Sprite { get => sprite; }

    }

}