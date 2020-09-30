using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Block
{
    class BlockAir : IBlock
    {
        public BlockId GetBlockId()
        {
            return BlockId.Air;
        }

        public BlockTextureId GetTextureLeftId()
        {
            return BlockTextureId.None;
        }

        public BlockTextureId GetTextureRightId()
        {
            return BlockTextureId.None;
        }

        public BlockTextureId GetTextureTopId()
        {
            return BlockTextureId.None;
        }

        public BlockTextureId GetTextureBottomId()
        {
            return BlockTextureId.None;
        }

        public BlockTextureId GetTextureFrontId()
        {
            return BlockTextureId.None;
        }

        public BlockTextureId GetTextureBackId()
        {
            return BlockTextureId.None;
        }

        public bool IsSolid()
        {
            return false;
        }
    }
}
