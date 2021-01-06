﻿using UnityEngine;
using UnityEngine.Tilemaps;
using static AChildsCourage.Game.TilePosition;

namespace AChildsCourage.Game.Floors
{

    public class GroundTileSpawnerEntity : MonoBehaviour
    {

        [FindComponent] private Tilemap groundTilemap;

        [FindInScene] private FloorStateKeeperEntity floorStateKeeper;
        [FindInScene] private TileRepositoryEntity tileRepository;


        public void Spawn(TilePosition position, GroundTileData _)
        {
            var tile = tileRepository.GetGroundTile();

            groundTilemap.SetTile(position.Map(ToVector3Int), tile);

            floorStateKeeper.OnGroundTilePlaced(position);
        }

    }

}