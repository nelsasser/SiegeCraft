using SiegeCraft_Fixed_.World;
using System.Collections.Generic;

namespace World {
	class LevelBuilder {

		public LevelBuilder() {
		}

		/**
			builds a level from a file.
			returns true if able to succesfully load and build level
			returns false if unable to load file, or if level file is incorrect
		*/
		public List<Cell> buildLevel(List<Tile[,]> layers) {
			List<Cell> cells; cells = new List<Cell>();

			Level.WIDTH = layers[0].GetLength(0);
			Level.HEIGHT = layers[0].GetLength(1);

			int size = Level.WIDTH * Level.HEIGHT;

			for(int i = 0; i < size; i++) {
				cells.Add(new Cell(i % Level.WIDTH, i / Level.WIDTH));
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
