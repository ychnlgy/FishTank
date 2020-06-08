using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FishTank
{
    using FishTank.Source;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        EntityManager manager;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferHeight = 640
            };
            Content.RootDirectory = "Content";
            manager = new EntityManager();
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ImageCreator backgroundCreator = new ImageCreator(1f, spriteBatch, Content);
            ImageCreator characterCreator = new ImageCreator(0.5f, spriteBatch, Content);

            manager.Add(new Entity(backgroundCreator.Create("resources/tank")));

            Entity fish1 = new Entity(characterCreator.Create("resources/fish1"), new Vector2(150, 200), false);
            Entity fish2 = new Entity(characterCreator.Create("resources/fish2"), new Vector2(250, 300), false);
            Entity shrimp = new Entity(characterCreator.Create("resources/shrimp"), new Vector2(800, 500), true);
            manager.Add(fish1);
            manager.Add(fish2);
            manager.Add(shrimp);

            manager.Add(new Entity(backgroundCreator.Create("resources/plants")));
            manager.Add(new Entity(backgroundCreator.Create("resources/rocks")));
            manager.Add(new Entity(backgroundCreator.Create("resources/sand")));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            manager.Update(dt);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            manager.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
