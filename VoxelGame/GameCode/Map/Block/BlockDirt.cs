using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Block
{
    class BlockDirt : IBlock
    {
        public BlockId GetBlockId()
        {
            return BlockId.Dirt;
        }

        public BlockTextureId GetTextureLeftId()
        {
            return BlockTextureId.Dirt;
        }

        public BlockTextureId GetTextureRightId()
        {
            return BlockTextureId.Dirt;
        }

        public BlockTextureId GetTextureTopId()
        {
            return BlockTextureId.Dirt;
        }

        public BlockTextureId GetTextureBottomId()
        {
            return BlockTextureId.Dirt;
        }

        public BlockTextureId GetTextureFrontId()
        {
            return BlockTextureId.Dirt;
        }

        public BlockTextureId GetTextureBackId()
        {
            return BlockTextureId.Dirt;
        }

        public bool IsSolid()
        {
            return true;
        }
    }
}
