﻿using System;

namespace AChildsCourage.Game.Input {

    public interface IInputListener {

        event EventHandler<MousePositionChangedEventArgs> OnMousePositionChanged;


    }
}