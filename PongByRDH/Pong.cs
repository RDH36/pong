using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongByRDH
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Pong : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Bat playerOne;
        Bat playerTwo;
        Ball balle;
        bool started;
        public Pong()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ServiceHelper.Game = this;
            Components.Add(new KeybordService(this));
            Components.Add(new FPSCompents(this));
            Window.Title = "Appuyer sur entrer pour demmarer !";
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
            playerOne = new Bat(new Vector2(10, graphics.PreferredBackBufferHeight / 2), graphics.PreferredBackBufferHeight,
                Keys.S, Keys.Z);
            playerTwo = new Bat(new Vector2(770, graphics.PreferredBackBufferHeight / 2), graphics.PreferredBackBufferHeight,
                Keys.Down, Keys.Up);
            balle = new Ball(new Vector2(0, 0), graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferWidth);
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

            // TODO: use this.Content to load your game content here
            balle.LoadMusic(Content, "ballSplas", "maty");
            playerOne.LoadContent(Content, "raquette");
            playerTwo.LoadContent(Content, "raquette");
            playerOne.LoadFont(Content, "font");
            playerTwo.LoadFont(Content, "font");
            balle.LoadContent(Content, "balle");
            balle.Position = new Vector2(graphics.PreferredBackBufferWidth / 2 - balle.Texture.Width / 2, graphics.PreferredBackBufferHeight / 2
                - balle.Texture.Height / 2);
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

            // TODO: Add your update logic here
            if (started)
            {
                playerOne.Move(gameTime);
                playerTwo.Move(gameTime);
                balle.Move(gameTime, playerOne, playerTwo, ref started);
            }
            else
            {
                if (ServiceHelper.Get<IkeybordService>().IskeyDown(Keys.Enter))
                {
                    balle.restart(playerOne, playerTwo);
                    started = true;
                    Window.Title = "PONG BY RDH (Prototype)";
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            playerOne.Draw(spriteBatch);
            playerTwo.Draw(spriteBatch);
            playerOne.Draw(spriteBatch, new Vector2(10, 50), Color.Red);
            playerTwo.Draw(spriteBatch, new Vector2(700, 50), Color.Red);
            playerOne.DrawWin(spriteBatch, new Vector2(graphics.PreferredBackBufferWidth / 2 - 100, 100), Color.Gold);
            playerTwo.DrawWin(spriteBatch, new Vector2(graphics.PreferredBackBufferWidth / 2 - 100, 100), Color.Gold);
            balle.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
