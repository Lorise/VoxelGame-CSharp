using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace VoxelGame.Libraly.Sprite
{
    class SpriteManager : DrawableGameComponent
    {
        private readonly List<ISprite> _sprites;

        public SpriteManager(Game game) : base(game)
        {
            _sprites = new List<ISprite>();
        }

        public override void Initialize()
        {
        }

        public override void Update(GameTime gameTime)
        {
            foreach (ISprite sprite in _sprites)
            {
                //sprite.Update();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (ISprite sprite in _sprites)
            {
                sprite.Draw();
            }
        }

        public void Add(ISprite sprite)
        {
            _sprites.Add(sprite);
        }

        public void Clear()
        {
            _sprites.Clear();
        }
    }
}
