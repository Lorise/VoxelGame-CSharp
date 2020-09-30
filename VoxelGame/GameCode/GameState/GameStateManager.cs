using Microsoft.Xna.Framework;
using VoxelGame.GameCode.GameState.State;

namespace VoxelGame.GameCode.GameState
{
    class GameStateManager : DrawableGameComponent
    {
        private readonly BaseGameState _gameState;

        public GameStateManager(Game game) : base(game)
        {
            _gameState = new PlayGame(game);
        }

        public override void Initialize()
        {
            _gameState.Initialize();
        }

        protected override void LoadContent()
        {
        }

        protected override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            _gameState.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _gameState.Draw(gameTime);
        }
    }
}
