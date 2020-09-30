using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VoxelGame.Libraly.ParticleEngine
{
    class ParticleEngine2D : DrawableGameComponent
    {
        private readonly List<Particle2D> _particles;
        private readonly List<Texture2D> _textures;
        
        //particle engine config
        public TimeSpan CreateTime { get; }
        public Vector2 Position { get; set; }
        public bool EngineEnable { get; set; }
        public TimeSpan Delay { get; set; }
        public bool GravitationEnabled { get; set; }
        public Vector2 GravitationVector { get; set; }
        public float GravitationMultiply { get; set; }
        public int ParticleSpawnCount { get; set; }
        
        //spawn particle config
        public TimeSpan StartLifeTimeMin { get; set; }
        public TimeSpan StartLifeTimeMax { get; set; }
        public float StartVelocityMultiplyMin { get; set; }
        public float StartVelocityMultiplyMax { get; set; }
        public float StartAngleMin { get; set; }
        public float StartAngleMax { get; set; }
        public float StartAngularVelocityMin { get; set; }
        public float StartAngularVelocityMax { get; set; }
        public float StartScaleMin { get; set; }
        public float StartScaleMax { get; set; }

        public ParticleEngine2D(Game game, List<Texture2D> textures) : base(game)
        {
            _particles = new List<Particle2D>();
            _textures = textures;

            //particle engine config
            CreateTime = DateTime.Now.TimeOfDay;
            Position = Vector2.Zero;
            EngineEnable = true;
            Delay = TimeSpan.Zero;
            GravitationEnabled = false;
            GravitationVector = Vector2.UnitY;
            GravitationMultiply = 1;
            ParticleSpawnCount = 10;

            //spawn particle config
            StartLifeTimeMin = TimeSpan.FromSeconds(1);
            StartLifeTimeMax = TimeSpan.FromSeconds(3);
            StartVelocityMultiplyMin = -1;
            StartVelocityMultiplyMax = 1;
            StartAngleMin = 0;
            StartAngleMax = 0;
            StartAngularVelocityMin = -0.1F;
            StartAngularVelocityMax = 0.1F;
            StartScaleMin = 0;
            StartScaleMax = 1;
        }

        public override void Initialize()
        {

        }

        public void Update()
        {
            if (EngineEnable)
            {
                if (DateTime.Now.TimeOfDay - CreateTime > Delay)
                {
                    for (int i = 0; i < ParticleSpawnCount; i++)
                        _particles.Add(SpawnParticle());
                }
            }

            for (int i = 0; i < _particles.Count; i++)
            {
                _particles[i].Update();
                if (GravitationEnabled)
                {
                    float particalLifeTime = (float) (_particles[i].LivedTime.TotalMilliseconds / 1000);
                    _particles[i].Position += GravitationVector * GravitationMultiply * particalLifeTime;
                }

                if (_particles[i].LivedTime > _particles[i].LifeTime)
                {
                    _particles.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Draw()
        {
            Game1.SpriteBatch.Begin();

            foreach (Particle2D particle in _particles)
                particle.Draw();

            Game1.SpriteBatch.End();
        }

        private readonly RandomEx _randomEx = new RandomEx();
        private Particle2D SpawnParticle()
        {
            Particle2D particle = new Particle2D(_textures[_randomEx.Next(_textures.Count)])
            {
                LifeTime = TimeSpan.FromSeconds(_randomEx.Next((int) StartLifeTimeMin.TotalSeconds, (int) StartLifeTimeMax.TotalSeconds)),
                Position = Position,
                Velocity = new Vector2(_randomEx.NextFloat(StartVelocityMultiplyMin, StartVelocityMultiplyMax), _randomEx.NextFloat(StartVelocityMultiplyMin, StartVelocityMultiplyMax)),
                Angle = _randomEx.NextFloat(StartAngleMin, StartAngleMax),
                AngularVelocity = _randomEx.NextFloat(StartAngularVelocityMin, StartAngularVelocityMax),
                Scale = _randomEx.NextFloat(StartScaleMin, StartScaleMax)
            };

            return particle;
        }
    }
}
