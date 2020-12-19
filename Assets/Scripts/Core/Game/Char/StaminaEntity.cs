﻿using System;
using System.Collections;
using AChildsCourage.Infrastructure;
using UnityEngine;

namespace AChildsCourage.Game.Char
{

    public class StaminaEntity : MonoBehaviour
    {

        [Pub] public event EventHandler OnStaminaDepleted;

        [Pub] public event EventHandler OnStaminaRefreshed;

        #region Fields
        
        [Header("Stats")]
        public float stamina = 100;



        [SerializeField] private float staminaDepletedCooldown;
        [SerializeField] private EnumArray<MovementState, float> staminaRates;
        [SerializeField] private float recoveredStaminaAmount;



        private float staminaDrainRate = 1f;
        private bool isOnCooldown;

        #endregion

        #region Methods

        private void Start() => StartCoroutine(Sprint());


        [Sub(nameof(CharControllerEntity.OnMovementStateChanged))]
        private void OnMovementStateChanged(object _, MovementStateChangedEventArgs eventArgs) => SetStaminaDrainRate(eventArgs.Current);

        private void SetStaminaDrainRate(MovementState movementState) => staminaDrainRate = staminaRates[movementState];

        private IEnumerator Sprint()
        {
            while (true)
            {
                if (!isOnCooldown)
                {
                    stamina = stamina.Plus(staminaDrainRate * Time.deltaTime).Clamp(0, 100);

                    if (stamina <= 0.05f)
                    {
                        StartCoroutine(Cooldown());
                        OnStaminaDepleted?.Invoke(this, EventArgs.Empty);
                    }

                    yield return null;
                }

                yield return null;
            }
        }

        private IEnumerator Cooldown()
        {
            isOnCooldown = true;
            yield return new WaitForSeconds(staminaDepletedCooldown);
            isOnCooldown = false;
            RefreshStamina(recoveredStaminaAmount);
        }

        private void RefreshStamina(float recoveredStaminaAmount)
        {
            stamina = recoveredStaminaAmount;
            OnStaminaRefreshed?.Invoke(this, EventArgs.Empty);
        }

        #endregion

    }

}