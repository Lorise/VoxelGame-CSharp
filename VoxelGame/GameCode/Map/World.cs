using Microsoft.Xna.Framework;
using VoxelGame.GameCode.Map.Object;
using VoxelGame.GameCode.Other;
using VoxelGame.Libraly;

namespace VoxelGame.GameCode.Map
{
    class World : DrawableGameComponent
    {
        private readonly ChunkManager _chunkManager;
        private readonly Camera _camera;

        public World(Game game, Camera camera, Player player) : base(game)
        {
            _chunkManager = new ChunkManager(game, camera, player);
            _camera = camera;
        }

        public override void Initialize()
        {
            _chunkManager.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _chunkManager.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _chunkManager.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
        }
    }
}
