using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SiegeCraft_Fixed_.Utility;
using System;
using System.Collections.Generic;
using NLua;

namespace SiegeCraft_Fixed_.ParticleEngine {
	class Emitter {

		/*@TODO:

			Add draw methods that loops through all of the particles and draws them
				-only loop until reach null in the buffer
			
			Create ParticleManager class
				-Manages creation, deletion and loading of particle systems

			Create ParticleLoader class to help with loading of particles created externally

			Create external particle editor that allows user to mess around with parameters and see their emitter / particles in real time.

			Add particle "jitter" (oscillate between size bounds)

			Finish update method
				-possible optimize by only updating every nth particle per update
					*have user be able to set this as a variabe when creating emitter
					*recommend to set it to 2 or 3;

			Make it so that particles can change texture over time

			Make it so particles can change color over time

			Make it so particles can change size over time
			
			Make it so basically everything things can change over time
		*/


		//emmitter vars
		private Random random;
		public Vector2 location { get; set; }		//location of the emitter
		private CircularBuffer<Particle> particles; //buffer that holds all of the particles
		private Texture2D refTexture;				//reference texture for the particles. acts as texture atlas
		private bool isBurst;						//indicates whether or not the emitter is a burst emitter or not (emits only initial amount of particles, then get deleted)
		private int numParticles;					//the total number of particles the system holds
		private int life;							//how long the emitter has existed
		private int initParticleCount;              //the initial amount of particles that will be spawned
		private int particlesPerUpdate;             //the number of particles that the emitter will create every update
		private int individualTextureWidth;			//width of individual textures on reference texture
		private int individualTextureHeight;        //height of individual texture on reference texture
		private int particleUpdate;                 //defines the n when every nth particle gets updated
		private Lua lua;							//lua interpreter

		//vars for particle generation
		public float minSize { get; set; }          //minimum size of particle
		public float maxSize { get; set; }          //maximum size of particle
		public Vector2 minVelocity { get; set; }    //minimum starting velocity
		public Vector2 maxVelocity { get; set; }    //maximum starting velocity
		public int minLife { get; set; }            //minimum lifespan of particle
		public int maxLife { get; set; }            //maximum lifepan of particle
		public bool minAngle { get; set; }          //minimum starting angle of particle
		public bool maxAngle { get; set; }          //maximum starting angle of particle
		public Vector2 gravity { get; set; }		//particle acceleration
		public Vector2 startingTexture { get; set; }//starts with random texture from reference
		public bool jitter { get; set; }			//indicates whether or not particle will jitter (oscillate in size)
		public float jitterBounds { get; set; }		//how much the particle will jitter
		public float jitterTime { get; set; }		//How long a jitter "period" lasts
		public Color intialColor { get; set; }		//intial color of particle
		public Color fadeToColor { get; set; }		//color that particle will fade to
		public float initialAlpha { get; set; }		//intial alpha
		public float endAlpha { get; set; }			//alpha particle moves towards
													//defines how the texture will change through time
		public Dictionary<int, Texture2D> texLookup { get; set; }
		public bool lockAngleToVel { get; set; }	//determines if angle of particle is locked to the 
		public string accelEq { get; set; }			//lua function to determine acceleration at given point


		/*
		Creates an emitter but the emitter, however at this point the emitter is not assigned to any particle. The particle parameters get assigned when
		the emitter is created in the ParticleManager class.
		*/
		public Emitter(Vector2 location, int numParticles, Texture2D refTexture, int initParticleCount, bool isBurst) {
			this.location = location;
			this.numParticles = numParticles;
			this.particles = new CircularBuffer<Particle>(this.numParticles);
			this.refTexture = refTexture;
			this.initParticleCount = initParticleCount;
			this.isBurst = isBurst;

			this.lua = new Lua();
		}

		/*
		Randomly creates initial particles for the emitter off given 
		*/
		public void init() {
			for(int i = 0; i < initParticleCount; i++) {
				//@TODO:
				//Randomize intial values for in bounds defined above
				//create intial particles based off of said bounds
			}
		}

		/*
		updates all of the particles in the emitter.
		-returns true if it is a burst emitter and it is still updating any particles.
		-returns false if it is done updating particles so it can be deleted.
		*/
		public bool update() {
			//kill burst emitter if we have reached end of all particle lives
			if(this.life >= this.maxLife && this.isBurst) {
				return false;
			}

			//@TODO:
			//Create more particles based on how many should be created each update
			//Update all of the particles values
			return true;
		}

	}
}