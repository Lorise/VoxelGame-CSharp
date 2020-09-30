using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Biome
{
    class DesertBiome: IBiome
    {
        public BlockId FirstLayer { get; } = BlockId.Sand;

        public BlockId SecondLayer { get; } = BlockId.Sandstone;

        public BlockId Fill { get; } = BlockId.Stone;
    }
}
