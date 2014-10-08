using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Predator_of_the_Pond
{
    class Bubble
    {
        public static Texture2D Sprite;
        public Vector2 Position;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, new Rectangle((int)Position.X, (int)Position.Y, Sprite.Width, Sprite.Height), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Position.Y -= 4;
            Random random = new Random();
            if (random.Next(1, 3) == 1) Position.X += 2;
            else Position.X -= 2;
        }
    }
}
