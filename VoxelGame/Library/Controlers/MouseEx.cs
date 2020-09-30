using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace VoxelGame.Libraly.Controlers
{
    static class MouseEx
    {
        public static IntPtr WindowHandle => Mouse.WindowHandle;
        public static MouseStateEx MouseStateEx;

        static MouseEx()
        {
            MouseStateEx = new MouseStateEx();
        }

        public static void SetPosition(Point point) => Mouse.SetPosition(point.X, point.Y);

        public static void SetCursor(MouseCursor mouseCursor) => Mouse.SetCursor(mouseCursor);

        public static void PlatformSetCursor(MouseCursor mouseCursor) => Mouse.PlatformSetCursor(mouseCursor);

        private static MouseState _prevMouseState;
        public static void Update()
        {
            MouseState mouseState = Mouse.GetState();

            ButtonStateEx leftButton;
            if (mouseState.LeftButton == ButtonState.Released && _prevMouseState.LeftButton == ButtonState.Pressed)
                leftButton = ButtonStateEx.Clicked;
            else
            {
                switch (mouseState.LeftButton)
                {
                    case ButtonState.Released:
                        leftButton = ButtonStateEx.Released;
                        break;
                    case ButtonState.Pressed:
                        leftButton = ButtonStateEx.Pressed;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }

            ButtonStateEx rightButton;
            if (mouseState.RightButton == ButtonState.Released && _prevMouseState.RightButton == ButtonState.Pressed)
                rightButton = ButtonStateEx.Clicked;
            else
            {
                switch (mouseState.RightButton)
                {
                    case ButtonState.Released:
                        rightButton = ButtonStateEx.Released;
                        break;
                    case ButtonState.Pressed:
                        rightButton = ButtonStateEx.Pressed;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }

            ButtonStateEx middleButton;
            if (mouseState.MiddleButton == ButtonState.Released && _prevMouseState.MiddleButton == ButtonState.Pressed)
                middleButton = ButtonStateEx.Clicked;
            else
            {
                switch (mouseState.MiddleButton)
                {
                    case ButtonState.Released:
                        middleButton = ButtonStateEx.Released;
                        break;
                    case ButtonState.Pressed:
                        middleButton = ButtonStateEx.Pressed;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }

            ButtonStateEx xButton1;
            if (mouseState.XButton1 == ButtonState.Released && _prevMouseState.XButton1 == ButtonState.Pressed)
                xButton1 = ButtonStateEx.Clicked;
            else
            {
                switch (mouseState.XButton1)
                {
                    case ButtonState.Released:
                        xButton1 = ButtonStateEx.Released;
                        break;
                    case ButtonState.Pressed:
                        xButton1 = ButtonStateEx.Pressed;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }

            ButtonStateEx xButton2;
            if (mouseState.XButton2 == ButtonState.Released && _prevMouseState.XButton2 == ButtonState.Pressed)
                xButton2 = ButtonStateEx.Clicked;
            else
            {
                switch (mouseState.XButton2)
                {
                    case ButtonState.Released:
                        xButton2 = ButtonStateEx.Released;
                        break;
                    case ButtonState.Pressed:
                        xButton2 = ButtonStateEx.Pressed;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }

            MouseStateEx = new MouseStateEx(new Point(mouseState.X, mouseState.Y), mouseState.ScrollWheelValue, leftButton, rightButton, middleButton, xButton1, xButton2);

            _prevMouseState = Mouse.GetState();
        }
    }
}
