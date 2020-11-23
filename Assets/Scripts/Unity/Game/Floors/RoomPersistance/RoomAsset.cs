﻿using Newtonsoft.Json;
using UnityEngine;

namespace AChildsCourage.Game.Floors.RoomPersistance
{

    [CreateAssetMenu(menuName = "A Child's Courage/Room", fileName = "New Room")]
    public class RoomAsset : ScriptableObject
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private int _id;
        [SerializeField] private RoomType _type;
        [SerializeField] [TextArea(10, 15)] private string passageJson;
        [SerializeField] [TextArea(10, 40)] private string contentJson;
        [SerializeField] [HideInInspector] private string roomJson;

#pragma warning restore 649

        #endregion

        #region Properties

        public int Id { get { return _id; } }

        public RoomType Type { get { return _type; } }

        public ChunkPassages Passages
        {
            get { return JsonConvert.DeserializeObject<ChunkPassages>(passageJson); }
            set { passageJson = JsonConvert.SerializeObject(value); }
        }

        public RoomContentData Content
        {
            get { return JsonConvert.DeserializeObject<RoomContentData>(contentJson); }
            set { contentJson = JsonConvert.SerializeObject(value); }
        }

        #endregion

    }

}