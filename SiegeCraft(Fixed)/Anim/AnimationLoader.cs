using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SiegeCraft_Fixed_.Anim {
	class AnimationLoader {

		public static ContentManager content { get; set; }

		public static Texture2D loadAnimation(string src, string type) {
			Texture2D tex = content.Load<Texture2D>(src + @"\" + type + @"\" + type);

			return tex;
		}

		public static Dictionary<string, Animation> loadAllAnimations(string src, string[] types) {
			Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

			return animations;
		}
	}
}
