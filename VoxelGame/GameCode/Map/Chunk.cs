using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VoxelGame.GameCode.Map.Block;
using VoxelGame.GameCode.Map.Generator;
using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map
{
    class Chunk : DrawableGameComponent
    {
        public static readonly int SizeX = 16;
        public static readonly int SizeY = 16;
        public static readonly int SizeZ = 16;

        private readonly IBlock[,,] _blocks;
        private VertexBuffer _chunkVertexBuffer;
        private IndexBuffer _chunkIndexBuffer;
        private bool _needRebuild;

        public ChunkOffset Offset { get; }
        public Matrix WorldMatrix => Matrix.CreateTranslation(Offset.X * SizeX, Offset.Y * SizeY, Offset.Z * SizeZ);
        public BoundingBox BoundingBox => new BoundingBox(
                    new Vector3(Offset.X * SizeX, Offset.Y * SizeY, Offset.Z * SizeZ),
                    new Vector3(Offset.X * SizeX + SizeX, Offset.Y * SizeY + SizeY, Offset.Z * SizeZ + SizeZ));

        

        public Chunk(Game game, ChunkOffset offset) : base(game)
        {
            _blocks = new IBlock[SizeX, SizeY, SizeZ];
            _needRebuild = true;

            Offset = offset;
        }

        public override void Initialize()
        {
            BaseGenerator baseGenerator = new BaseGenerator();
            baseGenerator.Generate(this);

            GenerateMesh();
            _needRebuild = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (_needRebuild)
            {
                GenerateMesh();
                _needRebuild = false;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (_chunkVertexBuffer == null)
                return;

            if (_chunkVertexBuffer.VertexCount == 0)
                return;

            GraphicsDevice.Indices = _chunkIndexBuffer;
            GraphicsDevice.SetVertexBuffer(_chunkVertexBuffer);
            GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, _chunkVertexBuffer.VertexCount / 2);
        }

        public Vector3 GetAbsPosition() => CoordinateConverter.ToAbsPosition(Offset);

        public Vector3 GetAbsPosition(BlockOffset blockOffset) => CoordinateConverter.ToAbsPosition(Offset, blockOffset);

        public IBlock GetBlock(BlockOffset blockOffset)
        {
            if (blockOffset.X >= 0 && blockOffset.X < SizeX &&
                blockOffset.Y >= 0 && blockOffset.Y < SizeY &&
                blockOffset.Z >= 0 && blockOffset.Z < SizeZ)
                return _blocks[blockOffset.X, blockOffset.Y, blockOffset.Z];

            return new BlockAir();
        }

        public void SetBlock(BlockOffset blockOffset, IBlock block)
        {
            if (blockOffset.X >= 0 && blockOffset.X < SizeX &&
                blockOffset.Y >= 0 && blockOffset.Y < SizeY &&
                blockOffset.Z >= 0 && blockOffset.Z < SizeZ)
            {
                _blocks[blockOffset.X, blockOffset.Y, blockOffset.Z] = block;
                _needRebuild = true;
            }
        }

        private void GenerateMesh()
        {
            List<VertexPositionNormalTexture> vertexPositionNormalTexture = new List<VertexPositionNormalTexture>();
            List<int> indices = new List<int>();

            Dictionary<BlockId, List<VertexPositionNormalTexture>> d = new Dictionary<BlockId, List<VertexPositionNormalTexture>>();

            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    for (int z = 0; z < SizeZ; z++)
                    {
                        if (!(GetBlock(new BlockOffset(x, y, z)) is BlockAir))
                        {
                            BlockId blockId = GetBlock(new BlockOffset(x, y, z)).GetBlockId();
                            
                            //front
                            if (GetBlock(new BlockOffset(x, y, z + 1)) is BlockAir)
                            {
                                int offsetIndex = vertexPositionNormalTexture.Count;

                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 0, y + 0, z + 1), Vector3.Backward, new Vector2(0, 0)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 0, y + 1, z + 1), Vector3.Backward, new Vector2(0, 1)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 1, y + 1, z + 1), Vector3.Backward, new Vector2(1, 1)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 1, y + 0, z + 1), Vector3.Backward, new Vector2(1, 0)));

                                indices.Add(offsetIndex + 0);
                                indices.Add(offsetIndex + 1);
                                indices.Add(offsetIndex + 2);
                                indices.Add(offsetIndex + 2);
                                indices.Add(offsetIndex + 3);
                                indices.Add(offsetIndex + 0);
                            }

                            //back
                            if (GetBlock(new BlockOffset(x, y, z - 1)) is BlockAir)
                            {
                                int offsetIndex = vertexPositionNormalTexture.Count;

                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 1, y + 0, z + 0), Vector3.Forward, new Vector2(0, 0)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 1, y + 1, z + 0), Vector3.Forward, new Vector2(0, 1)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 0, y + 1, z + 0), Vector3.Forward, new Vector2(1, 1)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 0, y + 0, z + 0), Vector3.Forward, new Vector2(1, 0)));

                                indices.Add(offsetIndex + 0);
                                indices.Add(offsetIndex + 1);
                                indices.Add(offsetIndex + 2);
                                indices.Add(offsetIndex + 2);
                                indices.Add(offsetIndex + 3);
                                indices.Add(offsetIndex + 0);
                            }

                            //left
                            if (GetBlock(new BlockOffset(x - 1, y, z)) is BlockAir)
                            {
                                int offsetIndex = vertexPositionNormalTexture.Count;

                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 0, y + 0, z + 0), Vector3.Left, new Vector2(0, 0)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 0, y + 1, z + 0), Vector3.Left, new Vector2(0, 1)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 0, y + 1, z + 1), Vector3.Left, new Vector2(1, 1)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 0, y + 0, z + 1), Vector3.Left, new Vector2(1, 0)));

                                indices.Add(offsetIndex + 0);
                                indices.Add(offsetIndex + 1);
                                indices.Add(offsetIndex + 2);
                                indices.Add(offsetIndex + 2);
                                indices.Add(offsetIndex + 3);
                                indices.Add(offsetIndex + 0);
                            }

                            //right
                            if (GetBlock(new BlockOffset(x + 1, y, z)) is BlockAir)
                            {
                                int offsetIndex = vertexPositionNormalTexture.Count;

                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 1, y + 0, z + 1), Vector3.Right, new Vector2(0, 0)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 1, y + 1, z + 1), Vector3.Right, new Vector2(0, 1)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 1, y + 1, z + 0), Vector3.Right, new Vector2(1, 1)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 1, y + 0, z + 0), Vector3.Right, new Vector2(1, 0)));

                                indices.Add(offsetIndex + 0);
                                indices.Add(offsetIndex + 1);
                                indices.Add(offsetIndex + 2);
                                indices.Add(offsetIndex + 2);
                                indices.Add(offsetIndex + 3);
                                indices.Add(offsetIndex + 0);
                            }

                            //up
                            if (GetBlock(new BlockOffset(x, y + 1, z)) is BlockAir)
                            {
                                int offsetIndex = vertexPositionNormalTexture.Count;

                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 0, y + 1, z + 1), Vector3.Up, new Vector2(0, 0)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 0, y + 1, z + 0), Vector3.Up, new Vector2(0, 1)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 1, y + 1, z + 0), Vector3.Up, new Vector2(1, 1)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 1, y + 1, z + 1), Vector3.Up, new Vector2(1, 0)));

                                indices.Add(offsetIndex + 0);
                                indices.Add(offsetIndex + 1);
                                indices.Add(offsetIndex + 2);
                                indices.Add(offsetIndex + 2);
                                indices.Add(offsetIndex + 3);
                                indices.Add(offsetIndex + 0);
                            }

                            //down
                            if (GetBlock(new BlockOffset(x, y - 1, z)) is BlockAir)
                            {
                                int offsetIndex = vertexPositionNormalTexture.Count;

                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 0, y + 0, z + 1), Vector3.Down, new Vector2(0, 0)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 1, y + 0, z + 1), Vector3.Down, new Vector2(0, 1)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 1, y + 0, z + 0), Vector3.Down, new Vector2(1, 1)));
                                vertexPositionNormalTexture.Add(new VertexPositionNormalTexture(new Vector3(x + 0, y + 0, z + 0), Vector3.Down, new Vector2(1, 0)));

                                indices.Add(offsetIndex + 0);
                                indices.Add(offsetIndex + 1);
                                indices.Add(offsetIndex + 2);
                                indices.Add(offsetIndex + 2);
                                indices.Add(offsetIndex + 3);
                                indices.Add(offsetIndex + 0);
                            }
                        }
                    }
                }
            }

            if (vertexPositionNormalTexture.Count != 0)
            {
                _chunkVertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionNormalTexture), vertexPositionNormalTexture.Count, BufferUsage.None);
                _chunkVertexBuffer.SetData(vertexPositionNormalTexture.ToArray());

                _chunkIndexBuffer = new IndexBuffer(GraphicsDevice, IndexElementSize.ThirtyTwoBits, indices.Count, BufferUsage.None);
                _chunkIndexBuffer.SetData(indices.ToArray());
            }
        }
    }
}
