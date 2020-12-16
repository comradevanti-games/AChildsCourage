﻿using System;

namespace AChildsCourage.Game.Input
{

    internal class EquippedItemUsedEventArgs : EventArgs
    {

        #region Properties

        internal int SlotId { get; }

        #endregion

        #region Constructors

        internal EquippedItemUsedEventArgs(int slotId) => SlotId = slotId;

        #endregion

    }

}