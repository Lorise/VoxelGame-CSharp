using VoxelGame.GameCode.Other;

namespace VoxelGame.GameCode.Map.Generator
{
    internal abstract class Generator
    {
        protected int Seed;

        protected Generator(int seed)
        {
            Seed = seed;
        }

        public abstract void Generate(Chunk chunk);
        public abstract void GenerateLandscape(Chunk chunk, BlockOffset blockOffset);
        public abstract void GenerateCave(Chunk chunk, BlockOffset blockOffset);
        public abstract void GenerateWater(Chunk chunk, BlockOffset blockOffset);
        public abstract void GenerateCoal(Chunk chunk, BlockOffset blockOffset);
        public abstract void GenerateIron(Chunk chunk, BlockOffset blockOffset);
        public abstract void GenerateGold(Chunk chunk, BlockOffset blockOffset);
        public abstract void GenerateDiamond(Chunk chunk, BlockOffset blockOffset);
    }
}
