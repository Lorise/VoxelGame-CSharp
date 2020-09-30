using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Block
{
    class BlockWater : IBlock
    {
        public BlockId GetBlockId()
        {
            return BlockId.Water;
        }

        public BlockTextureId GetTextureLeftId()
        {
            return BlockTextureId.Water;
        }

        public BlockTextureId GetTextureRightId()
        {
            return BlockTextureId.Water;
        }

        public BlockTextureId GetTextureTopId()
        {
            return BlockTextureId.Water;
        }

        public BlockTextureId GetTextureBottomId()
        {
            return BlockTextureId.Water;
        }

        public BlockTextureId GetTextureFrontId()
        {
            return BlockTextureId.Water;
        }

        public BlockTextureId GetTextureBackId()
        {
            return BlockTextureId.Water;
        }

        public bool IsSolid()
        {
            return false;
        }
    }
}
