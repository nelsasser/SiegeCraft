using System.Collections.Generic;
using SiegeCraft_Fixed_.Anim;

namespace SiegeCraft_Fixed_.Actor {
	 abstract class Actor {

		public float x { get; set; } //x postion of the actor
		public float y { get; set; } //y positon of the actor
		protected Dictionary<string, Animation> animations = null; //dictionary of all of the 
		protected Animation currentAnimation = null; //current animation of the actor
		protected string currentAnimationKey = ""; //key for current animation
		public bool destroy = false; //destroy is true if actor should be removed from actor manager

		//sets the current animation of the actor
		protected void setCurrentAnimation(string key) {
			currentAnimation = animations[key];
			currentAnimationKey = key;
		}

		//all initialization should be done and called in this method
		public abstract void init();

		//all updates to position, rotation, state, etc should be done in update method
		public abstract void update();

		//draws the current frame of the actor
		public void draw() {
			currentAnimation.draw(x, y);
		}

	}
}
