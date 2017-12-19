using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeCraft_Fixed_.ParticleEngine {
	class ParticleManager {

		private ParticleLoader loader;


		/*
		All default values for particles and emitters
		*/
		//default 
		public readonly string DEFAULT_ACCELERATION_EQ = 
			@"
				function acc(time, current_acceleration)
					return current_acceleration
				end								
			";

		public readonly string DEFAULT_ALPHA_FADE =
			@"
				function alpha(current_life, max_life, time)
					return current_life / max_life
				end
			";

		public readonly string DEFAULT_COLOR_FADE =
			@"
				function color(current_life, max_life, time, current_color)
					return current_color
				end
			";

		public ParticleManager() {

		}

		public void draw() {
			//TODO create draw method
		}

	}
}
