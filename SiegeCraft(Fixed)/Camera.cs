using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using World;

namespace SiegeCraft_Fixed_ {
	class Camera {

		public Vector2 location = Vector2.Zero;

		public float viewScale { get; set; }

		private int moveSpeed = 5;

		public Camera() {
			viewScale = 1;  
		}

		public void update(Level level) {
			KeyboardState ks = Keyboard.GetState();
			MouseState ms = Mouse.GetState();

			if(ks.IsKeyDown(Keys.A)) {
				this.location.X = MathHelper.Clamp(this.location.X - moveSpeed, 0, (Chunk.WIDTH - 5) * Tile.TILE_WIDTH);
			}
			if(ks.IsKeyDown(Keys.W)) {
				this.location.Y = MathHelper.Clamp(this.location.Y - moveSpeed, 0, (Chunk.WIDTH - 5) * Tile.TILE_WIDTH);
			}
			if(ks.IsKeyDown(Keys.S)) {
				this.location.Y = MathHelper.Clamp(this.location.Y + moveSpeed, 0, (Chunk.WIDTH - 5) * Tile.TILE_WIDTH);
			}
			if(ks.IsKeyDown(Keys.D)) {
				this.location.X = MathHelper.Clamp(this.location.X + moveSpeed, 0, (Chunk.WIDTH - 5) * Tile.TILE_WIDTH);
			}

			viewScale = (float)(ms.ScrollWheelValue + 120) / 120f;

			if(viewScale < 0) {
				viewScale = -1 / viewScale;
			} else if(viewScale == 0) {
				viewScale = 1;
			}

			Console.WriteLine(viewScale);
		}
	}
}
