﻿using AChildsCourage.Game.Floors;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace AChildsCourage.RoomEditor
{

    public class DataTileLayer : TileLayer
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private Tile itemTile;
        [SerializeField] private Tile courageSparkTile;
        [SerializeField] private Tile courageOrbTile;
        [SerializeField] private Tile startPointTile;
        [SerializeField] private Tile endPointTile;

#pragma warning restore 649

        #endregion

        #region Methods

        public void PlaceAll(Tiles<DataTile> dataTiles)
        {
            Clear();

            foreach (var dataTile in dataTiles)
                Place(dataTile);
        }

        private void Place(DataTile dataTile)
        {
            var tile = GetTileFor(dataTile.Type);

            PlaceTileAt(tile, dataTile.Position);
        }


        public void PlaceAt(Vector2Int position, DataTileType tileType)
        {
            var tile = GetTileFor(tileType);

            PlaceTileAt(tile, position);
        }


        public Tiles<DataTile> ReadAll()
        {
            return new Tiles<DataTile>(
                GetTiles()
                .Select(ToDataTile));
        }

        private DataTile ToDataTile(TileAtPos tileAtPos)
        {
            var position = tileAtPos.Position;
            var tileType = GetTypeOf(tileAtPos.Tile);

            return new DataTile(position, tileType);
        }

        private DataTileType GetTypeOf(Tile tile)
        {
            return (DataTileType)Enum.Parse(typeof(DataTileType), tile.name);
        }


        private Tile GetTileFor(DataTileType tileType)
        {
            switch (tileType)
            {
                case DataTileType.Item:
                    return itemTile;
                case DataTileType.CourageSpark:
                    return courageSparkTile;
                case DataTileType.CourageOrb:
                    return courageOrbTile;
                case DataTileType.StartPoint:
                    return startPointTile;
                case DataTileType.EndPoint:
                    return endPointTile;
            }

            throw new System.Exception("Invalid tile-type!");
        }

        #endregion

    }

}