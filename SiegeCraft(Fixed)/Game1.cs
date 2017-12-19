using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SiegeCraft_Fixed_.Actor;
using SiegeCraft_Fixed_.Anim;
using SiegeCraft_Fixed_.ParticleEngine;
using SiegeCraft_Fixed_.World;
using System;
using World;

namespace SiegeCraft_Fixed_ {
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game {
		public static GraphicsDeviceManager graphics;

		public static readonly int SCREEN_WIDTH = 1280;
		public static readonly int SCREEN_HEIGHT = 720;

		SpriteBatch spriteBatch;

		/*
		Load Effects
		*/
		Effect ambientLight;

		Level level;

		Player player = new Player("Nick");

		double deltaTime = 0;
		int totalFrames = 0;

		ActorManager actorManager = new ActorManager();
		ParticleManager particleManager = new ParticleManager();

		public Game1() {
			graphics = new GraphicsDeviceManager(this);

			graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
			graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;

			Content.RootDirectory = "Content";

			//setup animations
			AnimationLoader.content = Content;
			Animation.spriteBatch = spriteBatch;
		}

		protected override void Initialize() {
			//initialize and build level
			ChunkLoader loader = new ChunkLoader("test_level");
			LevelBuilder builder = new LevelBuilder();
			level = new Level(builder.buildLevel(loader.loadLevels()));

			base.Initialize();
		}

		protected override void LoadContent() {
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Tile.textureMap = Content.Load<Texture2D>(@"tileset");

			//load up all effects / shaders
			ambientLight = Content.Load<Effect>(@"fx/Ambient");

			// TODO: use this.Content to load your game content here
		}

		protected override void UnloadContent() {
			// TODO: Unload any non ContentManager content here
		}

		protected override void Update(GameTime gameTime) {
			if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here
			if(deltaTime < 1000) {
				deltaTime += gameTime.ElapsedGameTime.Milliseconds;
				totalFrames++;
			} else {
				Console.Write("fps: " + totalFrames / (deltaTime / 1000) + "\n");
				totalFrames = 0;
				deltaTime = 0;
			}

			player.camera.update(level);

			actorManager.update();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, null);

			level.draw(spriteBatch, Tile.textureMap, player.camera);

			actorManager.draw();

			particleManager.draw();

			spriteBatch.End();

			base.Draw(gameTime);

			Animation.frame++;
		}
	}
}
