using Microsoft.Xna.Framework.Graphics;

namespace World {
	public enum TileType {
		FLOOR = 0,
		WALL = 1
	}

	class Tile {
		public static Texture2D textureMap;

		public int x { get; set; }
		public int y { get; set; }

		public int texLookup { get; set; }

		public TileType type { get; set; }

		public static readonly int TILE_WIDTH = 32;
		public static readonly int TILE_HEIGHT = 32;

		/*
		ALL TEXTURE LOOKUPS
		*/
		public static int GRASS = 1;
		public static int ROCK = 0;
		public static int DIRT = 2;
		public static int WATER = 4;

		public Tile(int x, int y, int texLookup, TileType type) {
			this.x = x;
			this.y = y;
			this.texLookup = texLookup;
			this.type = type;
		}
	}
}
