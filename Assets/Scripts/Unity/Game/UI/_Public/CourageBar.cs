﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AChildsCourage.Game.UI
{
    public class CourageBar : MonoBehaviour {

        #region Fields

#pragma warning disable 649
        [SerializeField] private Image courageBarFill;
        [SerializeField] private TextMeshProUGUI courageCounterTextMesh;
        [SerializeField] private Animator courageBarAnimator;
#pragma warning restore 649

        #endregion

        #region Methods

        public void UpdateCourage(int newValue, int maxValue) {
            UpdateCourageBar(newValue, maxValue);
            UpdateCourageCounter(newValue, maxValue);
            courageBarAnimator.SetTrigger("CollectedCourage");
        }

        private void UpdateCourageBar(int newValue, int maxValue) {
            float newFillAmount = CustomMathModule.Map(newValue, 0, maxValue, 0, 1);
            StartCoroutine(FillLerp(newFillAmount));
        }

        public void UpdateCourageCounter(int newValue, int neededValue) {
            courageCounterTextMesh.text = newValue + " / " + neededValue;
        }

        IEnumerator FillLerp(float destination) {

            while(courageBarFill.fillAmount < destination) {
                courageBarFill.fillAmount = Mathf.Lerp(courageBarFill.fillAmount, destination, Time.deltaTime * 2);
                yield return new WaitForEndOfFrame();
            }
            
        }


        #endregion

    }

}