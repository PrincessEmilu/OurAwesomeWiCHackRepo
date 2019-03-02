using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace coolGame
{


    /// <summary>
    /// Different states that the game can be in.
    /// </summary>
    enum GameState
    {
       TITLE_SCREEN,    // Title screen
       LEVEL_SELECT,    // You are selecting a level in the game
       INGAME_PLAYING,  // You are playing the game, walking around, etc. (PLAYING)
       INGAME_HACKING,  // You are hacking an object/world (PAUSED)
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState gameState;

        // DRAWING ATTRIBUTES
        Texture2D title;
        Texture2D pressEnterToPlay;
        Texture2D playerTexture;

        //Control
        KeyboardState kbState;
        KeyboardState pbState;

        //Entities
        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            this.gameState = GameState.TITLE_SCREEN;

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


            title = Content.Load<Texture2D>("title");   // loads the title
            pressEnterToPlay = Content.Load<Texture2D>("pressEnterToPlay");
            playerTexture = Content.Load<Texture2D>("rabbit");

            player = new Player(playerTexture, new Rectangle(100, 100, playerTexture.Width, playerTexture.Height), kbState);

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


            //Updates controls
            pbState = kbState;
            kbState = Keyboard.GetState();

            switch(gameState)
            {
                case GameState.TITLE_SCREEN:
                    TitleScreenUpdate();
                    break;
                case GameState.LEVEL_SELECT:
                    LevelSelectUpdate();
                    break;
                case GameState.INGAME_PLAYING:

                    //Calls player update logic
                    player.Update(gameTime);

                    break;
                case GameState.INGAME_HACKING:
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // TODO: Add your drawing code here
            switch (gameState)
            {
                case GameState.TITLE_SCREEN:
                    TitleScreenDraw();
                    break;
                case GameState.LEVEL_SELECT:
                    break;
                case GameState.INGAME_PLAYING:
                    break;
                case GameState.INGAME_HACKING:
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Does some stuff, updates the title screen
        /// </summary>
        protected void TitleScreenUpdate()
        {
            //Move to level select screen if player presses spacebar
            if (kbState.IsKeyDown(Keys.Space) && pbState.IsKeyUp(Keys.Space))
            {
                gameState = GameState.LEVEL_SELECT;
            }
        }

        /// <summary>
        /// Function responsible for drawing the title screen of the game.
        /// 
        /// Draws the title in the genter of the screen, and animates it.
        /// </summary>
        protected void TitleScreenDraw()
        {
            int width = title.Width;
            int height = title.Height;

            spriteBatch.Draw(title, new Rectangle(GraphicsDevice.Viewport.Width / 2 - title.Width / 2, 
                GraphicsDevice.Viewport.Height / 2 - title.Height, 
                title.Width, title.Height), Color.White);

            spriteBatch.Draw(pressEnterToPlay, new Rectangle(0, 0, pressEnterToPlay.Width, pressEnterToPlay.Height), Color.White);
        }

        /// <summary>
        /// Updates the level select screen.
        /// </summary>
        protected void LevelSelectUpdate()
        {
            //Move to level select screen if player presses spacebar
            if (kbState.IsKeyDown(Keys.Space) && pbState.IsKeyUp(Keys.Space))
            {
                gameState = GameState.INGAME_PLAYING;
            }
        }
    }
}
