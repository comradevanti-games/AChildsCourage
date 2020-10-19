﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace AChildsCourage.RoomEditor
{

    public class LayerManager : MonoBehaviour
    {

        #region Fields

#pragma warning disable 649

        [SerializeField] private Tile[] tiles;
        [SerializeField] private Tilemap tilemap;

#pragma warning restore 649

        private Tile selectedTile;
        private Dictionary<string, Tile> tilesByName = new Dictionary<string, Tile>();

        #endregion

        #region Properties

        public string SelectedTileName { get { return selectedTile.name; } }

        public string[] TileNames { get { return tilesByName.Keys.ToArray(); } }

        #endregion

        #region Methods

        public void SelectTile(string name)
        {
            selectedTile = tilesByName[name];
        }


        public void PlaceTileAt(Vector2Int tilePosition)
        {
            tilemap.SetTile((Vector3Int)tilePosition, selectedTile);
        }


        public void DeleteTile(Vector2Int tilePosition)
        {
            tilemap.SetTile((Vector3Int)tilePosition, null);
        }


        public Vector2Int[] GetPositionsWithTile(string name)
        {
            var bounds = tilemap.cellBounds;
            var positions = new List<Vector2Int>();

            for (var x = bounds.xMin; x <= bounds.xMax; x++)
                for (var y = bounds.yMin; y <= bounds.yMax; y++)
                {
                    var tile = tilemap.GetTile(new Vector3Int(x, y, 0));

                    if (tile != null && tile.name == name)
                        positions.Add(new Vector2Int(x, y));
                }

            return positions.ToArray();
        }


        private void Awake()
        {
            foreach (var tile in tiles)
                tilesByName.Add(tile.name, tile);

            SelectTile(tilesByName.Keys.First());
        }

        #endregion

    }
}
