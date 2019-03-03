using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
        Texture2D enemyTexture;
        Texture2D level1Text;
        Texture2D level1Icon;
        Texture2D cursor;
        Texture2D pressEnterToPlayHighlighted;
        Texture2D level1TextHighlighted;

        //Control
        KeyboardState kbState;
        KeyboardState pbState;

        //Entities
        Player player;
        List<Entity> listEntities;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Changes window size
            graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 1200;   // set this value to the desired height of your window
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
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
            IsMouseVisible = true;
            Helpers.mouseState = Mouse.GetState();
            Helpers.lastMouseState = Helpers.mouseState;

            listEntities = new List<Entity>();

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

            title = Content.Load<Texture2D>("title");
            pressEnterToPlay = Content.Load<Texture2D>("pressEnterToPlay");
            pressEnterToPlayHighlighted = Content.Load<Texture2D>("pressEnterToPlayHighlighted");
            playerTexture = Content.Load<Texture2D>("rabbit");
            enemyTexture = Content.Load<Texture2D>("enemy");
            level1Icon = Content.Load<Texture2D>("carrot");
            level1Text = Content.Load<Texture2D>("level1");
            level1TextHighlighted = Content.Load<Texture2D>("level1Highlighted");

            cursor = Content.Load<Texture2D>("arrow2");
            Mouse.SetCursor(MouseCursor.FromTexture2D(cursor, 0, 0));

            player = new Player(playerTexture, new Rectangle(100, 100, playerTexture.Width, playerTexture.Height), listEntities);

            //Puts enemies in list; will probably be handled with level later
            listEntities.Add(new GuardEnemy(enemyTexture, new Rectangle(1000, 500, enemyTexture.Width, enemyTexture.Height), player));
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
            Helpers.mouseState = Mouse.GetState();
            Helpers.lastMouseState = Helpers.mouseState;

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

                    foreach (Entity e in listEntities)
                    {
                        e.Update(gameTime);
                    }
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

            //Stuff to draw based on game state
            switch (gameState)
            {
                case GameState.TITLE_SCREEN:
                    TitleScreenDraw();
                    break;

                case GameState.LEVEL_SELECT:
                    LevelSelectDraw();
                    break;

                case GameState.INGAME_PLAYING:
                    player.Draw(spriteBatch);

                    //TODO: Draw enemies in list via level
                    foreach(Entity e in listEntities)
                    {
                        e.Draw(spriteBatch);
                    }
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
            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;

            int titleWidth = screenWidth * 4 / 5;
            int titleHeight = title.Height * titleWidth / title.Width;

            spriteBatch.Draw(title, new Rectangle(screenWidth / 2 - titleWidth / 2,
                screenHeight / 2 - titleHeight,
                titleWidth, titleHeight), Color.White);

            int pressEnterWidth = screenWidth / 3;
            int pressEnterHeight = pressEnterToPlay.Height * pressEnterWidth / pressEnterToPlay.Width;

            //Move to level select screen if player presses enter
            if (Helpers.CheckSingleKeyPress(Keys.Enter, kbState, pbState) ||
                (Helpers.IsHovering(screenWidth / 2 - pressEnterWidth / 2,
                3 * screenHeight / 5 - pressEnterHeight / 2, pressEnterWidth, pressEnterHeight) && 
                Helpers.GetLeftMousePressState() == Helpers.MousePressState.PRESS))
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
            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;
            
            int titleWidth = screenWidth * 4 / 5;
            int titleHeight = title.Height * titleWidth / title.Width;

            spriteBatch.Draw(title, new Rectangle(screenWidth / 2 - titleWidth / 2,
                screenHeight / 2 - titleHeight, 
                titleWidth, titleHeight), Color.White);
            
            int pressEnterWidth = screenWidth / 3;
            int pressEnterHeight = pressEnterToPlay.Height * pressEnterWidth / pressEnterToPlay.Width;

            if (Helpers.IsHovering(screenWidth / 2 - pressEnterWidth / 2,
                3 * screenHeight / 5 - pressEnterHeight / 2, pressEnterWidth, pressEnterHeight))
            {
                spriteBatch.Draw(pressEnterToPlayHighlighted, new Rectangle(screenWidth / 2 - pressEnterWidth / 2,
                    3 * screenHeight / 5 - pressEnterHeight / 2, pressEnterWidth, pressEnterHeight), Color.White);
            }
            else
            {
                spriteBatch.Draw(pressEnterToPlay, new Rectangle(screenWidth / 2 - pressEnterWidth / 2,
                    3 * screenHeight / 5 - pressEnterHeight / 2, pressEnterWidth, pressEnterHeight), Color.White);
            }
        }

        /// <summary>
        /// Updates the level select screen.
        /// </summary>
        protected void LevelSelectUpdate()
        {
            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;

            int l1IconWidth = screenWidth / 6;
            int l1IconHeight = level1Icon.Height * l1IconWidth / level1Icon.Width;
            int l1Iconx = screenWidth / 5 - l1IconWidth / 2;
            int l1Icony = screenHeight / 3 - l1IconHeight / 2;

            spriteBatch.Draw(level1Icon, new Rectangle(l1Iconx, l1Icony, l1IconWidth, l1IconHeight), Color.White);

            int l1TextWidth = screenWidth / 5;
            int l1TextHeight = level1Text.Height * l1TextWidth / level1Text.Width;
            int l1Textx = l1Iconx + l1IconWidth / 2 - l1TextWidth / 2;
            int l1Texty = l1Icony + l1IconHeight;

            

            //Move to level select screen if player presses spaentercebar
            if (Helpers.CheckSingleKeyPress(Keys.Enter, kbState, pbState))
            {
                //this.currentLevel = new Level("LevelStructures/level1.level");
                gameState = GameState.INGAME_PLAYING;
            }
        }

        /// <summary>
        /// Draws the screen for the Level Select screen.
        /// </summary>
        protected void LevelSelectDraw()
        {
            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;

            int l1IconWidth = screenWidth / 6;
            int l1IconHeight = level1Icon.Height * l1IconWidth / level1Icon.Width;
            int l1Iconx = screenWidth / 5 - l1IconWidth / 2;
            int l1Icony = screenHeight / 3 - l1IconHeight / 2;

            spriteBatch.Draw(level1Icon, new Rectangle(l1Iconx, l1Icony, l1IconWidth, l1IconHeight), Color.White);

            int l1TextWidth = screenWidth / 5;
            int l1TextHeight = level1Text.Height * l1TextWidth / level1Text.Width;
            // Level 1 select Text is in terms of the icon
            int l1Textx = l1Iconx + l1IconWidth / 2 - l1TextWidth / 2;  
            int l1Texty = l1Icony + l1IconHeight;

            if (Helpers.IsHovering(l1Textx, l1Texty, l1TextWidth, l1TextHeight) || 
                Helpers.IsHovering(l1Iconx, l1Icony, l1IconWidth, l1IconHeight))
            {
                spriteBatch.Draw(level1TextHighlighted, new Rectangle(l1Textx, l1Texty, l1TextWidth, l1TextHeight), Color.White);
            }
            else
            {
                spriteBatch.Draw(level1Text, new Rectangle(l1Textx, l1Texty, l1TextWidth, l1TextHeight), Color.White);
            }
        }

        public Texture2D GetEnemy ()
        {
            return this.enemyTexture;
        }

    }
}
