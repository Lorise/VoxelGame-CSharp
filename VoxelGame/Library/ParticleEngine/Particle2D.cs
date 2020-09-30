using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VoxelGame.Libraly.ParticleEngine
{
    class Particle2D
    {
        private readonly Texture2D _texture;

        public TimeSpan Birthday { get; }
        public TimeSpan LifeTime { get; set; }
        public TimeSpan LivedTime => DateTime.Now.TimeOfDay - Birthday;
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Angle { get; set; }
        public float AngularVelocity { get; set; }

        private float _scale;
        public float Scale
        {
            get => _scale;
            set => _scale = value < 0.01 ? 0.01F : value;
        }

        public Particle2D(Texture2D texture)
        {
            _texture = texture;

            Birthday = DateTime.Now.TimeOfDay;
            LifeTime = TimeSpan.FromSeconds(1);
            Position = Vector2.Zero;
            Velocity = Vector2.Zero;
            Angle = 0;
            AngularVelocity = 0;
            Scale = 1;
        }

        public void Update()
        {
            Position += Velocity;
            Angle += AngularVelocity;
        }

        public void Draw()
        {
            Game1.SpriteBatch.Draw(_texture, Position, _texture.Bounds, Color.White, Angle, _texture.Bounds.Center.ToVector2(), Scale, SpriteEffects.None, 0);
        }
    }
}
