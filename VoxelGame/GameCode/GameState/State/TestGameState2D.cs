using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VoxelGame.Libraly.Setups.Particle;
using VoxelGame.Libraly.Sprite;

namespace VoxelGame.GameCode.GameState.State
{
    class TestGameState2D : BaseGameState
    {
        private readonly BasePartical2DSetup _starParticleSetup;
        private readonly BasePartical2DSetup _defaultParticleSetup;

        private AnimatedSprite _animatedSprite;

        public TestGameState2D(Game game) : base(game)
        {
            _defaultParticleSetup = new DefaultParticle2DSetup(game);
            _starParticleSetup = new StarsParticle2DSetup(game);
        }

        public override void Initialize()
        {
            _defaultParticleSetup.Initialize();
            _starParticleSetup.Initialize();

            _animatedSprite = new AnimatedSprite(Game.Content.Load<Texture2D>("cat"), 2, 4, 24);
            _animatedSprite.Position = Game.Window.ClientBounds.Center.ToVector2();
        }

        public override void Update(GameTime gameTime)
        {
            _defaultParticleSetup.Update(gameTime);
            _starParticleSetup.Update(gameTime);

            _animatedSprite.Update();

            float speed = 3;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                _animatedSprite.Position -= Vector2.UnitX * speed;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                _animatedSprite.Position += Vector2.UnitX * speed;

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                _animatedSprite.Position -= Vector2.UnitY * speed;

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                _animatedSprite.Position += Vector2.UnitY * speed;
        }

        public override void Draw(GameTime gameTime)
        {
            _defaultParticleSetup.Draw(gameTime);
            _starParticleSetup.Draw(gameTime);

            _animatedSprite.Draw();
        }
    }
}
