using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Block
{
    interface IBlock
    {
        BlockId GetBlockId();

        BlockTextureId GetTextureLeftId();
        BlockTextureId GetTextureRightId();
        BlockTextureId GetTextureTopId();
        BlockTextureId GetTextureBottomId();
        BlockTextureId GetTextureFrontId();
        BlockTextureId GetTextureBackId();

        bool IsSolid();
    }
}
