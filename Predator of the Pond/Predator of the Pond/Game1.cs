using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Screen_Management_Library;
using Screen_Management_Library.Controls;

using Predator_of_the_Pond.GameScreens;

namespace Predator_of_the_Pond
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;

        const int screenWidth = 1280;
        const int screenHeight = 720;
        public readonly Rectangle ScreenRectangle;

        GameStateManager stateManager;
        public TitleMenuScreen TitleMenuScreen;
        public InstructionsScreen InstructionsScreen;
        public GameScreen GameScreen;
        public GameOverScreen GameOverScreen;
        public WinnerScreen WinnerScreen;

        public Song sadMusic;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            this.IsMouseVisible = true;

            Content.RootDirectory = "Content";
            ScreenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            Components.Add(new InputHandler(this));

            stateManager = new GameStateManager(this);
            Components.Add(stateManager);

            TitleMenuScreen = new TitleMenuScreen(this, stateManager);
            InstructionsScreen = new InstructionsScreen(this, stateManager);
            GameScreen = new GameScreen(this, stateManager);
            GameOverScreen = new GameOverScreen(this, stateManager);
            WinnerScreen = new WinnerScreen(this, stateManager);

            stateManager.ChangeState(TitleMenuScreen);
        }

        protected override void Initialize()
        {
           base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Bubble.Sprite = Content.Load<Texture2D>("bubble");
            sadMusic = Content.Load<Song>("Audio/sad_violin");
            Song song = Content.Load<Song>("Audio/music");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
            Enemy.Sprites[0] = Content.Load<Texture2D>("fishright");
            Enemy.Sprites[1] = Content.Load<Texture2D>("fishleft");
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            

            base.Draw(gameTime);
        }
    }
}
