using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VoxelGame.Libraly.ParticleEngine;
using VoxelGame.Libraly.Sprite;

namespace VoxelGame.Libraly.Setups.Particle
{
    class StarsParticle2DSetup: BasePartical2DSetup
    {
        private ParticleEngine2D _particleEngine;

        public StarsParticle2DSetup(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            List<Texture2D> textures = new List<Texture2D>
            {
                Game.Content.Load<Texture2D>("particle/star")
            };

            _particleEngine = new ParticleEngine2D(Game, textures);

            _particleEngine = new ParticleEngine2D(Game, textures);
            _particleEngine.GravitationEnabled = true;
            _particleEngine.StartVelocityMultiplyMin = -2;
            _particleEngine.StartVelocityMultiplyMax = 2;
            _particleEngine.StartLifeTimeMin = TimeSpan.FromSeconds(5);
            _particleEngine.StartLifeTimeMax = TimeSpan.FromSeconds(10);
        }

        public override void Update(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                _particleEngine.EngineEnable = true;
                _particleEngine.Position = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            }
            else
                _particleEngine.EngineEnable = false;

            _particleEngine.Update();
        }

        public override void Draw(GameTime gameTime)
        {
            _particleEngine.Draw();
        }
    }
}
