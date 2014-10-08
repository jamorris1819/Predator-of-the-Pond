using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using Screen_Management_Library;
using Screen_Management_Library.Controls;

namespace Predator_of_the_Pond.GameScreens
{
    public abstract partial class BaseGameState : GameState
    {
        protected Game1 GameRef;
        protected ControlManager ControlManager;

        protected SoundEffect controlChange;
        protected SoundEffect controlSelect;

        protected SoundEffect click;

        protected SpriteFont mainFont;
        protected SpriteFont smallFont;

        public BaseGameState(Game game, GameStateManager manager)
            : base(game, manager)
        {
            GameRef = (Game1)game;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;
            mainFont = Content.Load<SpriteFont>("Fonts/MainFont");
            smallFont = Content.Load<SpriteFont>("Fonts/SmallFont");
            ControlManager = new ControlManager(mainFont);
            click = Content.Load<SoundEffect>("Audio/bubble");
            base.LoadContent();
        }

        void BaseGameState_VisibleChanged(object sender, EventArgs e)
        {

        }

        protected override void StateChange(object sender, EventArgs e)
        {
            base.StateChange(sender, e);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
