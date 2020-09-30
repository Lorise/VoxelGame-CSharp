using Microsoft.Xna.Framework;
using VoxelGame.GameCode.Map;

namespace VoxelGame.GameCode.Other
{
    static class CoordinateConverter
    {
        public static BlockOffset ToVoxelPosition(Vector3 coord)
        {
            return new BlockOffset(
                (int)(coord.X % Chunk.SizeX),
                (int)(coord.Y % Chunk.SizeY),
                (int)(coord.Z % Chunk.SizeZ));
        }

        public static ChunkOffset ToChunkPosition(Vector3 coord)
        {
            return new ChunkOffset(
                (int) (coord.X / Chunk.SizeX),
                (int) (coord.Y / Chunk.SizeY),
                (int) (coord.Z / Chunk.SizeZ));
        }

        public static Vector3 ToAbsPosition(ChunkOffset chunkOffset)
        {
            return new Vector3(
                chunkOffset.X * Chunk.SizeX,
                chunkOffset.Y * Chunk.SizeY,
                chunkOffset.Z * Chunk.SizeZ);
        }

        public static Vector3 ToAbsPosition(ChunkOffset chunkOffset, BlockOffset blockOffset)
        {
            return new Vector3(
                chunkOffset.X * Chunk.SizeX + blockOffset.X,
                chunkOffset.Y * Chunk.SizeY + blockOffset.Y,
                chunkOffset.Z * Chunk.SizeZ + blockOffset.Z);
        }
    }
}
