﻿using System.Linq;
using NUnit.Framework;
using static AChildsCourage.MRng;

namespace AChildsCourage
{

    [TestFixture]
    public class CollectionRngTests
    {

        [Test]
        public void Getting_A_Random_Element_From_Empty_Collection_Returns_Default()
        {
            // Given

            var elements = new int[0];

            float CreateRng() => 0;

            // When

            var element = elements.GetRandom(CreateRng);

            // Then

            Assert.That(element, Is.Zero, "Did not get default element!");
        }

        [Test]
        public void Getting_A_Random_Weighted_Element_From_Empty_Collection_Returns_Default()
        {
            // Given

            var elements = new int[0];

            float CreateRng() => 0;

            // When

            var element = elements.GetWeightedRandom(e => e, CreateRng);

            // Then

            Assert.That(element, Is.Zero, "Did not get default element!");
        }

        [Test]
        public void Elements_With_Double_The_Weight_Appear_Approximately_Double_As_Often()
        {
            // Given

            var elements = new[] {1, 2};
            var rng = FromSeed(0);

            // When

            var numbers = new int[1000];

            for (var i = 0; i < numbers.Length; i++) numbers[i] = elements.GetWeightedRandom(e => e, rng);

            // Then

            var element1Count = numbers.Count(n => n == 1);
            var element2Count = numbers.Count(n => n == 2);

            Assert.That(element2Count, Is.EqualTo(element1Count * 2)
                                         .Within(100), "Element not selected approximately double as often!");
        }

    }

}