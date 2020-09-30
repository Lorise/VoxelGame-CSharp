using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using VoxelGame.Libraly;
using VoxelGame.Libraly.Controlers;
using Control = VoxelGame.GameCode.Other.Control;

namespace VoxelGame.GameCode.Map.Object
{
    class Player : GameComponent
    {
        public Vector3 Position => Camera.CameraPosition;
        private float _speed;

        public Camera Camera { get; }

        public Player(Game game) : base(game)
        {
            _speed = 1;

            Camera = new Camera(game, new Vector3(0, 0, -1), new Vector3(0, 0, 0), Vector3.Up);
        }

        public override void Initialize()
        {
            Camera.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Control.Jump))
                Jump();

            if (MouseEx.MouseStateEx.LeftButton == ButtonStateEx.Pressed)
            {
                Camera.Update(gameTime);
            }
        }

        public void Jump()
        {

        }
    }
}
