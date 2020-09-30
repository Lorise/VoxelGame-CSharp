using Microsoft.Xna.Framework.Input;

namespace VoxelGame.GameCode.Other
{
    static class Control
    {
        public static Keys MoveFront { get; set; } = Keys.W;
        public static Keys MoveBack { get; set; } = Keys.S;
        public static Keys MoveLeft { get; set; } = Keys.A;
        public static Keys MoveRight { get; set; } = Keys.D;
        public static Keys MoveUp { get; set; } = Keys.R;
        public static Keys MoveDown { get; set; } = Keys.F;
        public static Keys Jump { get; set; } = Keys.Space;
    }
}
