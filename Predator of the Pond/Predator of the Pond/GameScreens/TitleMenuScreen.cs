using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

using Screen_Management_Library;
using Screen_Management_Library.Controls;

namespace Predator_of_the_Pond.GameScreens
{
    public class TitleMenuScreen : BaseGameState
    {
        PictureBox background;
        LinkLabel startGame;
        LinkLabel instructions;
        LinkLabel about;

        public TitleMenuScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            ContentManager Content = Game.Content;
            background = new PictureBox(Content.Load<Texture2D>("Backgrounds/menu"), GameRef.ScreenRectangle);
            ControlManager.Add(background);

            startGame = new LinkLabel();
            startGame.Text = "Start Game";
            startGame.Position = new Vector2(700, 250);
            startGame.Selected += new EventHandler(startGame_Selected);
            ControlManager.Add(startGame);

            instructions = new LinkLabel();
            instructions.Text = "Instructions";
            instructions.Position = new Vector2(685, 350);
            instructions.Selected += new EventHandler(instructions_Selected);
            ControlManager.Add(instructions);

            about = new LinkLabel();
            about.Text = "About";
            about.Position = new Vector2(770, 450);
            about.Selected += new EventHandler(about_Selected);
            ControlManager.Add(about);

            ControlManager.NextControl();
        }

        void about_Selected(object sender, EventArgs e)
        {
            Process.Start("http://jamorris.co.uk/");
        }

        void instructions_Selected(object sender, EventArgs e)
        {
            click.Play();
            StateManager.ChangeState(GameRef.InstructionsScreen);
        }

        void startGame_Selected(object sender, EventArgs e)
        {
            click.Play();
            StateManager.ChangeState(GameRef.GameScreen);
        }

        public override void Draw(GameTime gameTime)
        {

            GameRef.SpriteBatch.Begin();
            base.Draw(gameTime);
            ControlManager.Draw(GameRef.SpriteBatch);
            BubbleManager.Draw(GameRef.SpriteBatch);
            GameRef.SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if (InputHandler.LeftMousePressed())
                BubbleManager.Create(new Vector2(InputHandler.MouseState.X, InputHandler.MouseState.Y));
            ControlManager.Update(gameTime);
            base.Update(gameTime);
            BubbleManager.Update(gameTime);
        }
    }
}
