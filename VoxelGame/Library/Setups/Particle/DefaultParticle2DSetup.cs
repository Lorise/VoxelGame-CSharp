using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VoxelGame.Libraly.ParticleEngine;
using VoxelGame.Libraly.Sprite;

namespace VoxelGame.Libraly.Setups.Particle
{
    class DefaultParticle2DSetup: BasePartical2DSetup
    {
        private ParticleEngine2D _particleEngine;

        public DefaultParticle2DSetup(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            Texture2D texture = new Texture2D(GraphicsDevice, 10, 10);
            texture.SetData(Enumerable.Repeat(Color.Green, texture.Width * texture.Height).ToArray());

            _particleEngine = new ParticleEngine2D(Game, new List<Texture2D> { texture });
        }

        public override void Update(GameTime gameTime)
        {
            _particleEngine.Position = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            _particleEngine.Update();
        }

        public override void Draw(GameTime gameTime)
        {
            _particleEngine.Draw();
        }
    }
}
