using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using VoxelGame.GameCode.Other;

namespace VoxelGame.Libraly
{
    class Camera : GameComponent
    {
        public Matrix View { get; protected set; }
        public Matrix Projection { get; protected set; }
        public Matrix ViewProjection => View * Projection;

        public BoundingFrustum BoundingFrustum;

        public Vector3 CameraPosition { get; set; }
        Vector3 _cameraDirection;
        Vector3 _cameraUp;

        //defines speed of camera movement
        float _speed = 0.5F;

        MouseState _prevMouseState;

        public Camera(Game game, Vector3 pos, Vector3 target, Vector3 up) : base(game)
        {
            // Build camera view matrix
            CameraPosition = pos;
            _cameraDirection = target - pos;
            _cameraDirection.Normalize();
            _cameraUp = up;
            CreateLookAt();

            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Game.Window.ClientBounds.Width / (float)Game.Window.ClientBounds.Height, 1, 1000);

            BoundingFrustum = new BoundingFrustum(ViewProjection);
        }

        public override void Initialize()
        {
            // Set mouse position and do initial get state
            Mouse.SetPosition(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 2);

            _prevMouseState = Mouse.GetState();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Control.MoveFront))
                CameraPosition += _cameraDirection * _speed;

            if (Keyboard.GetState().IsKeyDown(Control.MoveBack))
                CameraPosition -= _cameraDirection * _speed;

            if (Keyboard.GetState().IsKeyDown(Control.MoveLeft))
                CameraPosition += Vector3.Cross(_cameraUp, _cameraDirection) * _speed;

            if (Keyboard.GetState().IsKeyDown(Control.MoveRight))
                CameraPosition -= Vector3.Cross(_cameraUp, _cameraDirection) * _speed;

            if (Keyboard.GetState().IsKeyDown(Control.MoveUp))
                CameraPosition += _cameraUp * _speed;

            if (Keyboard.GetState().IsKeyDown(Control.MoveDown))
                CameraPosition -= _cameraUp * _speed;

            // Rotation in the world
            _cameraDirection = Vector3.Transform(_cameraDirection, Matrix.CreateFromAxisAngle(_cameraUp, (-MathHelper.PiOver4 / 150) * (Mouse.GetState().X - _prevMouseState.X)));
            _cameraDirection = Vector3.Transform(_cameraDirection, Matrix.CreateFromAxisAngle(Vector3.Cross(_cameraUp, _cameraDirection), (MathHelper.PiOver4 / 100) * (Mouse.GetState().Y - _prevMouseState.Y)));

            // Reset prevMouseState
            Mouse.SetPosition(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 2);
            _prevMouseState = Mouse.GetState();

            CreateLookAt();

            BoundingFrustum.Matrix = ViewProjection;

            base.Update(gameTime);
        }

        private void CreateLookAt()
        {
            View = Matrix.CreateLookAt(CameraPosition, CameraPosition + _cameraDirection, _cameraUp);
        }
    }
}
