using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Block
{
    class BlockStone : IBlock
    {
        public BlockId GetBlockId()
        {
            return BlockId.Stone;
        }

        public BlockTextureId GetTextureLeftId()
        {
            return BlockTextureId.Stone;
        }

        public BlockTextureId GetTextureRightId()
        {
            return BlockTextureId.Stone;
        }

        public BlockTextureId GetTextureTopId()
        {
            return BlockTextureId.Stone;
        }

        public BlockTextureId GetTextureBottomId()
        {
            return BlockTextureId.Stone;
        }

        public BlockTextureId GetTextureFrontId()
        {
            return BlockTextureId.Stone;
        }

        public BlockTextureId GetTextureBackId()
        {
            return BlockTextureId.Stone;
        }

        public bool IsSolid()
        {
            return true;
        }
    }
}
