using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VoxelGame.GameCode.Map.Block;
using VoxelGame.GameCode.Map.Object;
using VoxelGame.GameCode.Other;
using VoxelGame.Libraly;

namespace VoxelGame.GameCode.Map
{
    class ChunkManager : DrawableGameComponent
    {
        private readonly List<Chunk> _chunks = new List<Chunk>();
        private readonly object _lockList = new object();
        private readonly Camera _camera;
        private readonly Player _player;

        private BasicEffect _effect;
        private Texture2D _texture2D;

        private readonly Thread _thread;
        private bool _threadRun;

        public ChunkManager(Game game, Camera camera, Player player) : base(game)
        {
            _camera = camera;
            _player = player;

            _thread = new Thread(LoadTerrain);
            _threadRun = false;
        }

        public override void Initialize()
        {
            _texture2D = Game.Content.Load<Texture2D>("dirt");

            _effect = new BasicEffect(GraphicsDevice)
            {
                TextureEnabled = true,

                FogEnabled = true,
                FogColor = new Vector3(0.75F, 0.75F, 0.75F),
                FogStart = 1,
                FogEnd = GameConfig.ViewDistance * Chunk.SizeX
            };

            _effect.EnableDefaultLighting();

            _threadRun = true;
            _thread.Start();
        }

        public override void Update(GameTime gameTime)
        {
            UnloadFarDistanceChunks();

            lock (_lockList)
            {
                _chunks.ForEach(chunk => chunk.Update(gameTime));
            }
        }

        public override void Draw(GameTime gameTime)
        {
            lock (_lockList)
            {
                foreach (Chunk chunk in _chunks)
                {
                    if (!_camera.BoundingFrustum.Intersects(chunk.BoundingBox))
                        continue;

                    _effect.World = chunk.WorldMatrix;
                    _effect.View = _camera.View;
                    _effect.Projection = _camera.Projection;

                    _effect.Texture = _texture2D;

                    _effect.CurrentTechnique.Passes.First().Apply();

                    chunk.Draw(gameTime);
                }
            }
        }

        protected override void UnloadContent()
        {

        }

        public IBlock GetBlock(ChunkOffset chunkOffset, BlockOffset blockOffset)
        {
            Chunk chunk = FindChunk(chunkOffset);

            return chunk?.GetBlock(blockOffset);
        }

        public void SetBlock(ChunkOffset chunkOffset, BlockOffset blockOffset, IBlock block)
        {
            Chunk chunk = FindChunk(chunkOffset);

            chunk?.SetBlock(blockOffset, block);
        }

        private void LoadChunk(ChunkOffset chunkOffset)
        {
            Chunk chunk = new Chunk(Game, chunkOffset);
            chunk.Initialize();

            lock (_lockList)
            {
                _chunks.Add(chunk);
            }
        }

        private Chunk FindChunk(ChunkOffset chunkOffset)
        {
            lock (_lockList)
            {
                return _chunks.Find(chunk =>
                    chunk.Offset.X == chunkOffset.X &&
                    chunk.Offset.Y == chunkOffset.Y &&
                    chunk.Offset.Z == chunkOffset.Z);
            }
        }

        private readonly Semaphore _semaphore = new Semaphore(8, 8);
        private void LoadTerrain()
        {
            while (_threadRun)
            {
                for (int distance = 0; distance < GameConfig.ViewDistance; distance++)
                {
                    for (int x = CoordinateConverter.ToChunkPosition(_player.Position).X - distance; x < CoordinateConverter.ToChunkPosition(_player.Position).X + distance; x++)
                    {
                        for (int y = CoordinateConverter.ToChunkPosition(_player.Position).Y - distance; y < CoordinateConverter.ToChunkPosition(_player.Position).Y + distance; y++)
                        {
                            for (int z = CoordinateConverter.ToChunkPosition(_player.Position).Z - distance; z < CoordinateConverter.ToChunkPosition(_player.Position).Z + distance; z++)
                            {
                                ChunkOffset chunkOffset = new ChunkOffset(x, y, z);

                                if (FindChunk(chunkOffset) == null && _camera.BoundingFrustum.Intersects(new BoundingBox(
                                        new Vector3(chunkOffset.X * Chunk.SizeX, chunkOffset.Y * Chunk.SizeY, chunkOffset.Z * Chunk.SizeZ),
                                        new Vector3(chunkOffset.X * Chunk.SizeX + Chunk.SizeX, chunkOffset.Y * Chunk.SizeY + Chunk.SizeY, chunkOffset.Z * Chunk.SizeZ + Chunk.SizeZ))))
                                {
                                    _semaphore.WaitOne();

                                    ThreadPool.QueueUserWorkItem(state =>
                                    {
                                        LoadChunk(chunkOffset);
                                        _semaphore.Release();
                                    });
                                }
                            }
                        }
                    }
                }
            }
        }

        private void UnloadFarDistanceChunks()
        {
            ChunkOffset chunkOffset = CoordinateConverter.ToChunkPosition(_player.Position);

            lock (_lockList)
            {
                _chunks.RemoveAll(chunk => Math.Abs(chunkOffset.X - chunk.Offset.X) > GameConfig.ViewDistance + 1 ||
                                           Math.Abs(chunkOffset.Y - chunk.Offset.Y) > GameConfig.ViewDistance + 1 ||
                                           Math.Abs(chunkOffset.Z - chunk.Offset.Z) > GameConfig.ViewDistance + 1);
            }
        }
    }
}
