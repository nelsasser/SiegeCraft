using Microsoft.Xna.Framework;
using SiegeCraft_Fixed_.Actor;
using SiegeCraft_Fixed_.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World;

namespace SiegeCraft_Fixed_.World {
	class WorldGenerator {

		private int seed;
		private int octaves;
		private float scale;
		private float persistance;
		private float lacunarity;

		public WorldGenerator(int seed, int octaves, float scale, float persistance, float lacunarity) {
			this.seed = seed;
			this.octaves = octaves;
			this.scale = scale;
			this.persistance = persistance;
			this.lacunarity = lacunarity;
		}

		public List<Cell> createLevel(float[,] noiseMap) {
			List<Cell> level = new List<Cell> ();

			for(int x = 0; x < noiseMap.GetLength(0); x++) {
				for(int y = 0; y < noiseMap.GetLength(1); y++) {

				}
			}

			return level;
		}

		/*
		Generates a noise map around the player that will be turned into the map
		This way the whole map doesn't have to be generated, only what is around them.	
		*/
		public float[,] generateTerrainNoiseMap(Player p) {
			//get the width and height for the map
			int width = (int)(Game1.SCREEN_WIDTH / Tile.TILE_WIDTH * p.camera.viewScale);
            int height = (int)(Game1.SCREEN_HEIGHT / Tile.TILE_HEIGHT * p.camera.viewScale);

			float[,] map = new float[width, height];

			System.Random prng = new Random(seed);

			//get offset values
			Vector2[] octaveOffsets = new Vector2[octaves];
			for(int i = 0; i < octaves; i++) {
				float offsetX = prng.Next(-100000, 100000) + p.camera.location.X;
				float offsetY = prng.Next(-100000, 100000) + p.camera.location.Y;

				octaveOffsets[i] = new Vector2(offsetX, offsetY);
			}

			//clamp the scale
			if(scale <= 0) {
				scale = 0.0001f;
			}

			float min = float.MinValue;
			float max = float.MaxValue;

			for(int x = 0; x < width; x++) {
				for(int y = 0; y < height; y++) {

					float amplitude = 1;
					float frequency = 1;
					float noiseHeight = 0;

					for(int i = 0; i < octaves; i++) {
						float sampleX = x / scale * frequency + octaveOffsets[i].X;
						float sampleY = y / scale * frequency + octaveOffsets[i].Y;

						float perlinValue = Noise.Perlin(sampleX, sampleY, 0);

						noiseHeight += perlinValue * amplitude;

						amplitude *= persistance;
						frequency *= lacunarity;
					}

					if(noiseHeight > max) {
						max = noiseHeight;
					} else if(noiseHeight < min) {
						min = noiseHeight;
					}

					map[x, y] = noiseHeight;
				}
			}

			for(int x = 0; x < width; x++) {
				for(int y = 0; y < height; y++) {
					map[x, y] = inverseLerp(min, max, map[x, y]);
				}
			}

			return map;
		}

		public float inverseLerp(float start, float end, float val) {
			return (val - start) / (end - start);
		}
	}
}
