using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using Screen_Management_Library;
using Screen_Management_Library.Controls;

namespace Predator_of_the_Pond.GameScreens
{
    public class InstructionsScreen : BaseGameState
    {
        PictureBox background;
        LinkLabel back;

        public InstructionsScreen(Game game, GameStateManager manager)
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
            background = new PictureBox(Content.Load<Texture2D>("Backgrounds/instructions"), GameRef.ScreenRectangle);
            ControlManager.Add(background);

            back = new LinkLabel();
            back.Text = "Back to menu";
            back.Position = new Vector2(800, 250);
            back.Selected += new EventHandler(back_Selected);
            ControlManager.Add(back);

            ControlManager.NextControl();
        }

        void back_Selected(object sender, EventArgs e)
        {
            click.Play();
            StateManager.ChangeState(GameRef.TitleMenuScreen);
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
