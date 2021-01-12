﻿using System;
using AChildsCourage.Game.Char;
using AChildsCourage.Game.Floors.Courage;
using AChildsCourage.Game.Input;

namespace AChildsCourage.Game
{

    public class GameManager : SceneManagerEntity
    {

        [Pub] public event EventHandler OnBackToMainMenu;

        [Pub] public event EventHandler OnStartGame;


        [Sub(nameof(CharControllerEntity.OnCharKilled))]
        private void OnCharKilled(object _1, EventArgs _2) =>
            OnLose();

        private void OnLose() =>
            Transition.To(SceneName.menu);

        [Sub(nameof(CourageRiftEntity.OnCharEnteredRift))]
        private void OnCharEnteredRift(object _1, EventArgs _2) =>
            OnWin();

        private void OnWin() =>
            Transition.To(SceneName.endCutscene);

        private void BackToMainMenu() =>
            Transition.To(SceneName.menu);

        [Sub(nameof(InputListener.OnExitInput))]
        private void OnExitInputPressed(object _1, EventArgs _2)
        {
            OnBackToMainMenu?.Invoke(this, EventArgs.Empty);
            BackToMainMenu();
        }

        internal override void OnSceneVisible() =>
            OnStartGame?.Invoke(this, EventArgs.Empty);

    }

}