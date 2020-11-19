﻿using AChildsCourage.Game.Floors;
using NUnit.Framework;
using static AChildsCourage.Game.NightManagement.Loading.GroundBuilding;

namespace AChildsCourage.Game.NightManagement.Loading
{

    [TestFixture]
    public class GroundBuildingTests
    {

        #region Tests

        [Test]
        public void Building_Transforms_All_Tiles_And_Places_Them()
        {
            // Given

            var builder = new FloorBuilder();
            var tiles = new Tiles<GroundTile>(new[]
            {
                new GroundTile(0, 0, 0, 0),
                new GroundTile(1, 0, 0, 0)
            });
            TileTransformer transformer = pos => new TilePosition(pos.X, 1);

            // When

            BuildGroundTiles(builder, tiles, transformer);

            // Then

            var expected = new[]
            {
                new TilePosition(0, 1),
                new TilePosition(1, 1)
            };
            Assert.That(builder.GroundPositions, Is.EqualTo(expected), "Tiles incorrectly built!");
        }


        [Test]
        public void Transforming_A_Ground_Tile_Changes_Its_Position()
        {
            // Given

            var tile = new GroundTile(0, 0, 0, 0);
            TileTransformer transformer = position => new TilePosition(1, 1);

            // When

            var transformed = TransformGroundTile(tile, transformer);

            // Then

            Assert.That(transformed.Position, Is.EqualTo(new TilePosition(1, 1)), "Position incorrectly transformed!");
        }


        [Test]
        public void Creating_A_Ground_Tile_With_A_New_Position_Changes_Its_Position()
        {
            // Given

            var tile = new GroundTile(0, 0, 0, 0);

            // When

            var newtile = tile.With(new TilePosition(1, 1));

            // When

            Assert.That(newtile.Position, Is.EqualTo(new TilePosition(1, 1)), "Position should change!");
        }

        [Test]
        public void Creating_A_Ground_Tile_With_A_New_Position_Does_Not_Change_Its_Other_Properties()
        {
            // Given

            var tile = new GroundTile(0, 0, 0, 0);

            // When

            var newtile = tile.With(new TilePosition(1, 1));

            // When

            Assert.That(newtile.DistanceToWall, Is.EqualTo(tile.DistanceToWall), "Distance to wall should not change!");
            Assert.That(newtile.AOIIndex, Is.EqualTo(tile.AOIIndex), "AOI index should not change!");
        }


        [Test]
        public void Ground_Positions_Are_Placed_Into_Correct_List()
        {
            // Given

            var builder = new FloorBuilder();

            // When

            PlaceGroundTile(new GroundTile(0, 0, 0, 0), builder);

            // Then

            Assert.That(builder.GroundPositions.Contains(new TilePosition(0, 0)), Is.True, "Should be added to ground list!");
        }

        #endregion

    }

}