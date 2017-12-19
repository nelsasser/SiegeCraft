using SiegeCraft_Fixed_.Utility;
using System.Collections.Generic;

namespace SiegeCraft_Fixed_.Actor {
	class ActorManager {

		private LinkedList<Actor> actors = new LinkedList<Actor>();

		public ActorManager() {

		}

		//adds an actor to the list of actors
		public void addActor(Actor actor) {
			actors.AddLast(actor);
			actors.Last.Value.init();
		}

		//updates all of the actors
		//removes any actors that need to be destroyed
		public void update() {
			//iterate through the actors
			LinkedListIterator<Actor> iterator = new LinkedListIterator<Actor>(actors);
			while(iterator.hasNext()) {
				Actor a = iterator.next();
				
				//check whether or not to destroy the actor
				if(a.destroy) {
					iterator.remove();
				} else {
					a.update();
				}
			}
		}

		public void draw() {
			//iterate through the actors
			LinkedListIterator<Actor> iterator = new LinkedListIterator<Actor>(actors);
			while(iterator.hasNext()) {
				Actor a = iterator.next();
				a.draw();
			}
		}

	}
}
