using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Block
{
    class BlockCobblestone : IBlock
    {
        public BlockId GetBlockId()
        {
            return BlockId.Cobblestone;
        }

        public BlockTextureId GetTextureLeftId()
        {
            return BlockTextureId.Cobblestone;
        }

        public BlockTextureId GetTextureRightId()
        {
            return BlockTextureId.Cobblestone;
        }

        public BlockTextureId GetTextureTopId()
        {
            return BlockTextureId.Cobblestone;
        }

        public BlockTextureId GetTextureBottomId()
        {
            return BlockTextureId.Cobblestone;
        }

        public BlockTextureId GetTextureFrontId()
        {
            return BlockTextureId.Cobblestone;
        }

        public BlockTextureId GetTextureBackId()
        {
            return BlockTextureId.Cobblestone;
        }

        public bool IsSolid()
        {
            return true;
        }
    }
}
