using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Block
{
    class BlockCoal : IBlock
    {
        public BlockId GetBlockId()
        {
            return BlockId.Coal;
        }

        public BlockTextureId GetTextureLeftId()
        {
            return BlockTextureId.Coal;
        }

        public BlockTextureId GetTextureRightId()
        {
            return BlockTextureId.Coal;
        }

        public BlockTextureId GetTextureTopId()
        {
            return BlockTextureId.Coal;
        }

        public BlockTextureId GetTextureBottomId()
        {
            return BlockTextureId.Coal;
        }

        public BlockTextureId GetTextureFrontId()
        {
            return BlockTextureId.Coal;
        }

        public BlockTextureId GetTextureBackId()
        {
            return BlockTextureId.Coal;
        }

        public bool IsSolid()
        {
            return true;
        }
    }
}
