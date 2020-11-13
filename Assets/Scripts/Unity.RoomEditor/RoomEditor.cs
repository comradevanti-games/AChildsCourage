﻿using AChildsCourage.Game.Floors;
using AChildsCourage.Game.Floors.Generation;
using AChildsCourage.Game.Floors.Persistance;
using UnityEngine;

namespace AChildsCourage.RoomEditor
{

    public class RoomEditor : MonoBehaviour
    {

        #region Fields

        [SerializeField] private GroundTileLayer groundLayer;
        [SerializeField] private DataTileLayer dataLayer;

        private RoomAsset loadedAsset;

        #endregion

        #region Properties

        public TileCategory SelectedTileCategory { get; set; }

        public DataTileType SelectedDataTileType { get; set; }

        public ChunkPassages CurrentPassages { get; set; }

        public RoomType CurrentRoomType { get; set; }


        public int CurrentAssetId { get { return loadedAsset.Id; } }


        public bool HasLoadedAsset { get { return loadedAsset != null; } }


        public bool CurrentRoomIsStartRoom { get { return CurrentRoomType == RoomType.Start; } }


        public bool CurrentRoomIsEndRoom { get { return CurrentRoomType == RoomType.End; } }

        #endregion

        #region Methods

        public void OnAssetSelected(RoomAsset asset)
        {
            loadedAsset = asset;

            Load(asset.Room);
        }

        private void Load(Room room)
        {
            CurrentPassages = room.Passages;
            CurrentRoomType = room.Type;

            groundLayer.PlaceAll(room.GroundTiles);
            dataLayer.PlaceAll(room.DataTiles);
        }


        public void OnMouseDown(MouseDownEventArgs eventArgs)
        {
            if (HasLoadedAsset)
                ProcessEvent(eventArgs);
        }

        private void ProcessEvent(MouseDownEventArgs eventArgs)
        {
            if (eventArgs.MouseButtonName == MouseListener.LeftButtonName)
                PlaceTileAt(eventArgs.Position);
            else
                DeleteTileAt(eventArgs.Position);
        }

        private void PlaceTileAt(Vector2Int position)
        {
            switch (SelectedTileCategory)
            {
                case TileCategory.Ground:
                    groundLayer.PlaceAt(position);
                    break;
                case TileCategory.Data:
                    dataLayer.PlaceAt(position, SelectedDataTileType);
                    break;
            }
        }

        private void DeleteTileAt(Vector2Int position)
        {
            switch (SelectedTileCategory)
            {
                case TileCategory.Ground:
                    groundLayer.DeleteTileAt(position);
                    break;
                case TileCategory.Data:
                    dataLayer.DeleteTileAt(position);
                    break;
            }
        }


        public void SaveChanges()
        {
            var room = new Room(
                CurrentRoomType,
                groundLayer.ReadAll(),
                dataLayer.ReadAll(),
                CurrentPassages);

            loadedAsset.Room = room;
        }

        #endregion

    }

}
