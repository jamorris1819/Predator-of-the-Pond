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
    static class BubbleManager
    {
        static List<Bubble> bubbles = new List<Bubble>();

        public static List<Bubble> Bubbles
        {
            get { return bubbles; }
            set { bubbles = value; }
        }

        public static void Update(GameTime gameTime)
        {
            for(int i = 0; i < bubbles.Count; i++)
            {
                if (bubbles[i].Position.Y + Bubble.Sprite.Height < 0)
                    bubbles.RemoveAt(i);
                else
                    bubbles[i].Update(gameTime);
            }
            Random random = new Random();
            if (random.Next(0, 30) == 10)
                Create(new Vector2(random.Next(0, 761) + random.Next(500), 720));
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bubble bubble in bubbles)
                bubble.Draw(spriteBatch);
        }

        public static void Create(Vector2 pos)
        {
            Bubble bubble = new Bubble();
            bubble.Position = pos;
            bubbles.Add(bubble);
        }
    }
}
