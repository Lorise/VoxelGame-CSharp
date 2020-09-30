using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Block
{
    class BlockDiamond : IBlock
    {
        public BlockId GetBlockId()
        {
            return BlockId.Diamond;
        }

        public BlockTextureId GetTextureLeftId()
        {
            return BlockTextureId.Diamond;
        }

        public BlockTextureId GetTextureRightId()
        {
            return BlockTextureId.Diamond;
        }

        public BlockTextureId GetTextureTopId()
        {
            return BlockTextureId.Diamond;
        }

        public BlockTextureId GetTextureBottomId()
        {
            return BlockTextureId.Diamond;
        }

        public BlockTextureId GetTextureFrontId()
        {
            return BlockTextureId.Diamond;
        }

        public BlockTextureId GetTextureBackId()
        {
            return BlockTextureId.Diamond;
        }

        public bool IsSolid()
        {
            return true;
        }
    }
}
