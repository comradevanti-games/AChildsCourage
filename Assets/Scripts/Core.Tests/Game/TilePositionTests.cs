﻿using NUnit.Framework;
using static AChildsCourage.Game.MTilePosition;

namespace AChildsCourage.Game
{

    [TestFixture]
    public class TilePositionTests
    {

        [Test]
        public void Given_Any_Coordinates_When_A_TilePosition_Is_Created_From_Them_Then_It_Has_These_Coordinates()
        {
            // Given

            const int x = 5;
            const int y = -10;

            // When

            var position = new TilePosition(x, y);

            // Then

            Assert.That(position.X, Is.EqualTo(x), "Incorrect X coordinate!");
            Assert.That(position.Y, Is.EqualTo(y), "Incorrect Y coordinate!");
        }

        [Test]
        public void Given_A_TilePosition_When_An_Offset_Is_Added_Then_The_Coordinates_Are_Added()
        {
            // Given

            var position = new TilePosition(0, 0);
            var offset = new TileOffset(1, -1);

            // When

            var actual = OffsetTilePosition(position, offset);

            // Then

            Assert.That(actual.X, Is.EqualTo(position.X + offset.X), "X coordinate incorrectly added!");
            Assert.That(actual.Y, Is.EqualTo(position.Y + offset.Y), "Y coordinate incorrectly added!");
        }


        [Test]
        public void Distance_From_Origin_Is_Calculated_Correctly()
        {
            // Given

            var position = new TilePosition(2, 0);

            // When

            var distance = GetDistanceFromOrigin(position);

            // When

            Assert.That(distance, Is.EqualTo(2), "Incorrect distance calculated!");
        }


        [Test]
        public void Distance_Between_Positions_Is_Calculated_Correctly()
        {
            // Given

            var p1 = new TilePosition(0, 0);
            var p2 = new TilePosition(2, 0);

            // When

            var distance = GetDistanceBetween(p1, p2);

            // When

            Assert.That(distance, Is.EqualTo(2), "Incorrect distance calculated!");
        }

    }

}