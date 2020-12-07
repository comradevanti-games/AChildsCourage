﻿using System;
using System.Collections.Generic;
using System.Linq;
using static AChildsCourage.MRng;

namespace AChildsCourage
{

    public static class MCollectionRng
    {

        public delegate float CalculateWeight<in T>(T element);


        public static T GetWeightedRandom<T>(this IEnumerable<T> elements, CalculateWeight<T> calculateWeight, CreateRng createRng) => GetWeightedRandom(calculateWeight, createRng, elements);


        public static T GetWeightedRandom<T>(CalculateWeight<T> calculateWeight, CreateRng createRng, IEnumerable<T> elements)
        {
            var elementsArray = elements as T[] ?? elements.ToArray();
            if (!elementsArray.Any())
                return default;

            var weightedElements = elementsArray.AttachWeights(calculateWeight).ToArray();

            var totalWeight = weightedElements.Sum(o => o.Weight);
            var itemWeightIndex = createRng.GetValueUnder(totalWeight);
            var currentWeightIndex = 0f;

            foreach (var weightedElement in weightedElements)
            {
                currentWeightIndex += weightedElement.Weight;

                if (currentWeightIndex >= itemWeightIndex)
                    return weightedElement.Element;
            }

            throw new Exception("No element selected. This should not happen!");
        }

        private static IEnumerable<Weighted<T>> AttachWeights<T>(this IEnumerable<T> elements, CalculateWeight<T> calculateWeight) =>
            elements
                .Select(o => AttachWeight(o, calculateWeight));


        private static Weighted<T> AttachWeight<T>(T element, CalculateWeight<T> calculateWeight) => new Weighted<T>(element, calculateWeight(element));


        public static T GetRandom<T>(this IEnumerable<T> elements, CreateRng createRng) => GetRandom(createRng, elements);


        public static T GetRandom<T>(CreateRng createRng, IEnumerable<T> elements)
        {
            var elementsArray = elements.ToArray();

            if (elementsArray.Length == 0)
                return default;

            var index = createRng.GetValueUnder(elementsArray.Length);
            return elementsArray[index];
        }


        private readonly struct Weighted<T>
        {

            internal T Element { get; }

            internal float Weight { get; }


            internal Weighted(T element, float weight)
            {
                Element = element;
                Weight = weight;
            }

        }

    }

}