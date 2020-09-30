using Microsoft.Xna.Framework;
using VoxelGame.GameCode.Map;
using VoxelGame.GameCode.Map.Object;

namespace VoxelGame.GameCode.GameState.State
{
    class PlayGame : BaseGameState
    {
        private readonly Player _player;
        private readonly World _world;

        public PlayGame(Game game) : base(game)
        {
            _player = new Player(game);
            _world = new World(game, _player.Camera, _player);
        }

        public override void Initialize()
        {
            _world.Initialize();
            _player.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _world.Update(gameTime);
            _player.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _world.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            
        }
    }
}
