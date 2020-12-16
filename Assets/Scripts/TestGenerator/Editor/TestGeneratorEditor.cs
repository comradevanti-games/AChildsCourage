﻿using UnityEditor;
using UnityEngine;
using static AChildsCourage.Game.MFloorGenerating;
using static AChildsCourage.MRng;
using static AChildsCourage.Game.MFloorGenerating.MFloorLayoutGenerating;
using static AChildsCourage.Game.MFloorGenerating.MFloorPlanGenerating;
using Random = UnityEngine.Random;

namespace AChildsCourage.Game.Floors.TestGenerator
{

    public class TestGeneratorEditor : EditorWindow
    {

        #region Properties

        private bool HasFloorImage => floorImage != null;

        #endregion

        #region Static Methods

        [MenuItem("Window/A Child's Courage/Test Generator")]
        public static void Open() =>
            GetWindow<TestGeneratorEditor>()
                .Show();

        #endregion

        #region Fields

        private int seed;
        private Texture2D floorImage;
        private readonly CompleteRoomLoader completeRoomLoader = new CompleteRoomLoader();

        #endregion

        #region Methods

        private void OnGUI()
        {
            OnConfigGUI();

            EditorGUILayout.Space();

            if (GUILayout.Button("Generate")) GenerateFloorImage();
            if (GUILayout.Button("Generate Random"))
            {
                seed = Random.Range(int.MinValue, int.MaxValue);
                GenerateFloorImage();
            }

            EditorGUILayout.Space();

            if (HasFloorImage)
                OnFloorGUI();
            else
                EditorGUILayout.LabelField("Press \"Generate\" to test generation!");
        }

        private void OnConfigGUI() => seed = EditorGUILayout.IntField("Seed", seed);

        private void OnFloorGUI() => GUI.DrawTexture(new Rect(10, 100, floorImage.width * 10, floorImage.height * 10), floorImage);


        private void GenerateFloorImage()
        {
            var parameters = new GenerationParameters(12);
            var rng = RngFromSeed(seed);
            var floorPlan = GenerateFloorLayout(rng, parameters)
                .Map(layout => GenerateFloorPlan(layout, completeRoomLoader.All(), rng));

            floorImage = GenerateTexture.From(floorPlan, completeRoomLoader);
        }

        #endregion

    }

}