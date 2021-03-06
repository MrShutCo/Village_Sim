﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Village_Sim.GameStates;
using Village_Sim.Helpers;
using Village_Sim.Sprites;

namespace Village_Sim {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class VillageSim : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public GameState gameState;
        public SpriteFont font;
        public KeyboardState keyBoard;
        public InputHandler inputHandler;
        public Texture2D background;
        public Script script;

        //Refactored stuff
        Simulation sim;

        //Ahh, feels good to be back in an XNA like setup
        public VillageSim() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            inputHandler = new InputHandler();
            // Create a new SpriteBatch, which can be used to draw textures.
            /*
            background = ;
            
            font = Content.Load<SpriteFont>("font");*/
            // TODO: use this.Content to load your game content here
            //script.addReference(gameState, "test"); // Allow our script to access the current GameState
            //script = new Script();

            spriteBatch = new SpriteBatch(GraphicsDevice);

            Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
            textures.Add("Villager", Content.Load<Texture2D>("Villager Old"));
            textures.Add("Background", Content.Load<Texture2D>("backgroundGear"));

            sim = new Simulation(textures);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //script.spawn();
            sim.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            sim.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
