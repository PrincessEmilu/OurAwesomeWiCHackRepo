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
       VICTORY          // You have beat the specific level.
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState gameState;
        SpriteFont font;
    
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
        Texture2D obstacleTexture;
        Texture2D finishTexture;
        Texture2D victoryText;
        Texture2D continueText;
        Texture2D continueTextHighlight;

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
            font = Content.Load<SpriteFont>("SFPixelate");

            // Sprites
            playerTexture = Content.Load<Texture2D>("rabbit");
            enemyTexture = Content.Load<Texture2D>("enemy");
            obstacleTexture = Content.Load<Texture2D>("obstacleTemp");
            finishTexture = Content.Load<Texture2D>("finishTemp");
            cursor = Content.Load<Texture2D>("arrow2");

            // Decor
            level1Icon = Content.Load<Texture2D>("carrot");

            // Text
            title = Content.Load<Texture2D>("title");
            victoryText = Content.Load<Texture2D>("Victory");
            level1Text = Content.Load<Texture2D>("level1");
            level1TextHighlighted = Content.Load<Texture2D>("level1Highlighted");
            pressEnterToPlay = Content.Load<Texture2D>("pressEnterToPlay");
            pressEnterToPlayHighlighted = Content.Load<Texture2D>("pressEnterToPlayHighlighted");
            continueText = Content.Load<Texture2D>("continueText");
            continueTextHighlight = Content.Load<Texture2D>("continueHighlight");
            
            Mouse.SetCursor(MouseCursor.FromTexture2D(cursor, 0, 0));

            player = new Player(playerTexture, new Rectangle(100, 100, playerTexture.Width, playerTexture.Height), listEntities);
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
            Helpers.lastMouseState = Helpers.mouseState;
            Helpers.mouseState = Mouse.GetState();
            

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
                    InGameUpdate(gameTime);
                    break;

                case GameState.INGAME_HACKING:
                    break;

                case GameState.VICTORY:
                    VictoryUpdate();
                    break;
            }

            base.Update(gameTime);
        }

        protected void InGameUpdate (GameTime gameTime)
        {
            //Calls player update logic
            player.Update(gameTime);

            foreach (Entity e in listEntities)
            {
                e.Update(gameTime);
                if (typeof(Finish).IsInstanceOfType(e) &&
                    e.Position.Intersects(player.Position))
                {
                    this.gameState = GameState.VICTORY;
                }
            }

            if (Helpers.CheckHack(listEntities))
            {
                this.gameState = GameState.INGAME_HACKING;
            }
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

                    //TODO: Draw enemies in list via level
                    foreach (Entity e in listEntities)
                    {
                        //Draws hackable enemies differently
                        if (e is HackableEnemy)
                        {
                            ((HackableEnemy)e).DrawHack(spriteBatch);
                        }
                    }

                    //As of right now, draws like normal.
                    player.Draw(spriteBatch);
                    break;

                case GameState.VICTORY:
                    VictoryDraw();
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
            

            int pressEnterWidth = screenWidth / 3;
            int pressEnterHeight = pressEnterToPlay.Height * pressEnterWidth / pressEnterToPlay.Width;

            // Move to level select screen if player presses enter
            if (Helpers.CheckSingleKeyPress(Keys.Enter, kbState, pbState))
            {
                gameState = GameState.LEVEL_SELECT;
            }

            // Move to level select screen if player clicks the text
            if (Helpers.IsHovering(screenWidth / 2 - pressEnterWidth / 2,
                3 * screenHeight / 5 - pressEnterHeight / 2, pressEnterWidth, pressEnterHeight) &&
                Helpers.GetLeftMousePressState() == Helpers.MousePressState.PRESS)
            { gameState = GameState.LEVEL_SELECT; }

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

            int l1TextWidth = screenWidth / 5;
            int l1TextHeight = level1Text.Height * l1TextWidth / level1Text.Width;
            int l1Textx = l1Iconx + l1IconWidth / 2 - l1TextWidth / 2;
            int l1Texty = l1Icony + l1IconHeight;

            //Move to level select screen if player presses spaentercebar
            if (Helpers.CheckSingleKeyPress(Keys.Enter, kbState, pbState) ||
                ((Helpers.IsHovering(l1Textx, l1Texty, l1TextWidth, l1TextHeight) ||
                Helpers.IsHovering(l1Iconx, l1Icony, l1IconWidth, l1IconHeight)) && 
                Helpers.GetLeftMousePressState() == Helpers.MousePressState.PRESS))
            {
                MakeLevel1();
                gameState = GameState.INGAME_PLAYING;
            }

            if ((Helpers.IsHovering(l1Textx, l1Texty, l1TextWidth, l1TextHeight) ||
                Helpers.IsHovering(l1Iconx, l1Icony, l1IconWidth, l1IconHeight)) &&
                Helpers.GetLeftMousePressState() == Helpers.MousePressState.PRESS)
            {
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

        protected void VictoryDraw ()
        {
            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;

            int victoryX = (screenWidth / 2) - (victoryText.Width / 2);
            int victoryY = (screenHeight / 2) - (screenHeight / 8);

            int continueX = (screenWidth / 2) - (continueText.Width / 2);
            int continueY = (screenHeight / 2) + (screenHeight / 8);

            spriteBatch.Draw(victoryText,
                new Rectangle(
                    victoryX, 
                    victoryY, 
                    victoryText.Width, 
                    victoryText.Height),
                Color.White);

            if (Helpers.IsHovering(continueX, continueY, 
                continueText.Width, continueText.Height))
            {
                spriteBatch.Draw(continueTextHighlight,
                    new Rectangle(
                        continueX,
                        continueY,
                        continueText.Width,
                        continueText.Height),
                    Color.White);
            }
            else
            {
                spriteBatch.Draw(continueText,
                    new Rectangle(
                        continueX,
                        continueY,
                        continueText.Width,
                        continueText.Height),
                    Color.White);

            }

        }

        protected void VictoryUpdate ()
        {
            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;

            int continueX = (screenWidth / 2) - (continueText.Width / 2);
            int continueY = (screenHeight / 2) + (screenHeight / 8);

            if (Helpers.CheckSingleKeyPress(Keys.Enter, kbState, pbState) ||
                Helpers.IsHovering(
                    continueX, 
                    continueY, 
                    continueTextHighlight.Width, 
                    continueTextHighlight.Height))
            {
                gameState = GameState.INGAME_PLAYING;
                MakeLevel2();
            }
        }

        /// <summary>
        /// Adds obstacles to make sure the player can't go off the screen.
        /// </summary>
        private void SetUpLevelBound()
        {
            // Obstacles
            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;
            // Left
            listEntities.Add(new Obstacle(obstacleTexture, new Rectangle(0, 0, 1, screenHeight)));
            // Right
            listEntities.Add(new Obstacle(obstacleTexture, new Rectangle(screenWidth, 0, 1, screenHeight)));
            //Top
            listEntities.Add(new Obstacle(obstacleTexture, new Rectangle(0, 0, screenWidth, 1)));
            // Bottom
            listEntities.Add(new Obstacle(obstacleTexture, new Rectangle(0, screenHeight, screenWidth, 1)));
        }

        /// <summary>
        /// Method that generates level 1
        /// </summary>
        private void MakeLevel1 ()
        {
            listEntities.Clear();
            SetUpLevelBound();

            // Level Finish
            listEntities.Add(new Finish(finishTexture, new Rectangle(1200, 100, 100, 100)));

            // Add interactables
            listEntities.Add(new GuardEnemy(enemyTexture, new Rectangle(1000, 500, enemyTexture.Width, enemyTexture.Height), player));
            listEntities.Add(new PatrolingGuard(enemyTexture, new Rectangle(200, 800, enemyTexture.Width, enemyTexture.Height)));
        }

        private void MakeLevel2 ()
        {
            listEntities.Clear();
            SetUpLevelBound();

            // Level Finish
            listEntities.Add(new Finish(finishTexture, new Rectangle(1200, 500, 100, 100)));

            // Add interactables
        }

    }
}
