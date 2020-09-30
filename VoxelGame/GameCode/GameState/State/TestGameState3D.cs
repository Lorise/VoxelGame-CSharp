using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VoxelGame.GameCode.Map;
using VoxelGame.GameCode.Map.Object;
using VoxelGame.GameCode.Other;
using VoxelGame.Libraly;
using VoxelGame.Libraly.Controlers;

namespace VoxelGame.GameCode.GameState.State
{
    class TestGameState3D : BaseGameState
    {
        private readonly Player _player;

        private VertexBuffer _vertexBuffer;
        private IndexBuffer _indexBuffer;

        private BasicEffect _basicEffect;

        public TestGameState3D(Game game) : base(game)
        {
            _player = new Player(game);
            _player.Camera.CameraPosition = new Vector3(0, 10, -100);
        }

        public override void Initialize()
        {
            _player.Initialize();

            _basicEffect = new BasicEffect(GraphicsDevice)
            {
                VertexColorEnabled = true,

                FogEnabled = true,
                FogColor = new Vector3(0.75F, 0.75F, 0.75F),
                FogStart = 1,
                FogEnd = GameConfig.ViewDistance * Chunk.SizeX
            };

            int quadSize = 100;

            _vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 4, BufferUsage.None);
            _vertexBuffer.SetData(new[]
            {
                new VertexPositionColor(new Vector3(-quadSize, 0, -quadSize), Color.Red),
                new VertexPositionColor(new Vector3(quadSize, 0, -quadSize), Color.Green),
                new VertexPositionColor(new Vector3(quadSize, 0, quadSize), Color.Blue),
                new VertexPositionColor(new Vector3(-quadSize, 0, quadSize), Color.Yellow)
            });

            _indexBuffer = new IndexBuffer(GraphicsDevice, IndexElementSize.SixteenBits, 6, BufferUsage.None);
            _indexBuffer.SetData(new short[] { 0, 1, 2, 2, 3, 0 });
        }

        public override void Update(GameTime gameTime)
        {
            _player.Update(new GameTime());

            Console.WriteLine(KeyboardEx.KeyboardStateEx.KeyStates[Keys.W]);
        }

        public override void Draw(GameTime gameTime)
        {
            _basicEffect.View = _player.Camera.View;
            _basicEffect.Projection = _player.Camera.Projection;
            _basicEffect.CurrentTechnique.Passes.First().Apply();

            GraphicsDevice.Indices = _indexBuffer;
            GraphicsDevice.SetVertexBuffer(_vertexBuffer);
            GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 2);
        }
    }
}
