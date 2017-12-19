using System;
using System.Collections.Generic;
using System.IO;
using World;

namespace SiegeCraft_Fixed_.World {
	class ChunkLoader {

		//private String levelDir { get; set; }

		public ChunkLoader() {
			//this.levelDir = levelDir;
		}

		/*
		Loads chunk a chunk from  a file

			NOT YET IMPLEMENTED
		*/
		//public List<Tile[,]> loadLevels(String file) {
		//	List<Tile[,]> layers =  new List<Tile[,]>();
		//
		//	String folderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"..\..\..\" + @"\Content\levels\" + this.levelDir;
		//
		//	foreach(String file in Directory.EnumerateFiles(folderPath, "*.csv")) {
		//		layers.Add(createLayer(file));
		//	}
		//
		//	return layers;
		//}

		public List<Tile[,]> loadChunk(List<int[,]> tileData) {
			List<Tile[,]> chunkLayers = new List<Tile[,]>();

			foreach(int[,] layer in tileData) {
				chunkLayers.Add(createLayer(layer));
			}

			return chunkLayers;
		}

		/*
		Create layer from data
		*/
		private Tile[,] createLayer(int[,] layer) {
			Tile[,] tiles = new Tile[layer.GetLength(0), layer.GetLength(1)];

			for(int y = 0; y < Chunk.HEIGHT; y++) {
				for(int x = 0; x < Chunk.WIDTH; x++) {
					Tile t = new Tile(x * Tile.TILE_WIDTH, y * Tile.TILE_HEIGHT, layer[x, y], (TileType)layer[x, y]);
					tiles[x, y] = t;
				}
			}

			return tiles;
		}

		/*
			Creates a single layer from each 
		*/
		private Tile[,] createLayer(String file) {
			Tile[,] tiles = new Tile[0, 0];
			try {
				String[] lines = System.IO.File.ReadAllLines(file);

				int worldHeight = lines.Length;
				int worldWidth = lines[0].Split(',').Length;

				tiles = new Tile[worldWidth, worldHeight];

				for(int y = 0; y < worldHeight; y++) {

					String row = lines[y];
					String[] cells = row.Split(',');

					for(int x = 0; x < worldWidth; x++) {
						Tile t = new Tile(x * Tile.TILE_WIDTH, y * Tile.TILE_HEIGHT, int.Parse(cells[x]), (TileType)int.Parse(cells[x]));
						tiles[x, y] = t;
					}
				}
				return tiles;
			}
			catch(IndexOutOfRangeException e) {
				Console.Write("jumped out the game time to get back in!\n");
				return tiles;
			}
		}
	}
}
