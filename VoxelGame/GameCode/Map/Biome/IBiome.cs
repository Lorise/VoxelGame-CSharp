using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Biome
{
    interface IBiome
    {
        BlockId FirstLayer { get; }

        BlockId SecondLayer { get; }

        BlockId Fill { get; }
    }
}
