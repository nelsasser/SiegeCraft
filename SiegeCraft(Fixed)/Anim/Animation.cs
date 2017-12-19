using Microsoft.Xna.Framework.Graphics;

namespace SiegeCraft_Fixed_.Anim {
	class Animation {

		public static SpriteBatch spriteBatch { get; set; }

		public static readonly int UPDATE = 12;
		public static int frame { get; set; }
		Texture2D atlas;
		private int width, height;

		public Animation(Texture2D atlas, int width, int height) {
			this.atlas = atlas;
			this.width = width;
			this.height = height;
		}

		public void draw(float x, float y) {
			
		}
	}
}
