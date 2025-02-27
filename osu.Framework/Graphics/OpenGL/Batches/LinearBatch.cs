﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using System;
using osu.Framework.Graphics.OpenGL.Buffers;
using osu.Framework.Graphics.Rendering;
using osu.Framework.Graphics.Rendering.Vertices;
using osuTK.Graphics.ES30;

namespace osu.Framework.Graphics.OpenGL.Batches
{
    internal class LinearBatch<T> : VertexBatch<T>
        where T : struct, IEquatable<T>, IVertex
    {
        private readonly PrimitiveType type;

        public LinearBatch(OpenGLRenderer renderer, int size, int maxBuffers, PrimitiveTopology topology)
            : base(renderer, size, maxBuffers)
        {
            switch (topology)
            {
                case PrimitiveTopology.Points:
                    type = PrimitiveType.Points;
                    break;

                case PrimitiveTopology.Lines:
                    type = PrimitiveType.Lines;
                    break;

                case PrimitiveTopology.LineStrip:
                    type = PrimitiveType.LineStrip;
                    break;

                case PrimitiveTopology.Triangles:
                    type = PrimitiveType.Triangles;
                    break;

                case PrimitiveTopology.TriangleStrip:
                    type = PrimitiveType.TriangleStrip;
                    break;

                default:
                    throw new ArgumentException($"Unsupported vertex topology: {topology}.", nameof(topology));
            }
        }

        protected override VertexBuffer<T> CreateVertexBuffer(OpenGLRenderer renderer) => new LinearVertexBuffer<T>(renderer, Size, type, BufferUsageHint.DynamicDraw);
    }
}
