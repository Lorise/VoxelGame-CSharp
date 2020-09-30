using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Block
{
    class BlockIron : IBlock
    {
        public BlockId GetBlockId()
        {
            return BlockId.Iron;
        }

        public BlockTextureId GetTextureLeftId()
        {
            return BlockTextureId.Iron;
        }

        public BlockTextureId GetTextureRightId()
        {
            return BlockTextureId.Iron;
        }

        public BlockTextureId GetTextureTopId()
        {
            return BlockTextureId.Iron;
        }

        public BlockTextureId GetTextureBottomId()
        {
            return BlockTextureId.Iron;
        }

        public BlockTextureId GetTextureFrontId()
        {
            return BlockTextureId.Iron;
        }

        public BlockTextureId GetTextureBackId()
        {
            return BlockTextureId.Iron;
        }

        public bool IsSolid()
        {
            return true;
        }
    }
}
