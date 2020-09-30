using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace VoxelGame.Libraly.Controlers
{
    static class KeyboardEx
    {
        public static KeyboardStateEx KeyboardStateEx { get; private set; }

        static KeyboardEx()
        {
            KeyboardStateEx = new KeyboardStateEx(null, false, false);
        }

        private static KeyboardState _prevKeyboardState;
        public static void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            Dictionary<Keys, KeyStateEx> keysStates = new Dictionary<Keys, KeyStateEx>();
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                if (keyboardState.IsKeyUp(key) && _prevKeyboardState.IsKeyDown(key))
                    keysStates[key] = KeyStateEx.Pressed;
                else
                {
                    if (keyboardState.IsKeyUp(key))
                        keysStates[key] = KeyStateEx.Up;

                    if (keyboardState.IsKeyDown(key))
                        keysStates[key] = KeyStateEx.Down;
                }
            }

            KeyboardStateEx = new KeyboardStateEx(keysStates, keyboardState.CapsLock, keyboardState.NumLock);

            _prevKeyboardState = Keyboard.GetState();
        }
    }
}
