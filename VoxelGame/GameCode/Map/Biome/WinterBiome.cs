using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Biome
{
    class WinterBiome: IBiome
    {
        public BlockId FirstLayer { get; } = BlockId.Dirt;

        public BlockId SecondLayer { get; } = BlockId.Stone;

        public BlockId Fill { get; } = BlockId.Stone;
    }
}
