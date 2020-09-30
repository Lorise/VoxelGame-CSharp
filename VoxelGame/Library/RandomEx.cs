using System;

namespace VoxelGame.Libraly
{
    class RandomEx
    {
        private readonly Random _random;

        public RandomEx() => _random = new Random();

        public RandomEx(int seed) => _random = new Random(seed);

        public void NextBytes(byte[] buffer) => _random.NextBytes(buffer);

        public byte[] NextBytes(int count)
        {
            byte[] bytes = new byte[count];
            _random.NextBytes(bytes);
            return bytes;
        }

        public int Next() => _random.Next();
        public int Next(int max) => _random.Next(max);
        public int Next(int min, int max) => _random.Next(min, max);

        public float NextFloat() => (float) _random.NextDouble();
        public float NextFloat(float max) => (float)_random.NextDouble() * max;
        public float NextFloat(float min, float max) => (float) (_random.NextDouble() * (max - min) + min);

        public double NextDouble() => _random.NextDouble();
        public double NextDouble(double max) => _random.NextDouble() * max;
        public double NextDouble(double min, double max) => _random.NextDouble() * (max - min) + min;
    }
}
