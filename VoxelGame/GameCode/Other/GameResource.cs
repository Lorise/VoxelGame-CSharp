using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace VoxelGame.GameCode.Other
{
    static class GameResource
    {
        public static Texture Dirt;

        public static void Load(ContentManager contentManager)
        {
            Dirt = contentManager.Load<Texture>("dirt");
        }
    }
}
