using Microsoft.Xna.Framework;
using VoxelGame.GameCode.Map.Block;
using VoxelGame.GameCode.Other;
using VoxelGame.Libraly;

namespace VoxelGame.GameCode.Map.Generator
{
    class BaseGenerator : Generator
    {
        private readonly FastNoise _noiseLandscape;
        private readonly FastNoise _heightGain;
        private readonly int _landScapeHeight;

        private readonly FastNoise _noiseCave;
        private readonly float _shearCaveMin;
        private readonly float _shearCaveMax;

        private readonly FastNoise _noiseCoal;
        private readonly int _minHeightCoal;
        private readonly int _maxHeightCoal;
        private readonly float _shearCoalMin;
        private readonly float _shearCoalMax;

        private readonly FastNoise _noiseIron;
        private readonly int _minHeightIron;
        private readonly int _maxHeightIron;
        private readonly float _shearIronMin;
        private readonly float _shearIronMax;

        private readonly FastNoise _noiseGold;
        private readonly int _minHeightGold;
        private readonly int _maxHeightGold;
        private readonly float _shearGoldMin;
        private readonly float _shearGoldMax;

        private readonly FastNoise _noiseDiamond;
        private readonly int _minHeightDiamond;
        private readonly int _maxHeightDiamond;
        private readonly float _shearDiamondMin;
        private readonly float _shearDiamondMax;

        public BaseGenerator() : base(1333)
        {
            _noiseLandscape = new FastNoise(Seed);
            _noiseLandscape.SetFrequency(0.01F);
            _heightGain = new FastNoise(Seed);
            _landScapeHeight = 64;

            _noiseCave = new FastNoise(Seed);
            _noiseCave.SetFrequency(0.05F);
            _shearCaveMin = 0.3F;
            _shearCaveMax = 0.7F;

            _noiseCoal = new FastNoise(Seed + 1);
            _noiseCoal.SetFrequency(0.2F);
            _minHeightCoal = 5;
            _maxHeightCoal = 55;
            _shearCoalMin = 0.45F;
            _shearCoalMax = 0.55F;

            _noiseIron = new FastNoise(Seed + 2);
            _noiseIron.SetFrequency(0.2F);
            _minHeightIron = 10;
            _maxHeightIron = 95;
            _shearIronMin = 0.45F;
            _shearIronMax = 0.55F;

            _noiseGold = new FastNoise(Seed + 3);
            _noiseGold.SetFrequency(0.2F);
            _minHeightGold = 80;
            _maxHeightGold = 120;
            _shearGoldMin = 0.45F;
            _shearGoldMax = 0.55F;

            _noiseDiamond = new FastNoise(Seed + 4);
            _noiseDiamond.SetFrequency(0.2F);
            _minHeightDiamond = 100;
            _maxHeightDiamond = 120;
            _shearDiamondMin = 0.45F;
            _shearDiamondMax = 0.55F;
        }

        public override void Generate(Chunk chunk)
        {
            for (int x = 0; x < Chunk.SizeX; x++)
            {
                for (int y = 0; y < Chunk.SizeY; y++)
                {
                    for (int z = 0; z < Chunk.SizeZ; z++)
                    {
                        BlockOffset blockOffset = new BlockOffset(x, y, z);

                        GenerateLandscape(chunk, blockOffset);

                        GenerateCoal(chunk, blockOffset);
                        GenerateIron(chunk, blockOffset);
                        GenerateGold(chunk, blockOffset);
                        GenerateDiamond(chunk, blockOffset);

                        GenerateCave(chunk, blockOffset);

                        GenerateWater(chunk, blockOffset);
                    }
                }
            }
        }

