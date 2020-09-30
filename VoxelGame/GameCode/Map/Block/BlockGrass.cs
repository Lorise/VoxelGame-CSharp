using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Block
{
    class BlockGrass : IBlock
    {
        public BlockId GetBlockId()
        {
            return BlockId.Grass;
        }

        public BlockTextureId GetTextureLeftId()
        {
            return BlockTextureId.GrassSide;
        }

        public BlockTextureId GetTextureRightId()
        {
            return BlockTextureId.GrassSide;
        }

        public BlockTextureId GetTextureTopId()
        {
            return BlockTextureId.Grass;
        }

        public BlockTextureId GetTextureBottomId()
        {
            return BlockTextureId.Dirt;
        }

        public BlockTextureId GetTextureFrontId()
        {
            return BlockTextureId.GrassSide;
        }

        public BlockTextureId GetTextureBackId()
        {
            return BlockTextureId.GrassSide;
        }

        public bool IsSolid()
        {
            return true;
        }
    }
}
