using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Block
{
    class BlockBedrock : IBlock
    {
        public BlockId GetBlockId()
        {
            return BlockId.Bedrock;
        }

        public BlockTextureId GetTextureLeftId()
        {
            return BlockTextureId.Bedrock;
        }

        public BlockTextureId GetTextureRightId()
        {
            return BlockTextureId.Bedrock;
        }

        public BlockTextureId GetTextureTopId()
        {
            return BlockTextureId.Bedrock;
        }

        public BlockTextureId GetTextureBottomId()
        {
            return BlockTextureId.Bedrock;
        }

        public BlockTextureId GetTextureFrontId()
        {
            return BlockTextureId.Bedrock;
        }

        public BlockTextureId GetTextureBackId()
        {
            return BlockTextureId.Bedrock;
        }

        public bool IsSolid()
        {
            return true;
        }
    }
}
