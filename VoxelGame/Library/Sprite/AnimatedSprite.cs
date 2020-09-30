using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VoxelGame.Libraly.Sprite
{
    class AnimatedSprite : ISprite
    {
        private readonly Texture2D _texture;
        private readonly int _columns;
        private readonly int _rows;
        private SpriteEffects _spriteEffects;

        private readonly int _widthFrame;
        private readonly int _heightFrame;

        private int _currentFrame;
        private readonly int _totalFrames;

        public Vector2 Position { get; set; }
        public int Fps { get; set; }
        public bool FlipHorisontaly { get; set; }
        public bool FlipVerticaly { get; set; }
        public Vector2 RorationPoint { get; set; }
        public float Rotatinon { get; set; }

        public AnimatedSprite(Texture2D texture, int columns, int rows, int fps = 1)
        {
            _texture = texture;
            _columns = columns;
            _rows = rows;
            _spriteEffects = SpriteEffects.None;

            _widthFrame = _texture.Width / _columns;
            _heightFrame = _texture.Height / _rows;

            _currentFrame = 0;
            _totalFrames = _rows * _columns;

            Position = Vector2.Zero;
            Fps = fps;
            FlipHorisontaly = false;
            FlipVerticaly = false;
            RorationPoint = new Vector2(_widthFrame / 2, _heightFrame / 2);
            Rotatinon = 0;
        }

        private TimeSpan _prevFrameTime = DateTime.Now.TimeOfDay;
        public void Update()
        {
            if (DateTime.Now.TimeOfDay - _prevFrameTime < TimeSpan.FromMilliseconds(1000 / Fps))
                return;

            _prevFrameTime = DateTime.Now.TimeOfDay;

            _spriteEffects = SpriteEffects.None;
            if (FlipHorisontaly)
                _spriteEffects |= SpriteEffects.FlipHorizontally;
            if (FlipVerticaly)
                _spriteEffects |= SpriteEffects.FlipVertically;

            _currentFrame++;

            if (_currentFrame == _totalFrames)
                _currentFrame = 0;

            Console.WriteLine(_currentFrame);
        }

        public void Draw()
        {
            int column = _currentFrame % _columns;
            int row = _currentFrame / _columns;

            Rectangle sourceRectangle = new Rectangle(column * _widthFrame, row * _heightFrame, _widthFrame, _heightFrame);
            Rectangle destinationRectangle = new Rectangle((int) Position.X, (int) Position.Y, _widthFrame, _heightFrame);

            Game1.SpriteBatch.Begin();
            Game1.SpriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White, Rotatinon, RorationPoint, _spriteEffects, 1);
            Game1.SpriteBatch.End();
        }
    }
}
