using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using SiegeCraft_Fixed_;
using SiegeCraft_Fixed_.World;

namespace World {
	class Chunk {

		List<Cell> cells;

		public static readonly int WIDTH = 128;
		public static readonly int HEIGHT = 128;

		public Chunk(List<Cell> cells) {
			this.cells = cells;
		}

		public void draw(SpriteBatch sb, Texture2D tileSetTexture, Camera camera) {

			int cellsDrawn = 0;

			for(int y = (int)(camera.location.Y / Tile.TILE_HEIGHT / camera.viewScale); y < ((int)camera.location.Y + 600) / Tile.TILE_HEIGHT; y++) {
				for(int x = (int)(camera.location.X / Tile.TILE_WIDTH / camera.viewScale); x < ((int)camera.location.X + 900) / Tile.TILE_WIDTH; x++) {
					int place = indexToPlace(Math.Min(x, Chunk.WIDTH - 1), Math.Min(y, Chunk.HEIGHT - 1));
					cells[place].draw(sb, tileSetTexture, camera);

					cellsDrawn++;
				}
			}

			//Console.Write(cellsDrawn + " cells drawn\n");
		}

		private int indexToPlace(int x, int y) {
			return (y * HEIGHT) + x;
		}
			
	}
}
