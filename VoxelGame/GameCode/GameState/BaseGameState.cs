using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace VoxelGame.GameCode.GameState
{
    abstract class BaseGameState: DrawableGameComponent, IGameState
    {
        protected BaseGameState(Game game) : base(game)
        {
        }
    }
}
