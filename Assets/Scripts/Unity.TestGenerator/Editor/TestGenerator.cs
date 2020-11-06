﻿using Ninject;
using UnityEditor;
using UnityEngine;

namespace AChildsCourage.Game.Floors.Generation.Editor
{

    public class TestGenerator : EditorWindow
    {

        #region Static Methods

        [MenuItem("Window/A Child's Courage/Test Generator")]
        public static void Open()
        {
            GetWindow<TestGenerator>().Show();
        }

        #endregion

        #region Fields

        private int seed;
        private Texture2D floorImage;
        private readonly TestRoomInfoRespository roomInfoRepo = new TestRoomInfoRespository();
        private IFloorGenerator _floorGenerator;

        #endregion

        #region Properties

        private bool HasFloorImage { get { return floorImage != null; } }

        private IFloorGenerator FloorGenerator
        {
            get
            {
                if (_floorGenerator == null)
                    _floorGenerator = GetFloorGenerator();

                return _floorGenerator;
            }
        }

        #endregion

        #region Methods

        private void OnGUI()
        {
            OnConfigGUI();

            EditorGUILayout.Space();

            if (GUILayout.Button("Generate"))
                GenerateFloorImage();
            if (GUILayout.Button("Generate Random"))
            {
                seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
                GenerateFloorImage();
            }

            EditorGUILayout.Space();

            if (HasFloorImage)
                OnFloorGUI();
            else
                EditorGUILayout.LabelField("Press \"Generate\" to test generation!");
        }

        private void OnConfigGUI()
        {
            seed = EditorGUILayout.IntField("Seed", seed);
        }

        private void OnFloorGUI()
        {
            GUI.DrawTexture(new Rect(10, 100, floorImage.width * 10, floorImage.height * 10), floorImage);
        }


        private IFloorGenerator GetFloorGenerator()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IRNG>().To<RNG>();
            kernel.Bind<IChunkGrid>().To<ChunkGrid>();

            return new FloorGenerator(roomInfoRepo, kernel);
        }


        private void GenerateFloorImage()
        {
            roomInfoRepo.Reset();
            var floorPlan = FloorGenerator.GenerateNew(seed);

            floorImage = GenerateTexture.From(floorPlan, roomInfoRepo);
        }

        #endregion

    }

}