        public override void GenerateLandscape(Chunk chunk, BlockOffset blockOffset)
        {
            Vector3 coord = chunk.GetAbsPosition(blockOffset);

            float height = _landScapeHeight - _noiseLandscape.GetSimplexFractal(coord.X, coord.Z) * (_heightGain.GetSimplexFractal(coord.X, coord.Z) * 50);

            IBlock block = new BlockAir();

            if (coord.Y <= height)
                block = new BlockGrass();

            if ((coord.Y <= height - 1) && (coord.Y > height - 5))
                block = new BlockDirt();

            if (coord.Y <= height - 5)
                block = new BlockStone();

            chunk.SetBlock(blockOffset, block);
        }

        public override void GenerateCave(Chunk chunk, BlockOffset blockOffset)
        {
            Vector3 coord = chunk.GetAbsPosition(blockOffset);

            float n = _noiseCave.GetPerlin(coord.X, coord.Y, coord.Z);

            if (n < _shearCaveMax && n > _shearCaveMin)
                chunk.SetBlock(blockOffset, new BlockAir());
        }

        public override void GenerateWater(Chunk chunk, BlockOffset blockOffset)
        {
            Vector3 coord = chunk.GetAbsPosition(blockOffset);

            IBlock block = chunk.GetBlock(blockOffset);

            if (block is BlockAir && coord.Y == 79995)
                chunk.SetBlock(blockOffset, new BlockWater());
        }

        public override void GenerateCoal(Chunk chunk, BlockOffset blockOffset)
        {
            Vector3 coord = chunk.GetAbsPosition(blockOffset);

            float height = _landScapeHeight - _noiseLandscape.GetSimplexFractal(coord.X, coord.Z) * (_heightGain.GetSimplexFractal(coord.X, coord.Z) * 50);
            float n = _noiseCoal.GetPerlin(coord.X, coord.Y, coord.Z);

            if (coord.Y <= height - _minHeightCoal && coord.Y > height - _maxHeightCoal &&
                n < _shearCoalMax && n > _shearCoalMin)
                chunk.SetBlock(blockOffset, new BlockCoal());
        }

        public override void GenerateIron(Chunk chunk, BlockOffset blockOffset)
        {
            Vector3 coord = chunk.GetAbsPosition(blockOffset);

            float height = _landScapeHeight - _noiseLandscape.GetSimplexFractal(coord.X, coord.Z) * (_heightGain.GetSimplexFractal(coord.X, coord.Z) * 50);
            float n = _noiseIron.GetPerlin(coord.X, coord.Y, coord.Z);

            if (coord.Y <= height - _minHeightIron && coord.Y > height - _maxHeightIron &&
                n < _shearIronMax && n > _shearIronMin)
                chunk.SetBlock(blockOffset, new BlockIron());
        }

        public override void GenerateGold(Chunk chunk, BlockOffset blockOffset)
        {
            Vector3 coord = chunk.GetAbsPosition(blockOffset);

            float height = _landScapeHeight - _noiseLandscape.GetSimplexFractal(coord.X, coord.Z) * (_heightGain.GetSimplexFractal(coord.X, coord.Z) * 50);
            float n = _noiseGold.GetPerlin(coord.X, coord.Y, coord.Z);

            if (coord.Y <= height - _minHeightGold - 5 && coord.Y > height - _maxHeightGold &&
                n < _shearGoldMax && n > _shearGoldMin)
                chunk.SetBlock(blockOffset, new BlockGold());
        }

        public override void GenerateDiamond(Chunk chunk, BlockOffset blockOffset)
        {
            Vector3 coord = chunk.GetAbsPosition(blockOffset);

            float height = _landScapeHeight - _noiseLandscape.GetSimplexFractal(coord.X, coord.Z) * (_heightGain.GetSimplexFractal(coord.X, coord.Z) * 50);
            float n = _noiseDiamond.GetPerlin(coord.X, coord.Y, coord.Z);

            if (coord.Y <= height - _minHeightDiamond - 5 && coord.Y > height - _maxHeightDiamond &&
                n < _shearDiamondMax && n > _shearDiamondMin)
                chunk.SetBlock(blockOffset, new BlockDiamond());
        }
    }
}
