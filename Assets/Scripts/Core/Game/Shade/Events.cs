﻿using System;
using UnityEngine.Events;

namespace AChildsCourage.Game.Shade
{

    public static class ShadeEvents
    {

        [Serializable]
        public class AwarenessLevel : UnityEvent<Shade.AwarenessLevel> { }

        [Serializable]
        public class VisibilityEvent : UnityEvent<Visibility> { }

        [Serializable]
        public class TilesInViewEvent : UnityEvent<TilesInView> { }

    }

}