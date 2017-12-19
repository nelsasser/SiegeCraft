using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SiegeCraft_Fixed_.ParticleEngine {
	public class Particle {

		/*@TODO

			Add comments to everything in here

			Add acceleration

			Values can change based on how much life they have left

			Fix draw method
				-refernce refTexture from Emitter.cs
				-picks what part of texture to reference

		*/

		public Texture2D texture { get; set; }
		public Vector2 position { get; set; }
		public Vector2 veloctiy { get; set; }
		public float angle { get; set; }
		public float angularVelocity { get; set; }
		public Color color { get; set; }
		public float size { get; set; }
		public int life { get; set; }

		public Particle(Texture2D texture, Vector2 position, Vector2 veloctiy, float angle, float angularVelocity, Color color, float size, int life) {
			this.texture = texture;
			this.position = position;
			this.veloctiy = veloctiy;
			this.angle = angle;
			this.angularVelocity = angularVelocity;
			this.color = color;
			this.size = size;
			this.life = life;
		}

		public void update() {
			life--;
			position += veloctiy;
			angle += angularVelocity;
		}

		public void draw(SpriteBatch sb) {
			Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
			Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);

			sb.Draw(texture, position, sourceRectangle, color, angle, origin, size, SpriteEffects.None, 0f);
		}

	}
}
