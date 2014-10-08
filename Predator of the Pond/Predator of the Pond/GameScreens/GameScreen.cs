using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Screen_Management_Library;
using Screen_Management_Library.Controls;

namespace Predator_of_the_Pond.GameScreens
{
    public class GameScreen : BaseGameState
    {
        PictureBox background;
        Player player;

        public GameScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
            player = new Player();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            ContentManager Content = Game.Content;
            background = new PictureBox(Content.Load<Texture2D>("Backgrounds/ingame"), GameRef.ScreenRectangle);
            ControlManager.Add(background);

            ControlManager.NextControl();

            player.Sprites[0] = Content.Load<Texture2D>("fishright");
            player.Sprites[1] = Content.Load<Texture2D>("fishleft");
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();
            base.Draw(gameTime);
            ControlManager.Draw(GameRef.SpriteBatch);
            BubbleManager.Draw(GameRef.SpriteBatch);
            GameRef.SpriteBatch.End();
            player.Draw(GameRef.SpriteBatch);
            EnemyManager.Draw(GameRef.SpriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (InputHandler.LeftMousePressed())
                BubbleManager.Create(new Vector2(InputHandler.MouseState.X, InputHandler.MouseState.Y));
            ControlManager.Update(gameTime);
            base.Update(gameTime);
            BubbleManager.Update(gameTime);
            player.Update();
            EnemyManager.Update(player);
        }
    }
}
