using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Block
{
    class BlockGold : IBlock
    {
        public BlockId GetBlockId()
        {
            return BlockId.Gold;
        }

        public BlockTextureId GetTextureLeftId()
        {
            return BlockTextureId.Gold;
        }

        public BlockTextureId GetTextureRightId()
        {
            return BlockTextureId.Gold;
        }

        public BlockTextureId GetTextureTopId()
        {
            return BlockTextureId.Gold;
        }

        public BlockTextureId GetTextureBottomId()
        {
            return BlockTextureId.Gold;
        }

        public BlockTextureId GetTextureFrontId()
        {
            return BlockTextureId.Gold;
        }

        public BlockTextureId GetTextureBackId()
        {
            return BlockTextureId.Gold;
        }

        public bool IsSolid()
        {
            return true;
        }
    }
}
