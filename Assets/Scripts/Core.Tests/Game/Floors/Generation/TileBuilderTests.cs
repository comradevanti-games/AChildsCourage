﻿using NUnit.Framework;

namespace AChildsCourage.Game.Floors.Generation
{

    [TestFixture]
    public class TileBuilderTests
    {

        #region Tests

        [Test]
        public void When_A_Wall_Is_Placed_Then_An_Event_With_The_Correct_Information_Is_Raised()
        {
            // Given

            var tileBuilder = new TileBuilder();

            // When

            var position = new TilePosition(0, 0);
            var eventArgs = tileBuilder.Capture<WallPlacedEventArgs>(() => tileBuilder.PlaceWall(position));

            // Then

            Assert.That(eventArgs, Is.Not.Null, "No event was raised!");
            Assert.That(eventArgs.Position, Is.EqualTo(position), "Event raised with incorrect position!");
        }

        [Test]
        public void When_Ground_Is_Placed_Then_An_Event_With_The_Correct_Information_Is_Raised()
        {
            // Given

            var tileBuilder = new TileBuilder();

            // When

            var position = new TilePosition(0, 0);
            var eventArgs = tileBuilder.Capture<GroundPlacedEventArgs>(() => tileBuilder.PlaceGround(position));

            // Then

            Assert.That(eventArgs, Is.Not.Null, "No event was raised!");
            Assert.That(eventArgs.Position, Is.EqualTo(position), "Event raised with incorrect position!");
        }

        #endregion

    }

}