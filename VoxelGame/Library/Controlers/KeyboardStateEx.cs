using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace VoxelGame.Libraly.Controlers
{
    class KeyboardStateEx
    {
        public Dictionary<Keys, KeyStateEx> KeyStates { get; }
        public bool CapsLock { get; }
        public bool NumLock { get; }

        public KeyboardStateEx(Dictionary<Keys, KeyStateEx> keysState, bool capsLock, bool numLock)
        {
            KeyStates = keysState;

            CapsLock = capsLock;
            NumLock = numLock;
        }

        public KeyStateEx GetKeyState(Keys key) => KeyStates[key];

        public bool IsKeyDown(Keys key) => KeyStates[key] == KeyStateEx.Down;

        public bool IsKeyUp(Keys key) => KeyStates[key] == KeyStateEx.Up;

        public bool IsKeyPressed(Keys key) => KeyStates[key] == KeyStateEx.Pressed;
    }
}
