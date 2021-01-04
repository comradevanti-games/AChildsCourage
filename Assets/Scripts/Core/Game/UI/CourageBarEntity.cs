﻿using AChildsCourage.Game.Char;
using AChildsCourage.Game.Floors.Courage;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static AChildsCourage.Lerping;

namespace AChildsCourage.Game.UI
{

    public class CourageBarEntity : MonoBehaviour
    {

        private const float HundredPercent = 1;

        private static readonly Color defaultTextColor = new Color(1, 1, 1, 1);

        [SerializeField] private float barFillTime;
        [SerializeField] private Image courageBarFill;
        [SerializeField] private TextMeshProUGUI courageCounterTextMesh;
        [SerializeField] private Color textColor;
        [SerializeField] private Animation pickupAnimation;

        private float completionPercent;


        private float FillPercent
        {
            get => courageBarFill.fillAmount;
            set => courageBarFill.fillAmount = value.Clamp(0, 1);
        }

        private float CompletionPercent
        {
            get {
                return completionPercent;
            }
            set
            {
                completionPercent = value;
                TextColor = value >= HundredPercent ? textColor : defaultTextColor;
                Text = $"{Mathf.FloorToInt(value * 100)}%";
            }
        }

        private Color TextColor
        {
            set => courageCounterTextMesh.color = value;
        }

        private string Text
        {
            set => courageCounterTextMesh.text = value;
        }


        [Sub(nameof(CourageManagerEntity.OnCollectedCourageChanged))]
        private void OnCollectedCourageChanged(object _, CollectedCourageChangedEventArgs eventArgs) =>
            CompletionPercent = eventArgs.CompletionPercent;

        [Sub(nameof(CharControllerEntity.OnCouragePickedUp))]
        private void OnCouragePickedUp(object _, CouragePickedUpEventArgs eventArgs) {

            if(eventArgs.Variant == CourageVariant.Spark) {
                pickupAnimation.PlayQueued("Spark", QueueMode.CompleteOthers);
            }

        }

        private void PlayFillAnimation(AnimationEvent fillAnimation) {
            fillAnimation.floatParameter = CompletionPercent;
            UpdateBarFill(CompletionPercent);
        }


        private void UpdateBarFill(float percent) =>
            this.StartOnly(() => TimeLerp(new Range<float>(FillPercent, percent),
                                          t => FillPercent = t,
                                          barFillTime));

    }

}