﻿using AChildsCourage.Game.FloorGeneration.Persistance;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace AChildsCourage.Game.FloorGeneration.Editor
{

    public class RoomEditorWindow : EditorWindow
    {

        #region Fields

        private RoomAsset selectedRoomAsset;
        private Tilemap _wallTileMap;
        private Tile _wallTile;
        private Tilemap _floorTileMap;
        private Tile _floorTile;

        #endregion

        #region Properties

        private Tilemap WallTileMap
        {
            get
            {
                if (_wallTileMap == null)
                    _wallTileMap = GameObject.Find("Walls").GetComponent<Tilemap>();
                return _wallTileMap;
            }
        }

        private Tile WallTile
        {
            get
            {
                if (_wallTile == null)
                    _wallTile = AssetDatabase.LoadAssetAtPath<Tile>("Assets/Sprites/Editor/Placeholder_Wall.asset");

                return _wallTile;
            }
        }

        private Tilemap FloorTileMap
        {
            get
            {
                if (_floorTileMap == null)
                    _floorTileMap = GameObject.Find("Floor").GetComponent<Tilemap>();
                return _floorTileMap;
            }
        }

        private Tile FloorTile
        {
            get
            {
                if (_floorTile == null)
                    _floorTile = AssetDatabase.LoadAssetAtPath<Tile>("Assets/Sprites/Editor/Placeholder_Floor.asset");

                return _floorTile;
            }
        }

        #endregion

        #region Methods

        private void OnGUI()
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "RoomEditor")
                DrawEditor();
            else
                EditorGUILayout.LabelField("Open the RoomEditor scene to edit rooms!");
        }

        private void DrawEditor()
        {
            selectedRoomAsset = (RoomAsset)EditorGUILayout.ObjectField("Room asset: ", selectedRoomAsset, typeof(RoomAsset), false);

            if (selectedRoomAsset != null)
                DrawRoomEditor();
            else
                EditorGUILayout.LabelField("Select a room asset to start editing!");
        }

        private void DrawRoomEditor()
        {
            if (GUILayout.Button("Load room from asset"))
                LoadFromAsset(selectedRoomAsset);
            if (GUILayout.Button("Save changes"))
                SaveChangesToAsset(selectedRoomAsset);
        }

        private void LoadFromAsset(RoomAsset asset)
        {
            LoadRoomShape(asset.RoomShape);
        }

        private void LoadRoomShape(RoomShape roomShape)
        {
            LoadWalls(roomShape.WallPositions);
            LoadFloors(roomShape.FloorPositions);
        }

        private void LoadWalls(TilePosition[] wallPositions)
        {
            WallTileMap.ClearAllTiles();

            foreach (var wallPosition in wallPositions)
            {
                var vectorPosition = new Vector3Int(wallPosition.X, wallPosition.Y, 0);
                WallTileMap.SetTile(vectorPosition, WallTile);
            }
        }

        private void LoadFloors(TilePosition[] floorPositions)
        {
            FloorTileMap.ClearAllTiles();

            foreach (var floorPosition in floorPositions)
            {
                var vectorPosition = new Vector3Int(floorPosition.X, floorPosition.Y, 0);
                FloorTileMap.SetTile(vectorPosition, FloorTile);
            }
        }

        private void SaveChangesToAsset(RoomAsset asset)
        {
            asset.RoomShape = ReadRoomShape();
        }

        private RoomShape ReadRoomShape()
        {
            var wallPositions = ReadWallPositions();
            var floorPositions = ReadFloorPositions();

            return new RoomShape(wallPositions, floorPositions);
        }

        private TilePosition[] ReadWallPositions()
        {
            return GetOccupiedPositions(WallTileMap).ToArray();
        }

        private TilePosition[] ReadFloorPositions()
        {
            return GetOccupiedPositions(FloorTileMap).ToArray();
        }

        private IEnumerable<TilePosition> GetOccupiedPositions(Tilemap tilemap)
        {
            var bounds = tilemap.cellBounds;

            for (var x = bounds.xMin; x <= bounds.xMax; x++)
                for (var y = bounds.yMin; y <= bounds.yMax; y++)
                {
                    var tile = tilemap.GetTile(new Vector3Int(x, y, 0));

                    if (tile != null)
                        yield return new TilePosition(x, y);
                }
        }

        #endregion

    }

}