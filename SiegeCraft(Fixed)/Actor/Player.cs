using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeCraft_Fixed_.Actor {
	class Player {

		public Camera camera { get; set; }
		public string name { get; }

		public Player(string name) {
			this.name = name;

			this.camera = new Camera();
		}

	}
}
