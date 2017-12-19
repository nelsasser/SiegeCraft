using SiegeCraft_Fixed_.World;
using System.Collections.Generic;

namespace World {
	class ChunkBuilder {

		public ChunkBuilder() {
		}

		/**
			builds a level from a file.
			returns true if able to succesfully load and build level
			returns false if unable to load file, or if level file is incorrect
		*/
		public List<Cell> buildChunk(List<Tile[,]> layers) {
			List<Cell> cells = new List<Cell>();

			int size = Chunk.WIDTH * Chunk.HEIGHT;

			for(int i = 0; i < size; i++) {
				cells.Add(new Cell(i % Chunk.WIDTH, i / Chunk.WIDTH));
			}

			foreach(Tile[,] layer in layers) {
				buildLayer(layer, cells);
			}

			return cells;
		}

		private void buildLayer(Tile[,] layer, List<Cell> cells) {
			foreach(Cell c in cells) {
				c.addTile(layer[c.x, c.y]);
			}
		}
	}
}
