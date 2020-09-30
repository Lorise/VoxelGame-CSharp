using Microsoft.Xna.Framework;

namespace VoxelGame.Libraly.Controlers
{
    class MouseStateEx
    {
        public Point Position { get; }
        public int ScrollWheelValue { get; }
        public ButtonStateEx LeftButton { get; }
        public ButtonStateEx RightButton { get; }
        public ButtonStateEx MiddleButton { get; }
        public ButtonStateEx XButton1 { get; }
        public ButtonStateEx XButton2 { get; }

        public MouseStateEx(
            Point position = default(Point), int scrollWheelValue = 0,
            ButtonStateEx leftButton = ButtonStateEx.Released,
            ButtonStateEx rightButton = ButtonStateEx.Released,
            ButtonStateEx middleButton = ButtonStateEx.Released,
            ButtonStateEx xButton1 = ButtonStateEx.Released,
            ButtonStateEx xButton2 = ButtonStateEx.Released)
        {
            Position = position;
            ScrollWheelValue = scrollWheelValue;
            LeftButton = leftButton;
            RightButton = rightButton;
            MiddleButton = middleButton;
            XButton1 = xButton1;
            XButton2 = xButton2;
        }
    }
}
