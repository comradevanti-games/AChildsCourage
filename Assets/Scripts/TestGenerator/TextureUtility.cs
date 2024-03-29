﻿using UnityEngine;
using static AChildsCourage.Game.Chunk;

namespace AChildsCourage.Game.Floors.Gen
{

    internal static class TextureUtility
    {

        public static void FillWith(this Texture2D texture, Color color) =>
            Grid.Generate(0, 0, texture.width, texture.height)
                .ForEach(pos => texture.SetPixel(pos.X, pos.Y, color));

        public static Texture2D CreateFittingTexture((int Width, int Height) chunkDimensions) =>
            new Texture2D(chunkDimensions.Width * ChunkSize, chunkDimensions.Height * ChunkSize)
            {
                filterMode = FilterMode.Point
            };

    }

}