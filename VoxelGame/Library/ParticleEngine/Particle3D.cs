using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VoxelGame.Libraly.ParticleEngine
{
    class Particle3D
    {
        private readonly Texture2D _texture;

        public TimeSpan Birthday { get; }
        public TimeSpan LifeTime { get; set; }
        public TimeSpan LivedTime => DateTime.Now.TimeOfDay - Birthday;
        public Vector3 Position { get; set; }
        public Vector3 Velocity { get; set; }
        public Vector3 Angle { get; set; }
        public Vector3 AngularVelocity { get; set; }

        private float _scale;
        public float Scale
        {
            get => _scale;
            set => _scale = value < 0.01 ? 0.01F : value;
        }

        public Particle3D(Texture2D texture)
        {
            _texture = texture;
            
            Birthday = DateTime.Now.TimeOfDay;
            LifeTime = TimeSpan.FromSeconds(1);
            Position = Vector3.Zero;
            Velocity = Vector3.Zero;
            Angle = Vector3.Zero;
            AngularVelocity = Vector3.Zero;
            Scale = 1;
        }

        public void Update()
        {
            Position += Velocity;
            Angle += AngularVelocity;
        }

        public void Draw()
        {

        }
    }
}
