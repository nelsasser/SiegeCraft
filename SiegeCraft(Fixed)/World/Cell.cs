using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using World;

namespace SiegeCraft_Fixed_.World {
	class Cell {

		private List<Tile> tileLayers = new List<Tile>();

		public int x { get; }
		public int y { get; }

		public Cell(int x, int y) {
			this.x = x;
			this.y = y;
		}

		public void addTile(Tile t) {
			this.tileLayers.Add(t);
		}

		public void draw(SpriteBatch sb, Texture2D tileSetTexture, Camera camera) {

			for(int i = 0; i < tileLayers.Count(); i++) {
				if(tileLayers[i].texLookup != -1) {
					int[] pos = indexFromType(tileLayers[i].texLookup, Tile.textureMap.Bounds.Width / Tile.TILE_WIDTH);

					sb.Draw(
						tileSetTexture,
						new Rectangle((int)(x * Tile.TILE_WIDTH * camera.viewScale) - (int)camera.location.X, (int)(y * Tile.TILE_HEIGHT * camera.viewScale) - (int)camera.location.Y, (int)(Tile.TILE_WIDTH * camera.viewScale), (int)(Tile.TILE_HEIGHT * camera.viewScale)),
                        new Rectangle(pos[0] * Tile.TILE_WIDTH, pos[1] * Tile.TILE_HEIGHT, Tile.TILE_WIDTH, Tile.TILE_HEIGHT),
						Color.White);
				}
			}
		}

		private int[] indexFromType(int type, int columns) {
			int[] position = new int[2];

			position[0] = type % columns;//x position
			position[1] = type / columns;//y position

			return position;
		}
	}
}
